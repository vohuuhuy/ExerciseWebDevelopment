using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
      List<StockModel> listStockModel = await stockModelRequest.FindAllAsync();
      await Db.Connection.CloseAsync();
      if (listStockModel.Count <= 0) {
        return NotFound();
      }
      return View(listStockModel);
    }
  }
}