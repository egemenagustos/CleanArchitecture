using CleanArchitecture.Application.Service;
using GenericEmailService;
using System.Net.Mail;

namespace CleanArchitecture.Infrastructure.Service
{
    public sealed class MailService : IMailService
    {
        public async Task SendMailAsync(List<string> emails,string subject, string body, List<Attachment>? attachments)
        {
            SendEmailModel sendEmailModel = new()
            {
                Body = body,
                Attachments = attachments,
                Emails = emails,
                Email = "",
                Html = true,
                Password = "",
                Port = 465,
                Smtp = "",
                SSL = true,
                Subject = subject
            };
            await EmailService.SendEmailAsync(sendEmailModel);
        }
    }
}
