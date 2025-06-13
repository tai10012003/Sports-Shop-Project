﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_thuong_hieu = table.Column<string>(type: "varchar(8)", nullable: false),
                    ten_thuong_hieu = table.Column<string>(type: "varchar(50)", nullable: false),
                    mo_ta = table.Column<string>(type: "text", nullable: true),
                    logo = table.Column<string>(type: "varchar(255)", nullable: true),
                    website = table.Column<string>(type: "varchar(100)", nullable: true),
                    thu_tu = table.Column<int>(type: "int", nullable: false),
                    trang_thai = table.Column<bool>(type: "bit", nullable: false),
                    slug = table.Column<string>(type: "varchar(255)", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.UniqueConstraint("AK_Brands_ma_thuong_hieu", x => x.ma_thuong_hieu);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_danh_muc = table.Column<string>(type: "varchar(8)", nullable: false),
                    ten_danh_muc = table.Column<string>(type: "varchar(50)", nullable: false),
                    mo_ta = table.Column<string>(type: "text", nullable: true),
                    hinh_anh = table.Column<string>(type: "varchar(255)", nullable: true),
                    danh_muc_cha = table.Column<int>(type: "int", nullable: true),
                    thu_tu = table.Column<int>(type: "int", nullable: false),
                    trang_thai = table.Column<bool>(type: "bit", nullable: false),
                    slug = table.Column<string>(type: "varchar(255)", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.UniqueConstraint("AK_Categories_ma_danh_muc", x => x.ma_danh_muc);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_san_pham = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ten_san_pham = table.Column<string>(type: "varchar(255)", nullable: false),
                    mo_ta = table.Column<string>(type: "text", nullable: true),
                    mo_ta_chi_tiet = table.Column<string>(type: "text", nullable: true),
                    kich_thuoc = table.Column<string>(type: "varchar(50)", nullable: true),
                    mau_sac = table.Column<string>(type: "varchar(50)", nullable: true),
                    chat_lieu = table.Column<string>(type: "varchar(100)", nullable: true),
                    xuat_xu = table.Column<string>(type: "varchar(100)", nullable: true),
                    bao_hanh = table.Column<string>(type: "varchar(50)", nullable: true),
                    gia = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    gia_khuyen_mai = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    so_luong = table.Column<int>(type: "int", nullable: false),
                    ma_danh_muc = table.Column<string>(type: "varchar(8)", nullable: false),
                    ma_thuong_hieu = table.Column<string>(type: "varchar(8)", nullable: false),
                    tinh_trang = table.Column<bool>(type: "bit", nullable: false),
                    noi_bat = table.Column<bool>(type: "bit", nullable: false),
                    luot_xem = table.Column<int>(type: "int", nullable: false),
                    slug = table.Column<string>(type: "varchar(255)", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.UniqueConstraint("AK_Products_ma_san_pham", x => x.ma_san_pham);
                    table.ForeignKey(
                        name: "FK_Products_Brands_ma_thuong_hieu",
                        column: x => x.ma_thuong_hieu,
                        principalTable: "Brands",
                        principalColumn: "ma_thuong_hieu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_ma_danh_muc",
                        column: x => x.ma_danh_muc,
                        principalTable: "Categories",
                        principalColumn: "ma_danh_muc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_san_pham = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    duong_dan = table.Column<string>(type: "varchar(255)", nullable: false),
                    thu_tu = table.Column<int>(type: "int", nullable: false),
                    anh_chinh = table.Column<bool>(type: "bit", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ma_san_pham",
                        column: x => x.ma_san_pham,
                        principalTable: "Products",
                        principalColumn: "ma_san_pham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ma_san_pham",
                table: "ProductImages",
                column: "ma_san_pham");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ma_danh_muc",
                table: "Products",
                column: "ma_danh_muc");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ma_thuong_hieu",
                table: "Products",
                column: "ma_thuong_hieu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
