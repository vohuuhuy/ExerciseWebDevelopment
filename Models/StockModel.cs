using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace ExerciseWebDevelopment.Models {
  public class StockModel {
    [Key]
    [Display(Name = "Mã Mẫu Hàng")]
    [StringLength(10)]
    public string ma { get; set; }
    [Key]
    [Display(Name = "Tên Mẫu Hàng")]
    [StringLength(10)]
    public string ten { get; set; }
    internal AppDb Db { get; set; }
    public StockModel () {}
    public StockModel (AppDb db) {
      Db = db;
    }

    public async Task InsertAsync() {
      using var cmd = Db.Connection.CreateCommand();
      cmd.CommandText = @"INSERT INTO `MauHang` (`ma`, `ten`) VALUES (@ma, @ten)";
      BindCode(cmd);
      BindParam(cmd);
      await cmd.ExecuteNonQueryAsync();
    }
    public async Task UpdateAsync() {
      using var cmd = Db.Connection.CreateCommand();
      cmd.CommandText = @"UPDATE `MauHang` SET `ten` = @name WHERE `ma` = @ma;";
      BindCode(cmd);
      BindParam(cmd);
      await cmd.ExecuteNonQueryAsync();
    }
    public async Task DeleteAsync() {
      using var cmd = Db.Connection.CreateCommand();
      cmd.CommandText = @"DELETE FROM `MauHang` WHERE `ma` = @ma;";
      BindCode(cmd);
      await cmd.ExecuteNonQueryAsync();
    }
    private void BindCode (MySqlCommand cmd) {
      cmd.Parameters.Add( new MySqlParameter {
        ParameterName = "@ma",
        DbType = DbType.String,
        Value = ma
      });
    }
    private void BindParam (MySqlCommand cmd) {
      cmd.Parameters.Add( new MySqlParameter {
        ParameterName = "@ten",
        DbType = DbType.String,
        Value = ten
      });
    }
  }
}