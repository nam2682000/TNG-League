using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TngLeague.Domain.Entities;
namespace TngLeague.Domain;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
    public DbSet<ThanhVien> ThanhViens { get; set; }
    public DbSet<ThanhVienGiaiDau> ThanhVienGiaiDaus { get; set; }
    public DbSet<VaiTro> VaiTros { get; set; }
    public DbSet<ViTri> ViTris { get; set; }
    public DbSet<DoiBong> DoiBongs { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseLazyLoadingProxies(); // Enable lazy loading
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<ThanhVien>()
        //    .HasMany(s => s.DoiBongs)
        //    .WithMany(c => c.CauThus)
        //    .UsingEntity(j => j.ToTable("CauThuDoiBong"));
    }
}