using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.PlanViewModels
{
    internal class PlanViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int Duration { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
    }
}
