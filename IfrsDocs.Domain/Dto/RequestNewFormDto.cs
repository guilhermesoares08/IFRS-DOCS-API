using IfrsDocs.Domain.Dto;
using IfrsDocs.Domain.Entities.Enums;
using IfrsDocs.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public ReceiveDocumentType ReceiveDocumentType { get; set; }
        public DocumentType DocumentType { get; set; }
        public FormStatus? Status { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Note { get; set; }
        public List<FormDocumentOptionDto> FormDocumentOptions { get; set; }
    }
}
