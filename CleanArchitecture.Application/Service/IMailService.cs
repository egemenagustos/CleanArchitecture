using System.Net.Mail;

namespace CleanArchitecture.Application.Service
{
    public interface IMailService
    {
        Task SendMailAsync(List<string> emails, string subject, string body, List<Attachment>? attachments);
    }
}
