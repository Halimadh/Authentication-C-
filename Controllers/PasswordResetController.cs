using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace WebApp.Controllers
{
    public class PasswordResetController : Controller
    {
        private readonly IJwtAuthenticationService _jwtAuthenticationService;
        private readonly IConfiguration _config;


        public IActionResult Index()
        {
            return View();
        }
        public PasswordResetController (IJwtAuthenticationService JwtAuthenticationService, IConfiguration config)
        {
            _jwtAuthenticationService = JwtAuthenticationService;
            _config = config;
        }
        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            var v = _jwtAuthenticationService.LaboExist(emailID);
            return v != null;
           
        }


        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string emailFor = "ResetPassword")
        {
            var verifyUrl = "/labo/" + emailFor ;
            var link = Url.Action(verifyUrl);

            var fromEmail = new MailAddress("dotnetawesome@gmail.com", "Dotnet Awesome");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "******"; // Replace with actual password

            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";
                body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
                    " successfully created. Please click on the below link to verify your account" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/>br/>We got request for reset your account password. Please click on the below link to reset your password" +
                    "<br/><br/><a href=" + link + ">Reset Password link</a>";
            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

    }
}
