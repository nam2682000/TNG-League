﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250415042309_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.DoiBong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GiaiDauId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LinkAnhDoi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayThanhLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenDoiBong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GiaiDauId");

                    b.ToTable("DoiBongs");
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.BangDau", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GiaiDauId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("TenBangDau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GiaiDauId");

                    b.ToTable("BangDaus");
                });

            modelBuilder.Entity("Domain.Entities.GiaiDauBangDau", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BangDauId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GiaiDauId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BangDauId");

                    b.HasIndex("GiaiDauId");

                    b.ToTable("GiaiDauBangDaus");
                });

            modelBuilder.Entity("Domain.Entities.GiaiDauVongDau", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GiaiDauId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsKnockout")
                        .HasColumnType("bit");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VongDauId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GiaiDauId");

                    b.HasIndex("VongDauId");

                    b.ToTable("GiaiDauVongDaus");
                });

            modelBuilder.Entity("Domain.Entities.HinhThucThiDau", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Mota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHinhThuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("HinhThucThiDaus");
                });

            modelBuilder.Entity("Domain.Entities.ThanhVienGiaiDau", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DoiBongId")
                        .HasColumnType("int");

                    b.Property<int?>("DoiBongId1")
                        .HasColumnType("int");

                    b.Property<int?>("GiaiDauId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("SoAo")
                        .HasColumnType("int");

                    b.Property<string>("TenThiDau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThanhVienId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoiBongId");

                    b.HasIndex("DoiBongId1");

                    b.HasIndex("GiaiDauId");

                    b.HasIndex("ThanhVienId");

                    b.ToTable("ThanhVienGiaiDaus");
                });

            modelBuilder.Entity("Domain.Entities.TranDau", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiaDiem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DoiBong1Id")
                        .HasColumnType("int");

                    b.Property<int?>("DoiBong2Id")
                        .HasColumnType("int");

                    b.Property<int?>("DoiBongThangId")
                        .HasColumnType("int");

                    b.Property<int?>("GiaiDauBangDauId")
                        .HasColumnType("int");

                    b.Property<int?>("GiaiDauId")
                        .HasColumnType("int");

                    b.Property<int?>("GiaiDauVongDauId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLuotVe")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TrangThaiTuyChinh")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoiBong1Id");

                    b.HasIndex("DoiBong2Id");

                    b.HasIndex("DoiBongThangId");

                    b.HasIndex("GiaiDauBangDauId");

                    b.HasIndex("GiaiDauId");

                    b.HasIndex("GiaiDauVongDauId");

                    b.ToTable("TranDaus");
                });

            modelBuilder.Entity("Domain.Entities.TranDauGhiBan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("ThanhVienGiaiDauId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianGhiBan")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TranDauId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ThanhVienGiaiDauId");

                    b.HasIndex("TranDauId");

                    b.ToTable("TranDauGhis");
                });

            modelBuilder.Entity("Domain.Entities.TranDauThePhat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTheDo")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTheVang")
                        .HasColumnType("bit");

                    b.Property<int?>("ThanhVienGiaiDauId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianPhat")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TranDauId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ThanhVienGiaiDauId");

                    b.HasIndex("TranDauId");

                    b.ToTable("TranDauThePhats");
                });

            modelBuilder.Entity("Domain.Entities.VaiTro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Mota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenVaiTro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("VaiTros");
                });

            modelBuilder.Entity("Domain.Entities.ViTri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenViTri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ViTris");
                });

            modelBuilder.Entity("Domain.Entities.VongDau", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GiaiDauId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("SoDoi")
                        .HasColumnType("int");

                    b.Property<string>("TenVongDau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GiaiDauId");

                    b.ToTable("VongDaus");
                });

            modelBuilder.Entity("Domain.GiaiDau", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MuaGiai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenGiaiDau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrangThaiTuyChinh")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("GiaiDaus");
                });

            modelBuilder.Entity("Domain.ThanhVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<int>("Sdt")
                        .HasColumnType("int");

                    b.Property<string>("SoCCCD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ThanhViens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.DoiBong", b =>
                {
                    b.HasOne("Domain.GiaiDau", "GiaiDau")
                        .WithMany("DoiBongs")
                        .HasForeignKey("GiaiDauId");

                    b.Navigation("GiaiDau");
                });

            modelBuilder.Entity("Domain.Entities.BangDau", b =>
                {
                    b.HasOne("Domain.GiaiDau", null)
                        .WithMany("BangDaus")
                        .HasForeignKey("GiaiDauId");
                });

            modelBuilder.Entity("Domain.Entities.GiaiDauBangDau", b =>
                {
                    b.HasOne("Domain.Entities.BangDau", "BangDau")
                        .WithMany()
                        .HasForeignKey("BangDauId");

                    b.HasOne("Domain.GiaiDau", "GiaiDau")
                        .WithMany()
                        .HasForeignKey("GiaiDauId");

                    b.Navigation("BangDau");

                    b.Navigation("GiaiDau");
                });

            modelBuilder.Entity("Domain.Entities.GiaiDauVongDau", b =>
                {
                    b.HasOne("Domain.GiaiDau", "GiaiDau")
                        .WithMany()
                        .HasForeignKey("GiaiDauId");

                    b.HasOne("Domain.Entities.VongDau", "VongDau")
                        .WithMany()
                        .HasForeignKey("VongDauId");

                    b.Navigation("GiaiDau");

                    b.Navigation("VongDau");
                });

            modelBuilder.Entity("Domain.Entities.ThanhVienGiaiDau", b =>
                {
                    b.HasOne("Domain.DoiBong", "DoiBongs")
                        .WithMany()
                        .HasForeignKey("DoiBongId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.DoiBong", null)
                        .WithMany("ThanhVienGiaiDaus")
                        .HasForeignKey("DoiBongId1");

                    b.HasOne("Domain.GiaiDau", "GiaiDau")
                        .WithMany()
                        .HasForeignKey("GiaiDauId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.ThanhVien", "ThanhVien")
                        .WithMany()
                        .HasForeignKey("ThanhVienId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("DoiBongs");

                    b.Navigation("GiaiDau");

                    b.Navigation("ThanhVien");
                });

            modelBuilder.Entity("Domain.Entities.TranDau", b =>
                {
                    b.HasOne("Domain.DoiBong", "DoiBong1")
                        .WithMany()
                        .HasForeignKey("DoiBong1Id");

                    b.HasOne("Domain.DoiBong", "DoiBong2")
                        .WithMany()
                        .HasForeignKey("DoiBong2Id");

                    b.HasOne("Domain.DoiBong", "DoiBongThang")
                        .WithMany()
                        .HasForeignKey("DoiBongThangId");

                    b.HasOne("Domain.Entities.GiaiDauBangDau", "GiaiDauBangDau")
                        .WithMany()
                        .HasForeignKey("GiaiDauBangDauId");

                    b.HasOne("Domain.GiaiDau", "GiaiDau")
                        .WithMany()
                        .HasForeignKey("GiaiDauId");

                    b.HasOne("Domain.Entities.GiaiDauVongDau", "GiaiDauVongDau")
                        .WithMany()
                        .HasForeignKey("GiaiDauVongDauId");

                    b.Navigation("DoiBong1");

                    b.Navigation("DoiBong2");

                    b.Navigation("DoiBongThang");

                    b.Navigation("GiaiDau");

                    b.Navigation("GiaiDauBangDau");

                    b.Navigation("GiaiDauVongDau");
                });

            modelBuilder.Entity("Domain.Entities.TranDauGhiBan", b =>
                {
                    b.HasOne("Domain.Entities.ThanhVienGiaiDau", "ThanhVienGiaiDau")
                        .WithMany()
                        .HasForeignKey("ThanhVienGiaiDauId");

                    b.HasOne("Domain.Entities.TranDau", "TranDau")
                        .WithMany("TranDauGhiBans")
                        .HasForeignKey("TranDauId");

                    b.Navigation("ThanhVienGiaiDau");

                    b.Navigation("TranDau");
                });

            modelBuilder.Entity("Domain.Entities.TranDauThePhat", b =>
                {
                    b.HasOne("Domain.Entities.ThanhVienGiaiDau", "ThanhVienGiaiDau")
                        .WithMany()
                        .HasForeignKey("ThanhVienGiaiDauId");

                    b.HasOne("Domain.Entities.TranDau", "TranDau")
                        .WithMany("TranDauThePhats")
                        .HasForeignKey("TranDauId");

                    b.Navigation("ThanhVienGiaiDau");

                    b.Navigation("TranDau");
                });

            modelBuilder.Entity("Domain.Entities.VongDau", b =>
                {
                    b.HasOne("Domain.GiaiDau", null)
                        .WithMany("VongDaus")
                        .HasForeignKey("GiaiDauId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.DoiBong", b =>
                {
                    b.Navigation("ThanhVienGiaiDaus");
                });

            modelBuilder.Entity("Domain.Entities.TranDau", b =>
                {
                    b.Navigation("TranDauGhiBans");

                    b.Navigation("TranDauThePhats");
                });

            modelBuilder.Entity("Domain.GiaiDau", b =>
                {
                    b.Navigation("BangDaus");

                    b.Navigation("DoiBongs");

                    b.Navigation("VongDaus");
                });
#pragma warning restore 612, 618
        }
    }
}
