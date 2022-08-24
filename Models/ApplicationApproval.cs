using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoanManagementSystem.Models
{
    [Table(name: "Loan_Applications_Approvals")]
    public class ApplicationApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApprovalId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(10)]
        [Display(Name = "Loan Application Status")]
        public string ApplicationStatus { get; set; }

        #region Navigation Properties to the Loan Application Model
        virtual public int LoanApplicationId { get; set; }

        [ForeignKey(nameof(ApplicationApproval.LoanApplicationId))]
        public LoanApplication LoanApplication { get; set; }

        #endregion

    }
}
