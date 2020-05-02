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
    public async Task<StockModel> FindOneAsync (string code) {
      using var cmd = Db.Connection.CreateCommand();
      cmd.CommandText = @"SELECT `code`, `name`, `unit`, `price`, `codeTypeStock` FROM `UD2` WHERE `code` = @code;";
      cmd.Parameters.Add(new MySqlParameter {
        ParameterName = "@code",
        DbType = DbType.String,
        Value = code
      });
      var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
      return result.Count > 0 ? result[0] : null;
    }
    public async Task<List<StockModel>> FindAllAsync () {
      using var cmd = Db.Connection.CreateCommand();
      cmd.CommandText = @"Select `code`, name, `unit`, `price`, `codeTypeStock` FROM `UD2`;";
      var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
      return result.Count > 0 ? result : null;
    }
    private async Task<List<StockModel>> ReadAllAsync (DbDataReader reader) {
      var stockModels = new List<StockModel>();
      using (reader) {
        while (await reader.ReadAsync()) {
          var item = new StockModel(Db) {
            code = reader.GetString(0),
            name = reader.GetString(1),
            unit = reader.GetString(2),
            price = reader.GetDouble(3),
            codeTypeStock = reader.GetString(4)
          };
          stockModels.Add(item);
        }
      }
      return stockModels;
    }
  }
}