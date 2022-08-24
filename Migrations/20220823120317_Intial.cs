using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EChallan1.Web.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customerid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RCNumber = table.Column<string>(nullable: false),
                    CarNumber = table.Column<string>(nullable: false),
                    MobileNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customerid);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    IID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Issues = table.Column<string>(maxLength: 50, nullable: false),
                    IssueDescription = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.IID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentStatus = table.Column<string>(maxLength: 50, nullable: true),
                    MethodEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Challans",
                columns: table => new
                {
                    ChallanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallanNumber = table.Column<string>(nullable: false),
                    ChallanDescription = table.Column<string>(maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fine = table.Column<int>(nullable: false),
                    Customerid = table.Column<int>(nullable: false),
                    IID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challans", x => x.ChallanID);
                    table.ForeignKey(
                        name: "FK_Challans_Customers_Customerid",
                        column: x => x.Customerid,
                        principalTable: "Customers",
                        principalColumn: "Customerid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Challans_Issues_IID",
                        column: x => x.IID,
                        principalTable: "Issues",
                        principalColumn: "IID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChallaDetails",
                columns: table => new
                {
                    CDID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpiId = table.Column<string>(nullable: false),
                    PaymentStatus = table.Column<bool>(nullable: false),
                    CID = table.Column<int>(nullable: false),
                    PID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallaDetails", x => x.CDID);
                    table.ForeignKey(
                        name: "FK_ChallaDetails_Challans_CID",
                        column: x => x.CID,
                        principalTable: "Challans",
                        principalColumn: "ChallanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallaDetails_PaymentMethods_PID",
                        column: x => x.PID,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChallaDetails_CID",
                table: "ChallaDetails",
                column: "CID");

            migrationBuilder.CreateIndex(
                name: "IX_ChallaDetails_PID",
                table: "ChallaDetails",
                column: "PID");

            migrationBuilder.CreateIndex(
                name: "IX_Challans_Customerid",
                table: "Challans",
                column: "Customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Challans_IID",
                table: "Challans",
                column: "IID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChallaDetails");

            migrationBuilder.DropTable(
                name: "Challans");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Issues");
        }
    }
}
