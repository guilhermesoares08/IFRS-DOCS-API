
using IfrsDocs.Domain;
using IfrsDocs.Domain.Dto;
using IfrsDocs.Domain.Entities.Enums;
using IfrsDocs.Domain.Entities.Pagination;
using IfrsDocs.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace IfrsDocs.Services
{
    public class FormService : BaseService<Form, IFormRepository>, IFormService
    {
        IUserRepository _userRepository;
        IFormDocumentOptionRepository _formDocumentOptionRepository;
        public FormService(IFormRepository formRepository, IUserRepository userRepository, IFormDocumentOptionRepository formDocumentOptionRepository) : base(formRepository)
        {
            _userRepository = userRepository;
            _formDocumentOptionRepository = formDocumentOptionRepository;
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

                    var newForm = EntityConverter.CopyProperties<Form, RequestNewFormDto>(formDto);

                    _repository.Add<Form>(newForm);
                    _repository.SaveChanges();

                    if (newForm.Id == 0) throw new Exception("Id de form zerado");

                    int newFormId = newForm.Id;

                    foreach (var fdo in formDto.FormDocumentOptionsDto)
                    {
                        var newFdo = EntityConverter.CopyProperties<FormDocumentOption, FormDocumentOptionDto>(fdo);
                        newFdo.FormId = newFormId;
                        _formDocumentOptionRepository.Add<FormDocumentOption>(newFdo);
                    }
                    _formDocumentOptionRepository.SaveChanges();

                    scope.Complete();

                    return newForm;
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
