using System;
using Microsoft.AspNetCore.Mvc;
using ExerciseWebDevelopment.Models;

namespace ExerciseWebDevelopment.Controllers {
	public class CalculatorController : Controller {
		[HttpGet]
		public IActionResult Index () {
			return View();
		}
		[HttpPost]
		public IActionResult Result (Calculator calculator) {
			switch (calculator.calculation) {
				case "+":
					ViewBag.Result = calculator.a + calculator.b;
					break;
				case "-":
					ViewBag.Result = calculator.a -calculator.b;
					break;
				case "*":
					ViewBag.Result = calculator.a * calculator.b;
					break;
				case "/":
					if (calculator.b == 0) ViewBag.Result = "Không chia được cho 0";
					else ViewBag.Result = calculator.a / calculator.b;
				break;
			}
			return View("Index");
		}
	}
}