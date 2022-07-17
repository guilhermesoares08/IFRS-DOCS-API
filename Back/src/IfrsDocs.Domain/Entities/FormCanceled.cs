using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfrsDocs.Domain
{
    public class FormCanceled
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public DateTime CanceledDate { get; set; }
        public string CanceledBy { get; set; }
    }
}
