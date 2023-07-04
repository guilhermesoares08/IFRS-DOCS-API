using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfrsDocs.Domain.Dto
{
    public class UserInfoDto
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public Role Role { get; set; }
    }
}
