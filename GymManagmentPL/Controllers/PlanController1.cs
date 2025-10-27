using GymManagmentBLL.Services.Classes;
using GymManagmentBLL.Services.Interface;
using GymManagmentBLL.ViewModels.PlanViewModels;
using GymManagmentDAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentPL.Controllers
{
    public class PlanController1 : Controller
    {
        private readonly IPlanService _planService;

        //Index
        public PlanController1(IPlanService planService)
        {
            _planService = planService;
        }

        #region Index
        public ActionResult Index()
        {
            var Plans = _planService.GetAllPlans();
            return View(Plans);
        }
        #endregion

        #region Details
        public ActionResult Details(int id)
        {

            if (id <= 0)
            {
                TempData["ErrorMessage"] = "id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }
            var plan = _planService.GetPlanDetails(id);
            if (plan == null)
            {
                TempData["ErrorMessage"] = "Plan not found";
                return RedirectToAction(nameof(Index));
            }
            return View(plan);

        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Invalid id";
                return RedirectToAction(nameof(Index));
            }
            var plans = _planService.GetPlanToUpdate(id);

            if (plans is null)
            {
                TempData["ErrorMessage"] = "plan can not be update";
                return RedirectToAction(nameof(Index));
            }
            return View(plans);
        }

        [HttpPost]
        public ActionResult Edit([FromRoute]int id,UpdatePlanViewModel updatePlan)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("WrongData", "Check data View.");
                return View(updatePlan);
            }
            var Result = _planService.UpdatePlan( id,updatePlan);
            if (Result)
            {
                TempData["SuccessMessage"] = "Plan update successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update Plan";
            }
            return RedirectToAction(nameof(Index));

        }

        #endregion

        #region Delete Action
        public ActionResult Activate(int id)
        {
          
            var Result = _planService.ToggleStatus(id);
            if (Result)
            {
                TempData["SuccessMessage"] = "Plan status change successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to change Plan";
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion


    }
}
