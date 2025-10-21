using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.PlanViewModels
{
    internal class UpdatePlanViewModel
    {
        [Required(ErrorMessage = "PlanName is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "PlanName must be between  50 and 2 characters")]
        public string PlanName { get; set; } = null!;

        [Required(ErrorMessage = "Description is Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Description must be between  50 and 2 characters")]

        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "DurationDay is Required")]
        [Range(1, 356, ErrorMessage = "Duration Days between 1 and 356")]
        public int DurationDay { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        [Range(0.1, 10000, ErrorMessage = "Price between 0.1 and 10000")]
        public decimal Price { get; set; }

    }
}
