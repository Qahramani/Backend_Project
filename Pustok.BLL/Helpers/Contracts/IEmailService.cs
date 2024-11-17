namespace Pustok.BLL.Helpers.Contracts;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string body);
}
