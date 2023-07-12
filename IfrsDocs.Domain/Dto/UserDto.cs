using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public class UserDto
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public RoleDto Role { get; set; }
    }
}