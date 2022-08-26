using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public enum MyIdentityRoleNames
    {

        [Display(Name = "Admin Role")]
        AppAdmin,

        [Display(Name = "User Role")]
        AppUser

    }
}
