﻿
using AutoMapper;
using IfrsDocs.Domain;
using IfrsDocs.Domain.Dto;
using IfrsDocs.Domain.Entities;
using IfrsDocs.Domain.Entities.Enums;
using IfrsDocs.Domain.Entities.Mail;
using IfrsDocs.Domain.Entities.Pagination;
using IfrsDocs.Domain.Extensions;
using IfrsDocs.Domain.Helpers;
using IfrsDocs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Transactions;

namespace IfrsDocs.Services
{
    public class FormService : BaseService<Form, IFormRepository>, IFormService
    {
        IUserRepository _userRepository;
        IFormDocumentOptionRepository _formDocumentOptionRepository;
        IMailService _mailService;
        MailSettings _mailSettings;

        public FormService(IFormRepository formRepository, IUserRepository userRepository, IFormDocumentOptionRepository formDocumentOptionRepository, IMailService mailService, MailSettings mailSettings) : base(formRepository)
        {
            _userRepository = userRepository;
            _formDocumentOptionRepository = formDocumentOptionRepository;
            _mailService = mailService;
            _mailSettings = mailSettings;
        }

        public Form GetFormById(int id)
        {
            return _repository.GetFormById(id);
        }

        public bool DeleteForm(int id)
        {
            try
            {
                var form = _repository.GetFormById(id);
                if (form == null) throw new System.Exception($"Form {id} para delete não encontrado");

                _repository.Delete<Form>(form);
                return _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PageList<Form> GetForms(PageParams pageParams)
        {
            return _repository.GetForms(pageParams);
        }

        public Form AddNewForm(RequestNewFormDto formDto)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    if (formDto == null) throw new ArgumentNullException(nameof(Form), "Entidade Form está nulo");
                    Form newForm = EntityConverter.ConvertToForm(formDto);

                    //Fill user info
                    var user = _userRepository.GetUserById(newForm.UserId.Value);
                    newForm.CreateBy = user.Login;
                    newForm.CPF = user.CPF;
                    newForm.Name = user.Login;
                    newForm.Email = user.Email;
                    
                    _repository.Add<Form>(newForm);
                    _repository.SaveChanges();

                    if (newForm.Id == 0) throw new Exception("Form não foi criado");

                    scope.Complete();

                    return newForm;
                }
                catch
                {
                    throw;
                }
            }
        }

        public Form UpdateFormStatus(int formId, UpdateFormStatusDto updateFormStatusDto)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    bool successSendMail = false;
                    var form = GetFormById(formId);
                    if (form == null) throw new Exception($"Id de formulário informado '{formId}' não encontrado");

                    var userUpdate = _userRepository.GetUserById(updateFormStatusDto.UserId);
                    if (userUpdate == null) throw new Exception($"Usuário {updateFormStatusDto.UserId} não encontrado!");

                    string oldStatus = form.Status.GetDescription();
                    form.UpdateDate = DateTime.Now;
                    form.Status = (FormStatus)updateFormStatusDto.Status;
                    form.UpdateBy = userUpdate.Login;

                    if (_mailSettings.IsEnabled)
                    {
                        successSendMail = ProcessMailForm(form, oldStatus, updateFormStatusDto.Attachments);
                    }
                    else
                    {
                        successSendMail = true;
                    }

                    if (successSendMail)
                    {
                        _repository.Update<Form>(form);
                        _repository.SaveChanges();
                        scope.Complete();
                    }
                    else
                    {
                        throw new Exception("Ocorreu um erro ao enviar o email.");
                    }
                    
                    return form;
                }
                catch
                {
                    throw;
                }
            }
        }

        private bool ProcessMailForm(Form form, string oldStatus, List<AttachmentData> attachments)
        {
            try
            {
                bool success = false;
                if (form == null) throw new ArgumentException("ProcessMailForm - form nulo para processamento de email");

                _mailService.ValidateEmail(form.Email);

                List<string> to = new List<string>();
                List<string> bcc = new List<string>();

                to.Add(form.Email);

                success = _mailService.SendFormChangedStatusMail(to, bcc, form, oldStatus, attachments);

                return success;
            }
            catch
            {
                throw;
            }
        }
    }
}
