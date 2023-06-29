using System.ComponentModel.DataAnnotations;
namespace QuanLyBookStore.Models
{
    public class Sach
    {
        [Key]
        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Mã sách")]
        public string MaSach {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Tên sách")]
        public string TenSach {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Tên NXB")]
        public string TenNXB {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Giá")]
        public string Gia {get; set;}
    }
}