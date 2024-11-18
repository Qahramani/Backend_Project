using Microsoft.AspNetCore.Mvc;
using Pustok.BLL.Helpers.Contracts;
using Pustok.BLL.ViewModels.AccountViewModels;

namespace Pustok.MVC.Controllers;

public class ContactController : Controller
{
    private readonly IEmailService _emailService;

    public ContactController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public IActionResult SendMessage()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(ContactEmailSendViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        var emailBody = $@"
        <html>
            <body>
                <h2>New Contact Message</h2>
                <p><strong>Full Name:</strong> {model.FullName ?? "Not provided"}</p>
                <p><strong>Email:</strong> {model.Email ?? "Not provided"}</p>
                <p><strong>Phone:</strong> {model.Phone ?? "Not provided"}</p>
                <hr>
                <p><strong>Message:</strong></p>
                <p>{model.Message ?? "No message provided."}</p>
            </body>
        </html>";
        await _emailService.SendEmailAsync("gunelng@code.edu.az", model.Email,emailBody);

        return View();
    }

}
