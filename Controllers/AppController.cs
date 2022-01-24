using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using DutchTreat.Services;
using Microsoft.EntityFrameworkCore;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.Data.Repos;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IRepoDutch<Product> repo;

        public AppController(IMailService mailService,IRepoDutch<Product> _repo)
        {
            _mailService = mailService;
            repo = _repo;
        }
        public IActionResult Index()
        {
            var prod = this.repo.List();
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
                //Send the email
                _mailService.SendMessage("",model.subject,$"From: {model.name} - {model.email}, Message: {model.message}");
                ViewBag.UserMessage = "Message Sent";
                ModelState.Clear();
            }
            else
            {
                
            }
            return View();
        }
        public IActionResult Shop()
        {
            //var results = _context.products.OrderBy(p => p.Category).ToList();
            var results = this.repo.List();
            return View(results);
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
