using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoanManagementSystem.Models
{
    [Table(name: "Loan_Applications")]
    public class LoanApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Loan Application Id")]
        public int LoanApplicationId { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Loan Application Holder Name ")]
        public string ApplicationHolderName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [StringLength(20)]
        [Display(Name = "IFSC Code ")]
        public string IfscCode { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Display(Name = "Required Loan Amount ($)")]
        public int LoanAmount { get; set; }
        #region Navigation Properties to the Loan Approvals Model

        public ICollection<ApplicationApproval> ApplicationApprovals { get; set; }

        #endregion

        #region Navigation Properties to the Loan Application Model
        virtual public int LoanId { get; set; }

        [ForeignKey(nameof(LoanApplication.LoanId))]
        public LoanType LoanType { get; set; }

        #endregion

        





    }
}
