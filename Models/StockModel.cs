using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ExerciseWebDevelopment.Models {
  public class StockModel {
    public string code { get; set; }
    public string name { get; set; }
    public string unit { get; set; }
    public double price { get; set; }
    public string codeTypeStock { get; set; }
    internal AppDb Db { get; set; }
    public StockModel () {}
    public StockModel (AppDb db) {
      Db = db;
    }

    public async Task InsertAsync() {
      using var cmd = Db.Connection.CreateCommand();
      cmd.CommandText = @"INSERT INTO `UD2` (`code`, `name`, `unit`, `price`, `codeTypeStock`) VALUES (@code, @name, @unit, @price, @codeTypeStock)";
      BindCode(cmd);
      BindParam(cmd);
      await cmd.ExecuteNonQueryAsync();
    }
    public async Task UpdateAsync() {
      using var cmd = Db.Connection.CreateCommand();
      cmd.CommandText = @"UPDATE `Stock` SET `name` = @name, `unit` = @unit, `price` = @price, `codeTypeStock` = @codeTypeStock WHERE `code` = @code;";
      BindCode(cmd);
      BindParam(cmd);
      await cmd.ExecuteNonQueryAsync();
    }
    public async Task DeleteAsync() {
      using var cmd = Db.Connection.CreateCommand();
      cmd.CommandText = @"DELETE FROM `Stock` WHERE `code` = @code;";
      BindCode(cmd);
      await cmd.ExecuteNonQueryAsync();
    }
    private void BindCode (MySqlCommand cmd) {
      cmd.Parameters.Add( new MySqlParameter {
        ParameterName = "@code",
        DbType = DbType.String,
        Value = code
      });
    }
    private void BindParam (MySqlCommand cmd) {
      cmd.Parameters.Add( new MySqlParameter {
        ParameterName = "@name",
        DbType = DbType.String,
        Value = name
      });
      cmd.Parameters.Add( new MySqlParameter {
        ParameterName = "@unit",
        DbType = DbType.String,
        Value = unit
      });
      cmd.Parameters.Add( new MySqlParameter {
        ParameterName = "@price",
        DbType = DbType.Double,
        Value = price
      });
      cmd.Parameters.Add( new MySqlParameter {
        ParameterName = "@codeTypeStock",
        DbType = DbType.String,
        Value = codeTypeStock
      });
    }
  }
}