using IfrsDocs.Domain.Entities;
using System.Collections.Generic;
using System.IO;

namespace IfrsDocs.Domain.Interfaces
{
    public interface IMailService
    {
        public void SendMail(List<string> to, List<string> bcc, string subject, string body, List<AttachmentData> attachments = null);

        public void ValidateEmail(string email);

        public bool SendFormChangedStatusMail(List<string> to, List<string> bcc, Form form, string oldStatus, List<AttachmentData> attachments = null);
    }
}
