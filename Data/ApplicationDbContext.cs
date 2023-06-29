using QuanLyBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace QuanLyBookStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<QuanLyBookStore.Models.NhanVien> NhanVien { get; set; } = default!;
        public DbSet<QuanLyBookStore.Models.HopDong> HopDong { get; set; } = default!;
        public DbSet<QuanLyBookStore.Models.Sach> Sach { get; set; } = default!;
        public DbSet<QuanLyBookStore.Models.DonMua> DonMua { get; set; } = default!;

    }
}