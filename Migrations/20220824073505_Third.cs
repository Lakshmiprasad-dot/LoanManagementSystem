using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagementSystem.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loan_Applications_Approvals",
                columns: table => new
                {
                    ApprovalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationStatus = table.Column<string>(maxLength: 10, nullable: false),
                    LoanId = table.Column<int>(nullable: false),
                    LoanApplicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan_Applications_Approvals", x => x.ApprovalId);
                    table.ForeignKey(
                        name: "FK_Loan_Applications_Approvals_Loan_Applications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "Loan_Applications",
                        principalColumn: "LoanApplicationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loan_Applications_Approvals_Loan_Types_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan_Types",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loan_Applications_Approvals_LoanApplicationId",
                table: "Loan_Applications_Approvals",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_Applications_Approvals_LoanId",
                table: "Loan_Applications_Approvals",
                column: "LoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loan_Applications_Approvals");
        }
    }
}
