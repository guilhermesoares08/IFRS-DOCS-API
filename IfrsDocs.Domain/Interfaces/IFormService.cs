﻿using IfrsDocs.Domain.Entities.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public interface IFormService : IBaseService<Form, IFormRepository>
    {
        public Form GetFormById(int id);

        public bool DeleteForm(int id);

        PageList<Form> GetForms(PageParams pageParams);
        public Form AddNewForm(RequestNewFormDto form);
        public Form UpdateFormStatus(int formId, UpdateFormStatusDto updateFormStatusDto);
    }
}
