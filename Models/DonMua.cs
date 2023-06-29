using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBookStore.Models
{
    public class DonMua
    {
        [Key]
        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Mã đơn mua")]
        public string MaDM {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Tên khách")]
        public string TenKhach {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Tên sách")]
        public string TenSach {get; set;}
        [ForeignKey("TenSach")]
        public Sach? Sach {get; set;}

        [Required(ErrorMessage ="Không được bỏ trống")]
        [Display(Name ="Ngày mua")]
        public string DateBuy {get; set;}
    }
}