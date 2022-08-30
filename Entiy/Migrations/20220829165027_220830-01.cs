using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entiy.Migrations
{
    public partial class _22083001 : Migration
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
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    LeaderId = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    ParentId = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Title = table.Column<string>(type: "varchar(16)", nullable: true),
                    Description = table.Column<string>(type: "varchar(32)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Href = table.Column<string>(type: "varchar(128)", nullable: true),
                    ParentId = table.Column<string>(type: "varchar(36)", nullable: true),
                    Icon = table.Column<string>(type: "varchar(32)", nullable: true),
                    Target = table.Column<string>(type: "varchar(32)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuInfo", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "R_UserInfo_RoleInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(36)", nullable: true),
                    RoleId = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_UserInfo_RoleInfo", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Account = table.Column<string>(type: "varchar(16)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    PhoneNum = table.Column<string>(type: "varchar(16)", nullable: true),
                    Email = table.Column<string>(type: "varchar(32)", nullable: true),
                    DepartmentId = table.Column<string>(type: "varchar(36)", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    PassWord = table.Column<string>(type: "varchar(32)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlow_Instance",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    ModelId = table.Column<string>(type: "varchar(36)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<string>(type: "varchar(36)", nullable: true),
                    OutNum = table.Column<int>(type: "int", nullable: false),
                    OutGoodsId = table.Column<string>(type: "varchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlow_Instance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlow_InstanceStep",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    InstanceId = table.Column<string>(type: "varchar(36)", nullable: true),
                    ReviewerId = table.Column<string>(type: "varchar(36)", nullable: true),
                    ReviewReason = table.Column<string>(type: "varchar(36)", nullable: true),
                    ReviewStatus = table.Column<int>(type: "int", nullable: false),
                    ReviewTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeforeStepId = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlow_InstanceStep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlow_Model",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Title = table.Column<string>(type: "varchar(36)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(64)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlow_Model", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ConsumableInfo");

            migrationBuilder.DropTable(
                name: "ConsumableRecord");

            migrationBuilder.DropTable(
                name: "DepartmentInfo");

            migrationBuilder.DropTable(
                name: "MenuInfo");

            migrationBuilder.DropTable(
                name: "R_RoleInfo_MenuInfo");

            migrationBuilder.DropTable(
                name: "R_UserInfo_RoleInfo");

            migrationBuilder.DropTable(
                name: "RoleInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "WorkFlow_Instance");

            migrationBuilder.DropTable(
                name: "WorkFlow_InstanceStep");

            migrationBuilder.DropTable(
                name: "WorkFlow_Model");
        }
    }
}
