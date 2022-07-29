using Microsoft.EntityFrameworkCore.Migrations;

namespace Entiy.Migrations
{
    public partial class _220727 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IsAdmin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
