using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entiy.Migrations
{
    public partial class _22082202 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "R_RoleInfo_MenuInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    MenuId = table.Column<string>(type: "varchar(36)", nullable: true),
                    RoleId = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_RoleInfo_MenuInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "R_RoleInfo_MenuInfo");
        }
    }
}
