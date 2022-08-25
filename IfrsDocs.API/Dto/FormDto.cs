using IfrsDocs.Domain.Entities.Enums;
using System;
using IfrsDocs.Domain.Extensions;

namespace IfrsDocs.API.Dto
{
    public class FormDto
    {
        public FormDto()
        {
            Status = FormStatus.Pendente.GetDescription();
            DocumentType = Domain.Entities.Enums.DocumentType.Historico.GetDescription();
        }
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int? CourseId { get; set; }
        public string ReceiveDocumentType { get; set; }
        public string DocumentType { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public CourseDto Course { get; set; }
        public UserDto User { get; set; }
        public string OptionsString { get; set; }
    }
}
