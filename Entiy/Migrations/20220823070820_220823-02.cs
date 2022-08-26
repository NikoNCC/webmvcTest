using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entiy.Migrations
{
    public partial class _22082302 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "WorkFlow_Instance");

            migrationBuilder.DropTable(
                name: "WorkFlow_InstanceStep");

            migrationBuilder.DropTable(
                name: "WorkFlow_Model");
        }
    }
}
