using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagementSystem.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loan_Applications",
                columns: table => new
                {
                    LoanApplicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationHolderName = table.Column<string>(maxLength: 50, nullable: false),
                    IfscCode = table.Column<string>(maxLength: 20, nullable: false),
                    LoanAmount = table.Column<int>(nullable: false),
                    LoanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan_Applications", x => x.LoanApplicationId);
                    table.ForeignKey(
                        name: "FK_Loan_Applications_Loan_Types_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan_Types",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loan_Applications_LoanId",
                table: "Loan_Applications",
                column: "LoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loan_Applications");
        }
    }
}
