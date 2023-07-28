using DanteMulching.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;

namespace DanteMulching.Controllers
{
    public class HomeController : Controller
    {
        

      

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public bool SendMail(string name, string email, string message1)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            message.From = new MailAddress("jacobrivera7271996@gmail.com");
            message.To.Add("jacobrivera7271996@gmail.com");
            message.Subject = "Test email";
            message.IsBodyHtml = true;
            message.Body = "<p>Name: " + name + "</p>" + "<p>Email: " + email + "</p>" + "<p>Message: " + message1 + "</p>";

            smtpClient.Port = 587;
            smtpClient.Host = "jacobrivera7271996@gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("jacobrivera7271996@gmail.com", "mqxfddiphnwlykhf");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(message);
            return true;
        }

        
    }
}