﻿using System;

namespace IfrsDocs.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Role Role { get; set; }
    }
}