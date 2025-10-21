using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.MemberViewModels
{
    public class MemberToUpdateViewModel
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between  50 and 2 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is Required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Email must be between  100 and 5 characters")]
        [EmailAddress(ErrorMessage = "Invalid Email Formate")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone is Required")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "phone must be Eygpt number")]
        [Phone(ErrorMessage = "Invalid Phone Formate")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "City is Required")]
        [Range(1, 9000, ErrorMessage = "building number must be between 1 and 9000")]
        public int BuildingNumber { get; set; }
        [Required(ErrorMessage = "City is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "City must be between  50 and 2 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string City { get; set; } = null!;
        [Required(ErrorMessage = "Street is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Street must be between  50 and 2 characters")]
        public string Street { get; set; } = null!;

        
        public string photo { get; set; } = null!;
    }
}
