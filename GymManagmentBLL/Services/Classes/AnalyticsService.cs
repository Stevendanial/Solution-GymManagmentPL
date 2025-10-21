//using GymManagmentBLL.Services.Interface;
using GymManagmentBLL.Services.Interface;
using GymManagmentBLL.ViewModels.AnalyticsViewModels;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Classes
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnalyticsService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
     
        AnalyticsViewModel IAnalyticsService.GetAnalyticsData()
        {
            var sessions = _unitOfWork.sessionRepository.GetAll();
            return new AnalyticsViewModel()
            {
                ActiveMembers = _unitOfWork.GetRepository<MemberShip>().GetAll(x => x.Status == "Active").Count(),
                TotalMembers = _unitOfWork.GetRepository <Member>().GetAll().Count(),
                TotalTrainer = _unitOfWork.GetRepository<Trainer>().GetAll().Count(),
                UpComingSession = sessions.Count(x => x.StartTime > DateTime.Now),
                OngoningSession = sessions.Count(x => x.StartTime <= DateTime.Now && x.EndTime > DateTime.Now),
                CompletedSession = sessions.Count(x => x.EndTime < DateTime.Now),


            };

        }
    }
}
