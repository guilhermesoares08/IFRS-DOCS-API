using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IfrsDocs.Domain.Dto
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Role Role { get; set; }
    }
}