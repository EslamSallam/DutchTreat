using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                MimeMessage message = new MimeMessage();

                MailboxAddress from = new MailboxAddress("Admin",
                "e.sallam@softexsw.com");
                message.From.Add(from);

                MailboxAddress to = new MailboxAddress("User",
                "eslam.salam1369@gmail.com");
                message.To.Add(to);

                message.Subject = "Test Email About MailKit";

                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = "<h1>Hello World!</h1>";
                bodyBuilder.TextBody = "Hello World!";

                message.Body = bodyBuilder.ToMessageBody();

                SmtpClient client = new SmtpClient();
                client.Connect("smtp_address_here", port_here, true);
                client.Authenticate("e.sallam@softexsw.com", "pwd_here");
            }
            else
            {

            }
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
