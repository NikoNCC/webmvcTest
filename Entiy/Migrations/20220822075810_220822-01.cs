using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entiy.Migrations
{
    public partial class _22082201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    ConsumableName = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    CategoryId = table.Column<string>(type: "varchar(36)", nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    Num = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WarningNum = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableRecord",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    ConsumableId = table.Column<string>(type: "varchar(36)", nullable: true),
                    Num = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableRecord", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "MenuInfo",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "varchar(36)", nullable: false),
            //        Title = table.Column<string>(type: "varchar(16)", nullable: true),
            //        Description = table.Column<string>(type: "varchar(32)", nullable: true),
            //        Level = table.Column<int>(type: "int", nullable: false),
            //        Sort = table.Column<int>(type: "int", nullable: false),
            //        Href = table.Column<string>(type: "varchar(128)", nullable: true),
            //        ParentId = table.Column<string>(type: "varchar(36)", nullable: true),
            //        Icon = table.Column<string>(type: "varchar(32)", nullable: true),
            //        Target = table.Column<string>(type: "varchar(32)", nullable: true),
            //        CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        IsDelete = table.Column<bool>(type: "bit", nullable: false),
            //        DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MenuInfo", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ConsumableInfo");

            migrationBuilder.DropTable(
                name: "ConsumableRecord");

            //migrationBuilder.DropTable(
            //    name: "MenuInfo");
        }
    }
}
