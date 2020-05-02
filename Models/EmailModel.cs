using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseWebDevelopment.Models {
  public class EmailModel {
    [Key]
    [Display(Name = "Gửi từ email")]
    [Required(ErrorMessage = "Địa chỉ người gửi là bắt buộc")]
    [EmailAddress(ErrorMessage = "Nên là định dạnh email ví dụ: vohuuhuy@gmail.com")]
    public string srcEmail { get; set; }
    [Display(Name = "Mật khẩu")]
    [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
    public string Password { get; set; }
    [Display(Name = "Gửi đến email")]
    [Required(ErrorMessage = "Địa chỉ gửi đến là bắt buộc")]
    [EmailAddress(ErrorMessage = "Nên là định dạnh email ví dụ: vohuuhuy@gmail.com")]
    public string desEmail { get; set; }
    [Display(Name = "Tiêu đề")]
    public string title { get; set; }
    [Display(Name = "Nội dung")]
    public string content { get; set; }
  }
}