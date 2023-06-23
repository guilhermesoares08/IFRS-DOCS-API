using IfrsDocs.Domain.Dto;
using IfrsDocs.Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace IfrsDocs.Domain
{
    public class RequestNewFormDto
    {
        public RequestNewFormDto()
        {
            Status = FormStatus.Pendente;
            ReceiveDocumentType = ReceiveDocumentType.ByEmail;
            DocumentType = DocumentType.Historico;
        }
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int? CourseId { get; set; }
        public ReceiveDocumentType ReceiveDocumentType { get; set; }
        public DocumentType DocumentType { get; set; }
        public FormStatus? Status { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<FormDocumentOptionDto> FormDocumentOptionsDto { get; set; }
    }
}
