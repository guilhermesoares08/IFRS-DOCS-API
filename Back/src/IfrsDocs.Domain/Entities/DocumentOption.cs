using System;

namespace IfrsDocs.Domain
{
    public class DocumentOption
    {
        public int Id { get; set; }

        public int DocumentTypeId { get; set; }

        public string FieldType { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
