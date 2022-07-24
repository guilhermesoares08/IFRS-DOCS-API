using IfrsDocs.Domain.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IfrsDocs.Domain
{
    public class Form
    {
        public Form()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int? CourseId { get; set; }
        public ReceiveDocumentType ReceiveDocumentType { get; set; }
        public int? DocumentTypeId { get; set; }
        public FormStatus? Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public Course Course { get; set; }        
        public User User { get; set; }
    }
}
