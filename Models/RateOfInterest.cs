using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LoanManagementSystem.Models
{
    [Table(name: "Rate_Of_Interests")]
    public class RateOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int RateOfInterestId { get; set; }

        [Required]
        [Display(Name = "Interest % (under 1 Lakh)")]
        virtual public int LoanAmount1 { get; set; }

        [Required]
        [Display(Name = "Interest % (between 1 Lakh to 10 Lakhs)")]
        virtual public int LoanAmount2 { get; set; }

        #region Navigation Properties to the Loan Type Model
        virtual public int LoanId { get; set; }

        [ForeignKey(nameof(RateOfInterest.LoanId))]
        public LoanType LoanType { get; set; }

        #endregion
    }
}

