using Microsoft.EntityFrameworkCore.Migrations;

namespace implementacija.Migrations
{
    public partial class izmjena2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FizickoLiceId",
                table: "VIP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FizickoLiceId",
                table: "VIP",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
