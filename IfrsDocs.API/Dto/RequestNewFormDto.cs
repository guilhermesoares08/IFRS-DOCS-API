using IfrsDocs.Domain.Entities.Enums;
using System;

namespace IfrsDocs.API.Dto
{
    public class RequestNewFormDto
    {
        public RequestNewFormDto()
        {
            Status = FormStatus.Pendente;
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int? CourseId { get; set; }
        public int? ReceiveDocumentTypeId { get; set; }
        public int? DocumentTypeId { get; set; }
        public FormStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
    }
}
