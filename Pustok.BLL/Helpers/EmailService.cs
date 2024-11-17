﻿using Microsoft.Extensions.Configuration;
using Pustok.BLL.Helpers.Contracts;
using System.Net.Mail;
using System.Net;

namespace Pustok.BLL.Helpers;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var emailSettings = _configuration.GetSection("EmailSettings");

        using (var client = new SmtpClient(emailSettings["SmtpServer"], int.Parse(emailSettings["Port"])))
        {
            client.Credentials = new NetworkCredential(emailSettings["SenderEmail"], emailSettings["SenderPassword"]);
            client.EnableSsl = true;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailSettings["SenderEmail"], emailSettings["SenderName"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
        }
    }
}
