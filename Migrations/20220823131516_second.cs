using Microsoft.EntityFrameworkCore.Migrations;

namespace EChallan1.Web.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challans_Customers_Customerid",
                table: "Challans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "ChallanDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChallanDetails",
                table: "ChallanDetails",
                column: "Customerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Challans_ChallanDetails_Customerid",
                table: "Challans",
                column: "Customerid",
                principalTable: "ChallanDetails",
                principalColumn: "Customerid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challans_ChallanDetails_Customerid",
                table: "Challans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChallanDetails",
                table: "ChallanDetails");

            migrationBuilder.RenameTable(
                name: "ChallanDetails",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Customerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Challans_Customers_Customerid",
                table: "Challans",
                column: "Customerid",
                principalTable: "Customers",
                principalColumn: "Customerid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
