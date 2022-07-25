using IfrsDocs.Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace IfrsDocs.Domain
{
    public class DocumentOption
    {
        public int Id { get; set; }

        public DocumentType DocumentType { get; set; }

        public FieldType FieldType { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
        public List<FormDocumentOption> FormDocumentOptions { get; set; }
    }
}
