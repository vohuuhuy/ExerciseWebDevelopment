using Microsoft.AspNetCore.Mvc;
using ExerciseWebDevelopment.Models;

namespace ExerciseWebDevelopment.Controllers {
	public class CalculatorController : Controller {
		[HttpGet]
		public IActionResult UseModel () {
			return View();
		}
		[HttpPost]
		public IActionResult UseModel (Calculator calculator) {
			switch (calculator.calculation) {
				case "+":
					ViewData["Result"] = calculator.a + calculator.b;
					break;
				case "-":
					ViewData["Result"] = calculator.a - calculator.b;
					break;
				case "*":
					ViewData["Result"] = calculator.a * calculator.b;
					break;
				case "/":
					if (calculator.b == 0) ViewData["Result"] = "Không chia được cho 0";
					else ViewData["Result"] = calculator.a / calculator.b;
				break;
			}
			return View();
		}
		[HttpGet]
		public IActionResult UseArguments () {
			return View();
		}
		[HttpPost]
		public IActionResult UseArguments (double a, double b, string pt = "+") {
			switch (pt) {
				case "+":
					ViewData["Result"] = a + b;
					break;
				case "-":
					ViewData["Result"] = a - b;
					break;
				case "*":
					ViewData["Result"] = a * b;
					break;
				case "/":
					if (b == 0) ViewData["Result"] = "Không chia được cho 0";
					else ViewData["Result"] = a / b;
				break;
			}
			return View();
		}
	}
}