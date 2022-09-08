﻿
using IfrsDocs.Domain;
using IfrsDocs.Domain.Entities.Enums;
using IfrsDocs.Domain.Entities.Pagination;
using System;
using System.Collections.Generic;

namespace IfrsDocs.Services
{
    public class FormService : BaseService<Form, IFormRepository>, IFormService
    {
        IUserRepository _userRepository;
        public FormService(IFormRepository formRepository, IUserRepository userRepository) : base(formRepository)
        {
            _userRepository = userRepository;
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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PageList<Form> GetForms(PageParams pageParams)
        {
            return _repository.GetForms(pageParams);
        }
    }
}
