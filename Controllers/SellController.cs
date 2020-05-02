using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ExerciseWebDevelopment.Models;

namespace ExerciseWebDevelopment.Controllers {
  public class SellController : Controller {
    public AppDb Db { get; }
    public SellController (AppDb db) {
      Db = db;
    }
    [HttpGet]
    public async Task<IActionResult> Index () {
      await Db.Connection.OpenAsync();
      StockModelRequest stockModelRequest = new StockModelRequest(Db);
      StockModel stockModel = await stockModelRequest.FindOneAsync("Fan1");
      await Db.Connection.CloseAsync();
      if (stockModel == null) {
        return NotFound();
      }
      return View(stockModel);
    }
  }
}