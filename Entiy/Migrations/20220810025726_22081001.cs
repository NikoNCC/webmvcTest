using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entiy.Migrations
{
    public partial class _22081001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "DepartmentInfo",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "varchar(36)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(32)", nullable: true),
            //        DepartmentName = table.Column<string>(type: "nvarchar(16)", nullable: true),
            //        LeaderId = table.Column<string>(type: "nvarchar(36)", nullable: true),
            //        ParentId = table.Column<string>(type: "nvarchar(36)", nullable: true),
            //        CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        IsDelete = table.Column<bool>(type: "bit", nullable: false),
            //        DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DepartmentInfo", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "RoleInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    RoleName = table.Column<string>(type: "varchar(16)", nullable: true),
                    Description = table.Column<string>(type: "varchar(32)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleInfo", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "UserInfo",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "varchar(36)", nullable: false),
            //        Account = table.Column<string>(type: "varchar(16)", nullable: true),
            //        UserName = table.Column<string>(type: "nvarchar(16)", nullable: true),
            //        PhoneNum = table.Column<string>(type: "varchar(16)", nullable: true),
            //        Email = table.Column<string>(type: "varchar(32)", nullable: true),
            //        DepartmentId = table.Column<string>(type: "varchar(36)", nullable: true),
            //        Sex = table.Column<int>(type: "int", nullable: false),
            //        PassWord = table.Column<string>(type: "varchar(32)", nullable: true),
            //        IsAdmin = table.Column<bool>(type: "bit", nullable: false),
            //        CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        IsDelete = table.Column<bool>(type: "bit", nullable: false),
            //        DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserInfo", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentInfo");

            migrationBuilder.DropTable(
                name: "RoleInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
