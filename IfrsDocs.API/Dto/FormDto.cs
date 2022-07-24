﻿using IfrsDocs.Domain.Entities.Enums;
using System;

namespace IfrsDocs.API.Dto
{
    public class FormDto
    {
        public FormDto()
        {
            Status = FormStatus.Pendente;
        }
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int? CourseId { get; set; }
        public int? ReceiveDocumentTypeId { get; set; }
        public int? DocumentTypeId { get; set; }
        public FormStatus? Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public CourseDto Course { get; set; }
        public UserDto User { get; set; }
    }
}
