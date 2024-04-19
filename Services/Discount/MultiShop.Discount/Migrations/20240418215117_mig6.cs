using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Discount.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Validate",
                table: "Coupons",
                newName: "ValidDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValidDate",
                table: "Coupons",
                newName: "Validate");
        }
    }
}
