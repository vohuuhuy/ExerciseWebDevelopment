using Microsoft.AspNetCore.Mvc;
using ExerciseWebDevelopment.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace ExerciseWebDevelopment.Controllers
{
	public class LayoutController : Controller
	{
		private readonly IWebHostEnvironment _env;
    public LayoutController (IWebHostEnvironment env) {
      _env = env;
    }
    [HttpGet]
		public IActionResult Index()
		{
				return View();
		}
    [HttpGet]
		public IActionResult Emp()
		{
				return View("Emp");
		}
    [HttpPost]
		public IActionResult Emp (EmpModel emp) {
      if (!ModelState.IsValid) {
        return View("Emp", emp);
      }
      var newFileName = string.Empty;
      if (HttpContext.Request.Form.Files != null) {
        var fileName = string.Empty;
        string PathDB = string.Empty;
        var files = HttpContext.Request.Form.Files;
        foreach (var file in files) {
          if (file.Length > 0) {
            fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
            var FileExtension = Path.GetExtension(fileName);
            newFileName = myUniqueFileName + FileExtension;
            emp.Avatar = newFileName;
            fileName = Path.Combine(_env.WebRootPath, "images" + $@"/{newFileName}");
            string dataPathFile = Path.Combine(_env.WebRootPath, "emps" + $@"/{emp.EmpID}.txt");
            PathDB = "images/" + newFileName;
            string[] empInfo = {
              emp.EmpID,
              emp.Name,
              emp.BirthOfDate.ToShortDateString(),
              emp.Email,
              emp.Password,
              emp.Department,
              emp.Avatar
            };
            using (FileStream fs = System.IO.File.Create(fileName)) {
              file.CopyTo(fs);
              fs.Flush();
            }
            System.IO.File.WriteAllLines(dataPathFile, empInfo);
            break;
          }
        }
      }
			return View("EmpShowInfo", emp);
		}
    [HttpGet]
		public IActionResult Email() {
				return View("Email");
		}
    [HttpPost]
    public IActionResult Email (EmailModel email) {
      if (!ModelState.IsValid) {
        return View("Email", email);
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
    [HttpGet]
		public IActionResult Banner() {
				return View("Banner");
		}
    [HttpPost]
		public IActionResult ChangeBanner () {
      if (HttpContext.Request.Form.Files != null) {
        var fileName = string.Empty;
        var files = HttpContext.Request.Form.Files;
        foreach (var file in files) {
          if (file.Length > 0) {
            fileName = Path.Combine(_env.WebRootPath, "images" + $@"/headerAdmin.png");
            using (FileStream fs = System.IO.File.Create(fileName)) {
              file.CopyTo(fs);
              fs.Flush();
            }
            break;
          }
        }
      }
			return RedirectToAction("Banner");
		}
  }
}
