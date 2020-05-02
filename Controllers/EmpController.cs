using Microsoft.AspNetCore.Mvc;
using ExerciseWebDevelopment.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace ExerciseWebDevelopment.Controllers {
	public class EmpController : Controller {
    private readonly IWebHostEnvironment _env;
    public EmpController (IWebHostEnvironment env) {
      _env = env;
    }
		[HttpGet]
		public IActionResult Index () {
			return View();
		}
		[HttpPost]
		public IActionResult Index (EmpModel emp) {
      if (!ModelState.IsValid) {
        return View("Index", emp);
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
			return View("ShowInfo", emp);
		}
	}
}