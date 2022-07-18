using IfrsDocs.Domain;
using System;

namespace IfrsDocs.API
{
    public class FormDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CourseString { get; set; }
        public int? ReceiveDocumentTypeId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public CourseDto Course { get; set; }
        public UserDto User { get; set; }
    }
}
