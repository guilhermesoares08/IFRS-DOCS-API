using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfrsDocs.Domain.Entities.Enums
{
    public enum RoleType
    {
        [Description("Admin")]
        Admin,
        [Description("User")]
        User
    }
}
