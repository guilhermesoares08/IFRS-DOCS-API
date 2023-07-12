using IfrsDocs.Domain.Entities.Enums;
using System;
using IfrsDocs.Domain.Extensions;
using IfrsDocs.Domain.Dto;
using IfrsDocs.Domain;

namespace IfrsDocs.API.Dto
{
    public class FormDto
    {
        public FormDto()
        {
            CreateDate = DateTime.Now;
            Status = (int)FormStatus.Pendente;
            DocumentType = Domain.Entities.Enums.DocumentType.Historico.GetDescription();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string ReceiveDocumentType { get; set; }
        public string DocumentType { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public CourseDto Course { get; set; }
        public UserDto User { get; set; }
        public string OptionsString { get; set; }
        public string Note { get; set; }
    }
}
