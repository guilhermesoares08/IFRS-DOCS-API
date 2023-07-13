using System.Collections.Generic;

namespace IfrsDocs.Domain.Interfaces
{
    public interface IMailService
    {
        public void SendMail(List<string> to, List<string> bcc, string subject, string body);

        public void ValidateEmail(string email);

        public void SendFormChangedStatusMail(List<string> to, List<string> bcc, Form form, string oldStatus);
    }
}
