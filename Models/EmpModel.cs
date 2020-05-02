using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseWebDevelopment.Models {
  public class EmpModel {
    [Key]
    [Required(ErrorMessage = "Mã số nhân viên là bắt buộc")]
    [Display(Name = "Mã số nhân viên")]
    [StringLength(10)]
    public string EmpID { get; set; }
    [Display(Name = "Họ tên")]
    [Required(ErrorMessage = "Họ tên là bắt buộc")]
    public string Name { get; set; }
    [Display(Name = "Ngày sinh")]
    public DateTime BirthOfDate { get; set; }
    [Display(Name = "Email")]
    public string Email { get; set; }
    [Display(Name = "Mật khẩu")]
    public string Password { get; set; }
    [Display(Name = "Đơn vị")]
    public string Department { get; set; }
    public string Avatar { get; set; }
  }
}