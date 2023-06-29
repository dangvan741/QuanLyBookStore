using System.ComponentModel.DataAnnotations;
namespace QuanLyBookStore.Models
{
    public class NhanVien
    {
        [Key]
        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Mã nhân viên")]
        public string MaNV {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Tên nhân viên")]
        public string TenNV {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Ngày sinh")]
        public string NgaySinh {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Quê quán")]
        public string Quequan {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Số điện thoại")]
        public string SDT {get; set;}
    }
}