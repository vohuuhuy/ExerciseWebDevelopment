using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ExerciseWebDevelopment.Models {
  public class StockModelRequest {
    public AppDb Db { get; }
    public StockModelRequest (AppDb db) {
      Db = db;
    }
    public async Task<StockModel> FindOneAsync (string ma) {
      using var cmd = Db.Connection.CreateCommand();
      cmd.CommandText = @"SELECT `ma`, `ten` FROM `MauHang` WHERE `ma` = @ma;";
      cmd.Parameters.Add(new MySqlParameter {
        ParameterName = "@ma",
        DbType = DbType.String,
        Value = ma
      });
      var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
      return result.Count > 0 ? result[0] : null;
    }
    public async Task<List<StockModel>> FindAllAsync () {
      using var cmd = Db.Connection.CreateCommand();
      cmd.CommandText = @"Select `ma`, `ten` FROM `MauHang`;";
      var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
      return result.Count > 0 ? result : null;
    }
    private async Task<List<StockModel>> ReadAllAsync (DbDataReader reader) {
      var stockModels = new List<StockModel>();
      using (reader) {
        while (await reader.ReadAsync()) {
          var item = new StockModel(Db) {
            ma = reader.GetString(0),
            ten = reader.GetString(1),
          };
          stockModels.Add(item);
        }
      }
      return stockModels;
    }
  }
}