using System.Net;
using System.Net.Mail;

namespace IfrsDocs.Domain.Entities.Mail
{
    public class MailSettings
    {
        public bool EnableSsl { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public bool IsEnabled { get; set; }
        public NetworkCredential NetworkCredential { get; set; }
    }
}
