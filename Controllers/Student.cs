using Microsoft.AspNetCore.Mvc;
using ExerciseWebDevelopment.Models;

namespace ExerciseWebDevelopment.Controllers {
	public class StudentController : Controller {
		[HttpGet]
		public IActionResult UseModel () {
			return View();
		}
		[HttpPost]
		public IActionResult UseModel (Student student) {
			return View("ShowUseModel", student);
		}
		[HttpGet]
		public IActionResult UseArguments () {
			return View();
		}
		[HttpPost]
		public IActionResult UseArguments (string ma, string hoTen, double diem) {
			ViewData["ma"] = ma;
			ViewData["hoTen"] = hoTen;
			ViewData["diem"] = diem;
			return View("ShowUseArguments");
		}
	}
}