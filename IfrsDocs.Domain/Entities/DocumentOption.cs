using IfrsDocs.Domain.Entities.Enums;
using System;

namespace IfrsDocs.Domain
{
    public class DocumentOption
    {
        public int Id { get; set; }

        public DocumentType DocumentTypeId { get; set; }

        public FieldType FieldType { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
