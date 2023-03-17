using System.ComponentModel.DataAnnotations;

namespace Advanced_Database_and_ORM_Concepts_Lab03.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(25, ErrorMessage = "Must be betweeen 3 and 25 characters", MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(25, ErrorMessage = "Must be betweeen 3 and 25 characters", MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Invalid phone number format. Use ###-###-####.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
