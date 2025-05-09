﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class adDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HinhThucThiDaus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucThiDaus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThanhViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoCCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdt = table.Column<int>(type: "int", nullable: true),
                    LinkAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaiTros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaiTros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViTris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenViTri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiaiDaus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGiaiDau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNguoiLienHe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    SoNguoiTrenSan = table.Column<int>(type: "int", nullable: false),
                    IsAuToSetup = table.Column<bool>(type: "bit", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    SoDoi = table.Column<int>(type: "int", nullable: false),
                    HinhThucThiDauId = table.Column<int>(type: "int", nullable: true),
                    SoDoiVaoVongTrong = table.Column<int>(type: "int", nullable: false),
                    DiemThang = table.Column<int>(type: "int", nullable: false),
                    DiemHoa = table.Column<int>(type: "int", nullable: false),
                    DiemThua = table.Column<int>(type: "int", nullable: false),
                    SoBangDau = table.Column<int>(type: "int", nullable: false),
                    SoVongDau = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThaiTuyChinh = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaiDaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaiDaus_HinhThucThiDaus_HinhThucThiDauId",
                        column: x => x.HinhThucThiDauId,
                        principalTable: "HinhThucThiDaus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BangDaus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBangDau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaiDauId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangDaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BangDaus_GiaiDaus_GiaiDauId",
                        column: x => x.GiaiDauId,
                        principalTable: "GiaiDaus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoiDaus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDoiDau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkAvatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNguoiLienHe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<int>(type: "int", nullable: true),
                    NgayThanhLap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GiaiDauId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoiDaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoiDaus_GiaiDaus_GiaiDauId",
                        column: x => x.GiaiDauId,
                        principalTable: "GiaiDaus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VongDaus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVongDau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDoi = table.Column<int>(type: "int", nullable: false),
                    LoaiVong = table.Column<int>(type: "int", nullable: false),
                    GiaiDauId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VongDaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VongDaus_GiaiDaus_GiaiDauId",
                        column: x => x.GiaiDauId,
                        principalTable: "GiaiDaus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GiaiDauBangDaus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BangDauId = table.Column<int>(type: "int", nullable: true),
                    GiaiDauId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaiDauBangDaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaiDauBangDaus_BangDaus_BangDauId",
                        column: x => x.BangDauId,
                        principalTable: "BangDaus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiaiDauBangDaus_GiaiDaus_GiaiDauId",
                        column: x => x.GiaiDauId,
                        principalTable: "GiaiDaus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ThanhVienGiaiDaus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThiDau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoAo = table.Column<int>(type: "int", nullable: false),
                    ThanhVienId = table.Column<int>(type: "int", nullable: true),
                    GiaiDauId = table.Column<int>(type: "int", nullable: true),
                    DoiDauId = table.Column<int>(type: "int", nullable: true),
                    ViTriId = table.Column<int>(type: "int", nullable: true),
                    VaiTroId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhVienGiaiDaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhVienGiaiDaus_DoiDaus_DoiDauId",
                        column: x => x.DoiDauId,
                        principalTable: "DoiDaus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThanhVienGiaiDaus_GiaiDaus_GiaiDauId",
                        column: x => x.GiaiDauId,
                        principalTable: "GiaiDaus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThanhVienGiaiDaus_ThanhViens_ThanhVienId",
                        column: x => x.ThanhVienId,
                        principalTable: "ThanhViens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThanhVienGiaiDaus_VaiTros_VaiTroId",
                        column: x => x.VaiTroId,
                        principalTable: "VaiTros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ThanhVienGiaiDaus_ViTris_ViTriId",
                        column: x => x.ViTriId,
                        principalTable: "ViTris",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GiaiDauVongDaus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VongDauId = table.Column<int>(type: "int", nullable: true),
                    GiaiDauId = table.Column<int>(type: "int", nullable: true),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false),
                    IsKnockout = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaiDauVongDaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaiDauVongDaus_GiaiDaus_GiaiDauId",
                        column: x => x.GiaiDauId,
                        principalTable: "GiaiDaus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiaiDauVongDaus_VongDaus_VongDauId",
                        column: x => x.VongDauId,
                        principalTable: "VongDaus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GiaiDauVongDauChiTiets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVongDau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaiDauVongDauId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaiDauVongDauChiTiets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaiDauVongDauChiTiets_GiaiDauVongDaus_GiaiDauVongDauId",
                        column: x => x.GiaiDauVongDauId,
                        principalTable: "GiaiDauVongDaus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TranDaus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vong = table.Column<int>(type: "int", nullable: true),
                    GiaiDauId = table.Column<int>(type: "int", nullable: true),
                    GiaiDauBangDauId = table.Column<int>(type: "int", nullable: true),
                    GiaiDauVongDauChiTietId = table.Column<int>(type: "int", nullable: true),
                    DoiDauNhaId = table.Column<int>(type: "int", nullable: true),
                    DoiDauKhachId = table.Column<int>(type: "int", nullable: true),
                    DoiDauThangId = table.Column<int>(type: "int", nullable: true),
                    SoBanGhiDoiNha = table.Column<int>(type: "int", nullable: true),
                    SoBanGhiDoiKhach = table.Column<int>(type: "int", nullable: true),
                    LinkBienBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsLuotVe = table.Column<bool>(type: "bit", nullable: false),
                    TrangThaiTuyChinh = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranDaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranDaus_DoiDaus_DoiDauKhachId",
                        column: x => x.DoiDauKhachId,
                        principalTable: "DoiDaus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TranDaus_DoiDaus_DoiDauNhaId",
                        column: x => x.DoiDauNhaId,
                        principalTable: "DoiDaus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TranDaus_DoiDaus_DoiDauThangId",
                        column: x => x.DoiDauThangId,
                        principalTable: "DoiDaus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TranDaus_GiaiDauBangDaus_GiaiDauBangDauId",
                        column: x => x.GiaiDauBangDauId,
                        principalTable: "GiaiDauBangDaus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TranDaus_GiaiDauVongDauChiTiets_GiaiDauVongDauChiTietId",
                        column: x => x.GiaiDauVongDauChiTietId,
                        principalTable: "GiaiDauVongDauChiTiets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TranDaus_GiaiDaus_GiaiDauId",
                        column: x => x.GiaiDauId,
                        principalTable: "GiaiDaus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TranDauGhiBans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TranDauId = table.Column<int>(type: "int", nullable: true),
                    ThanhVienGiaiDauId = table.Column<int>(type: "int", nullable: true),
                    ThoiGianGhiBan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranDauGhiBans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranDauGhiBans_ThanhVienGiaiDaus_ThanhVienGiaiDauId",
                        column: x => x.ThanhVienGiaiDauId,
                        principalTable: "ThanhVienGiaiDaus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TranDauGhiBans_TranDaus_TranDauId",
                        column: x => x.TranDauId,
                        principalTable: "TranDaus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TranDauThePhats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TranDauId = table.Column<int>(type: "int", nullable: true),
                    ThanhVienGiaiDauId = table.Column<int>(type: "int", nullable: true),
                    IsTheDo = table.Column<bool>(type: "bit", nullable: false),
                    IsTheVang = table.Column<bool>(type: "bit", nullable: false),
                    ThoiGianPhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranDauThePhats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranDauThePhats_ThanhVienGiaiDaus_ThanhVienGiaiDauId",
                        column: x => x.ThanhVienGiaiDauId,
                        principalTable: "ThanhVienGiaiDaus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TranDauThePhats_TranDaus_TranDauId",
                        column: x => x.TranDauId,
                        principalTable: "TranDaus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BangDaus_GiaiDauId",
                table: "BangDaus",
                column: "GiaiDauId");

            migrationBuilder.CreateIndex(
                name: "IX_DoiDaus_GiaiDauId",
                table: "DoiDaus",
                column: "GiaiDauId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaiDauBangDaus_BangDauId",
                table: "GiaiDauBangDaus",
                column: "BangDauId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaiDauBangDaus_GiaiDauId",
                table: "GiaiDauBangDaus",
                column: "GiaiDauId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaiDaus_HinhThucThiDauId",
                table: "GiaiDaus",
                column: "HinhThucThiDauId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaiDauVongDauChiTiets_GiaiDauVongDauId",
                table: "GiaiDauVongDauChiTiets",
                column: "GiaiDauVongDauId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaiDauVongDaus_GiaiDauId",
                table: "GiaiDauVongDaus",
                column: "GiaiDauId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaiDauVongDaus_VongDauId",
                table: "GiaiDauVongDaus",
                column: "VongDauId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienGiaiDaus_DoiDauId",
                table: "ThanhVienGiaiDaus",
                column: "DoiDauId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienGiaiDaus_GiaiDauId",
                table: "ThanhVienGiaiDaus",
                column: "GiaiDauId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienGiaiDaus_ThanhVienId",
                table: "ThanhVienGiaiDaus",
                column: "ThanhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienGiaiDaus_VaiTroId",
                table: "ThanhVienGiaiDaus",
                column: "VaiTroId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienGiaiDaus_ViTriId",
                table: "ThanhVienGiaiDaus",
                column: "ViTriId");

            migrationBuilder.CreateIndex(
                name: "IX_TranDauGhiBans_ThanhVienGiaiDauId",
                table: "TranDauGhiBans",
                column: "ThanhVienGiaiDauId");

            migrationBuilder.CreateIndex(
                name: "IX_TranDauGhiBans_TranDauId",
                table: "TranDauGhiBans",
                column: "TranDauId");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_DoiDauKhachId",
                table: "TranDaus",
                column: "DoiDauKhachId");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_DoiDauNhaId",
                table: "TranDaus",
                column: "DoiDauNhaId");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_DoiDauThangId",
                table: "TranDaus",
                column: "DoiDauThangId");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_GiaiDauBangDauId",
                table: "TranDaus",
                column: "GiaiDauBangDauId");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_GiaiDauId",
                table: "TranDaus",
                column: "GiaiDauId");

            migrationBuilder.CreateIndex(
                name: "IX_TranDaus_GiaiDauVongDauChiTietId",
                table: "TranDaus",
                column: "GiaiDauVongDauChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_TranDauThePhats_ThanhVienGiaiDauId",
                table: "TranDauThePhats",
                column: "ThanhVienGiaiDauId");

            migrationBuilder.CreateIndex(
                name: "IX_TranDauThePhats_TranDauId",
                table: "TranDauThePhats",
                column: "TranDauId");

            migrationBuilder.CreateIndex(
                name: "IX_VongDaus_GiaiDauId",
                table: "VongDaus",
                column: "GiaiDauId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TranDauGhiBans");

            migrationBuilder.DropTable(
                name: "TranDauThePhats");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ThanhVienGiaiDaus");

            migrationBuilder.DropTable(
                name: "TranDaus");

            migrationBuilder.DropTable(
                name: "ThanhViens");

            migrationBuilder.DropTable(
                name: "VaiTros");

            migrationBuilder.DropTable(
                name: "ViTris");

            migrationBuilder.DropTable(
                name: "DoiDaus");

            migrationBuilder.DropTable(
                name: "GiaiDauBangDaus");

            migrationBuilder.DropTable(
                name: "GiaiDauVongDauChiTiets");

            migrationBuilder.DropTable(
                name: "BangDaus");

            migrationBuilder.DropTable(
                name: "GiaiDauVongDaus");

            migrationBuilder.DropTable(
                name: "VongDaus");

            migrationBuilder.DropTable(
                name: "GiaiDaus");

            migrationBuilder.DropTable(
                name: "HinhThucThiDaus");
        }
    }
}
