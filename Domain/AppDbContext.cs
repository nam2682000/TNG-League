using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Domain;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<BangDau> BangDaus { get; set; }
    public DbSet<DoiDau> DoiDaus { get; set; }
    public DbSet<GiaiDau> GiaiDaus { get; set; }
    public DbSet<GiaiDauBangDau> GiaiDauBangDaus { get; set; }
    public DbSet<GiaiDauVongDau> GiaiDauVongDaus { get; set; }
    public DbSet<GiaiDauVongDauChiTiet> GiaiDauVongDauChiTiets { get; set; }
    public DbSet<HinhThucThiDau> HinhThucThiDaus { get; set; }
    public DbSet<ThanhVien> ThanhViens { get; set; }
    public DbSet<ThanhVienGiaiDau> ThanhVienGiaiDaus { get; set; }
    public DbSet<TranDau> TranDaus { get; set; }
    public DbSet<TranDauGhiBan> TranDauGhiBans { get; set; }
    public DbSet<TranDauThePhat> TranDauThePhats { get; set; }
    public DbSet<VaiTro> VaiTros { get; set; }
    public DbSet<ViTri> ViTris { get; set; }
    public DbSet<VongDau> VongDaus { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    //optionsBuilder.UseLazyLoadingProxies(); // Enable lazy loading
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TranDau>()
            .HasOne(t => t.DoiDauNha)
            .WithMany(d => d.TranDauNha)
            .HasForeignKey(t => t.DoiDauNhaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TranDau>()
            .HasOne(t => t.DoiDauKhach)
            .WithMany(d => d.TranDauKhach)
            .HasForeignKey(t => t.DoiDauKhachId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TranDau>()
            .HasOne(t => t.DoiDauThang)
            .WithMany(d => d.TranDauThang)
            .HasForeignKey(t => t.DoiDauThangId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
        
        //// Giữ Cascade delete cho mối quan hệ với GiaiDau
        //modelBuilder.Entity<ThanhVienGiaiDau>()
        //    .HasOne(x => x.GiaiDau)
        //    .WithMany()
        //    .HasForeignKey(x => x.GiaiDauId)
        //    .OnDelete(DeleteBehavior.SetNull);  // Cascade delete khi xóa GiaiDau

        //// SetNull khi xóa ThanhVien (sẽ NULL hóa ThanhVienId trong ThanhVienGiaiDau)
        //modelBuilder.Entity<ThanhVienGiaiDau>()
        //    .HasOne(x => x.ThanhVien)
        //    .WithMany()
        //    .HasForeignKey(x => x.ThanhVienId)
        //    .OnDelete(DeleteBehavior.SetNull);  // SetNull khi xóa ThanhVien

        //// SetNull khi xóa DoiDau (sẽ NULL hóa DoiDauId trong ThanhVienGiaiDau)
        //modelBuilder.Entity<ThanhVienGiaiDau>()
        //    .HasOne(x => x.DoiDaus)
        //    .WithMany()
        //    .HasForeignKey(x => x.DoiDauId)
        //    .OnDelete(DeleteBehavior.SetNull);  // SetNull khi xóa DoiDau
    }
}