using IfrsDocs.Domain.Dto;
using IfrsDocs.Domain.Entities.Enums;
using System;

namespace IfrsDocs.API.Dto
{
    public class DocumentOptionDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DocumentTypeDto DocumentType { get; set; }
    }   
}
