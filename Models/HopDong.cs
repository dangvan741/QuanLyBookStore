using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBookStore.Models
{
    public class HopDong
    {
        [Key]
        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Mã hợp đồng")]
        public string MaHD {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Tên nhân viên")]
        public string TenNV {get; set;}
        [ForeignKey("TenNV")]
        public NhanVien? NhanVien {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Ngày bắt đầu")]
        public string DateStart {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Ngày kết thúc")]
        public string DateEnd {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Lương")]
        public string Luong {get; set;}
        
    }
}