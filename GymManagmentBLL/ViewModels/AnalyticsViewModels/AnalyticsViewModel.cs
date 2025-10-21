using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.AnalyticsViewModels
{
    public class AnalyticsViewModel
    {
        public int TotalMembers { get; set; }
        public int ActiveMembers { get; set; }
        public int TotalTrainer { get; set; }
        public int UpComingSession { get; set; }
        public int OngoningSession { get; set; }
        public int CompletedSession { get; set; }


    }
}
