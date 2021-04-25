using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CBA.Models.ViewModels.UserViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required, MinLength(6)]
        [RegularExpression(@"^[ a-zA-Z0-9]+$", ErrorMessage = "Username should contain only letters and numbers"), MaxLength(40)]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please enter your Firstname")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Firstname should contain only letters"), MaxLength(40)]
        [Display(Name  = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Lastname")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Lastname should contain only letters"), MaxLength(40)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address"), MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid Phone number"), MinLength(11), MaxLength(16)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select a role")]
        [Display(Name = "Role")]
        public int RoleID { get; set; }
    }
}
