using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagementSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loan_Types",
                columns: table => new
                {
                    LoanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanTypeName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Details = table.Column<string>(type: "varchar(500)", nullable: false),
                    LoanGivenTo = table.Column<string>(nullable: false),
                    NumberOfGuaranters = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan_Types", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "Rate_Of_Interests",
                columns: table => new
                {
                    RateOfInterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmount1 = table.Column<int>(nullable: false),
                    LoanAmount2 = table.Column<int>(nullable: false),
                    LoanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate_Of_Interests", x => x.RateOfInterestId);
                    table.ForeignKey(
                        name: "FK_Rate_Of_Interests_Loan_Types_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan_Types",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rate_Of_Interests_LoanId",
                table: "Rate_Of_Interests",
                column: "LoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rate_Of_Interests");

            migrationBuilder.DropTable(
                name: "Loan_Types");
        }
    }
}
