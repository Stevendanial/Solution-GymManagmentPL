using GymManagmentBLL.Services.Interface;
using GymManagmentBLL.ViewModels.PlanViewModels;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repository.Interfaces;

//using GymManagmentDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Classes
{
    internal class PlanService : IPlanService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<PlanViewModel> GetAllPlans()
        {
            var planRepo = _unitOfWork.GetRepository<Plan>();
            var plans = planRepo.GetAll();

            if (plans == null || !plans.Any())
                return [];

            return plans.Select(x => new PlanViewModel()
            {
                Id = x.Id,
                Description = x.Description,
                Duration = x.DurationDays,
                Name = x.Name,
                IsActive = x.IsActive,
                Price = x.Price
            });
        }

        public PlanViewModel? GetPlanDetails(int planId)
        {
            var planRepo = _unitOfWork.GetRepository<Plan>();
            var plan = planRepo.GetById(planId);
            if (plan == null) return null;

            return new PlanViewModel
            {
                Id = plan.Id,
                Description = plan.Description,
                Duration = plan.DurationDays,
                Name = plan.Name,
                IsActive = plan.IsActive,
                Price = plan.Price
            };
        }

        public UpdatePlanViewModel? GetPlanToUpdate(int planId)
        {
            var planRepo = _unitOfWork.GetRepository<Plan>();
            var plan = planRepo.GetById(planId);

            if (plan == null) return null;

         
            if (plan.IsActive || HasActiveMemberships(planId))
                return null;

            return new UpdatePlanViewModel
            {
                Description = plan.Description,
                DurationDay = plan.DurationDays,
                PlanName = plan.Name,
                Price = plan.Price
            };
        }

        public bool ToggleStatus(int planId)
        {
            try
            {
                var planRepo = _unitOfWork.GetRepository<Plan>();
                var plan = planRepo.GetById(planId);
                if (plan == null) return false;

               
                plan.IsActive = !plan.IsActive;

                
                if (!plan.IsActive && HasActiveMemberships(planId))
                {
                    
                    return false;
                }

                planRepo.Update(plan);
                return _unitOfWork.SaveChange() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePlan(int planId, UpdatePlanViewModel updatedPlan)
        {
            try
            {
                var planRepo = _unitOfWork.GetRepository<Plan>();
                var plan = planRepo.GetById(planId);

                if (plan == null|| HasActiveMemberships(planId)) return false;



                (plan.Description, plan.Price, plan.DurationDays, plan.UpdatedAt) =
                    (updatedPlan.Description, updatedPlan.Price, updatedPlan.DurationDay, DateTime.Now);
                  
               

                planRepo.Update(plan);

                return _unitOfWork.SaveChange() > 0;
            }
            catch
            {
                return false;
            }
        }



        #region helper
        private bool HasActiveMemberships(int planId) {

            return _unitOfWork.GetRepository<MemberShip>().GetAll(x => x.planID == planId && x.Status == "Active").Any();
        }

        #endregion
    }
}
