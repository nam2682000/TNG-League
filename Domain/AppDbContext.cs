using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Domain;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<BangDau> BangDaus { get; set; }
    public DbSet<DoiBong> DoiBongs { get; set; }
    public DbSet<GiaiDau> GiaiDaus { get; set; }
    public DbSet<GiaiDauBangDau> GiaiDauBangDaus { get; set; }
    public DbSet<GiaiDauVongDau> GiaiDauVongDaus { get; set; }
    public DbSet<HinhThucThiDau> HinhThucThiDaus { get; set; }
    public DbSet<ThanhVien> ThanhViens { get; set; }
    public DbSet<ThanhVienGiaiDau> ThanhVienGiaiDaus { get; set; }
    public DbSet<TranDau> TranDaus { get; set; }
    public DbSet<TranDauGhiBan> TranDauGhis { get; set; }
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
        base.OnModelCreating(modelBuilder);

        // Giữ Cascade delete cho mối quan hệ với GiaiDau
        modelBuilder.Entity<ThanhVienGiaiDau>()
            .HasOne(x => x.GiaiDau)
            .WithMany()
            .HasForeignKey(x => x.GiaiDauId)
            .OnDelete(DeleteBehavior.SetNull);  // Cascade delete khi xóa GiaiDau

        // SetNull khi xóa ThanhVien (sẽ NULL hóa ThanhVienId trong ThanhVienGiaiDau)
        modelBuilder.Entity<ThanhVienGiaiDau>()
            .HasOne(x => x.ThanhVien)
            .WithMany()
            .HasForeignKey(x => x.ThanhVienId)
            .OnDelete(DeleteBehavior.SetNull);  // SetNull khi xóa ThanhVien

        // SetNull khi xóa DoiBong (sẽ NULL hóa DoiBongId trong ThanhVienGiaiDau)
        modelBuilder.Entity<ThanhVienGiaiDau>()
            .HasOne(x => x.DoiBongs)
            .WithMany()
            .HasForeignKey(x => x.DoiBongId)
            .OnDelete(DeleteBehavior.SetNull);  // SetNull khi xóa DoiBong
    }
}