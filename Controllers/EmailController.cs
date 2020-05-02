using Microsoft.AspNetCore.Mvc;
using ExerciseWebDevelopment.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace ExerciseWebDevelopment.Controllers {
	public class EmailController : Controller {
		[HttpGet]
		public IActionResult Index () {
			return View();
		}
		[HttpPost]
		public IActionResult Index (EmailModel email) {
      if (!ModelState.IsValid) {
        return View("Index", email);
      }
      System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
      mail.From = new System.Net.Mail.MailAddress(email.srcEmail);
      mail.To.Add(email.desEmail);
      mail.Subject = email.title;
      mail.Body = email.content;
      mail.IsBodyHtml = true;
      System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
      smtp.Credentials = new System.Net.NetworkCredential(email.srcEmail, email.Password);
      smtp.EnableSsl = true;
      smtp.Send(mail);
      return View("SendSuccess", email);
		}
	}
}