using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IfrsDocs.Domain.Helpers
{
    public static class FormatterHelper
    {
        public static string FormatDocumentOptionInline(List<FormDocumentOption> options)
        {
            StringBuilder sb = new StringBuilder();
            if (options != null && options.Any())
            {
                foreach (var fd in options)
                {
                    if (fd == options.Last())
                    {
                        sb.AppendFormat("{0}", fd.DocumentOption.Description);
                    }
                    else
                    {
                        sb.AppendFormat("{0}, ", fd.DocumentOption.Description);
                    }

                }
            }
            return sb.ToString();
        }
    }
}
