using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagementSystem.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Applications_Approvals_Loan_Applications_LoanApplicationId",
                table: "Loan_Applications_Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Applications_Approvals_Loan_Types_LoanId",
                table: "Loan_Applications_Approvals");

            migrationBuilder.DropIndex(
                name: "IX_Loan_Applications_Approvals_LoanId",
                table: "Loan_Applications_Approvals");

            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "Loan_Applications_Approvals");

            migrationBuilder.AlterColumn<int>(
                name: "LoanApplicationId",
                table: "Loan_Applications_Approvals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Applications_Approvals_Loan_Applications_LoanApplicationId",
                table: "Loan_Applications_Approvals",
                column: "LoanApplicationId",
                principalTable: "Loan_Applications",
                principalColumn: "LoanApplicationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Applications_Approvals_Loan_Applications_LoanApplicationId",
                table: "Loan_Applications_Approvals");

            migrationBuilder.AlterColumn<int>(
                name: "LoanApplicationId",
                table: "Loan_Applications_Approvals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "LoanId",
                table: "Loan_Applications_Approvals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Loan_Applications_Approvals_LoanId",
                table: "Loan_Applications_Approvals",
                column: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Applications_Approvals_Loan_Applications_LoanApplicationId",
                table: "Loan_Applications_Approvals",
                column: "LoanApplicationId",
                principalTable: "Loan_Applications",
                principalColumn: "LoanApplicationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Applications_Approvals_Loan_Types_LoanId",
                table: "Loan_Applications_Approvals",
                column: "LoanId",
                principalTable: "Loan_Types",
                principalColumn: "LoanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
