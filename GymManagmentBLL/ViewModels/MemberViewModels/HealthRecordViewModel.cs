using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.MemberViewModels
{
    public class HealthRecordViewModel
    {
        [Required(ErrorMessage ="Height is required")]
        [Range (0.1,300,ErrorMessage ="Height must be between 0.1 and 300 ")]
        public decimal Weight { get; set; }
        [Required(ErrorMessage = "Weight is required")]
        [Range(0.1, 500, ErrorMessage = "Weight must be between 0.1 and 500 ")]
        public decimal Height { get; set; }
        
        [Required(ErrorMessage = "Blood Type is required")]
        [RegularExpression(@"^(A|B|AB|O)[+-]$", ErrorMessage = "Blood Type must be A+, A-, B+, B-, AB+, AB-, O+ or O-")]
        [StringLength(3,ErrorMessage = "Blood Type must be A+, A-, B+, B-, AB+, AB-, O+ or O-")]
        public string BloodType { get; set; } = null!;

    }
}
