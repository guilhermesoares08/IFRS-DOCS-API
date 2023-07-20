using IfrsDocs.Domain.Entities;
using IfrsDocs.Domain.Entities.Mail;
using IfrsDocs.Domain.Exceptions;
using IfrsDocs.Domain.Extensions;
using IfrsDocs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace IfrsDocs.Domain.Services
{
    public class MailService : IMailService
    {
        MailSettings _mailSettings;
        public MailService(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public void SendMail(List<string> to, List<string> bcc, string subject, string body, List<AttachmentData> attachments = null)
        {
            MailMessage message = new MailMessage();

            foreach (string email in to)
            {
                message.To.Add(email);
            }

            if (bcc.Any())
            {
                foreach (string email in bcc)
                {
                    message.Bcc.Add(email);
                }
            }

            try
            {
                if (attachments != null && attachments.Any())
                {
                    foreach (var attachmentData in attachments)
                    {
                        var attachment = new Attachment(attachmentData.ContentStream, attachmentData.FileName);
                        message.Attachments.Add(attachment);
                    }
                }
            }
            catch
            {
                throw;
            }

            SmtpClient client = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = _mailSettings.EnableSsl,
                Host = _mailSettings.Host,
                Port = _mailSettings.Port,
                Credentials = new NetworkCredential(_mailSettings.NetworkCredential.UserName, _mailSettings.NetworkCredential.Password)
            };

            message.From = new MailAddress(_mailSettings.FromAddress);

            message.Subject = subject;
            message.Body = body + $"\n\n {_mailSettings.FromName}";
            message.IsBodyHtml = true;
            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message.ToString());
                Console.ResetColor();
                throw ex;
            }
        }

        public void ValidateEmail(string email)
        {
            // Expressão regular para validar o formato do e-mail
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Verifica se o e-mail corresponde ao padrão
            bool isValid = Regex.IsMatch(email, pattern);

            if (!isValid)
            {
                throw new InvalidEmailException(email);
            }
        }

        public bool SendFormChangedStatusMail(List<string> to, List<string> bcc, Form form, string oldStatus, List<AttachmentData> attachments = null)
        {
            try
            {
                string subject = "IFRS Campus Restinga - Sua solicitação ";
                string htmlBody = $"<h3>IFRS - Solicitação de Documentos Acadêmicos</h3>" +
                                $"<p>Referente à solicitação de <strong>{form.OptionsString}</strong> passou de <strong>{oldStatus}</strong> para <strong>{form.Status.GetDescription()}</strong>.</p></html>";

                if (form.Status == Entities.Enums.FormStatus.AguardandoRetirada
                    || form.Status == Entities.Enums.FormStatus.Atendida)
                {
                    subject += "está pronta!";
                }
                else
                {
                    subject += "trocou de status";
                }

                SendMail(to, bcc, subject, htmlBody, attachments);

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
