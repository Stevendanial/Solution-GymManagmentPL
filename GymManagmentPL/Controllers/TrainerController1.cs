using GymManagmentBLL.Services.Classes;
using GymManagmentBLL.Services.Interface;
using GymManagmentBLL.ViewModels.MemberViewModels;
using GymManagmentBLL.ViewModels.TrainerViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentPL.Controllers
{
    public class TrainerController1 : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainerController1(ITrainerService TrainerService)
        {
            _trainerService = TrainerService;
        }


        #region Get all Trainers
        public ActionResult Index()
        {
            var Trainers = _trainerService.GetAllTrainers();
            return View(Trainers);
        }
        #endregion

        #region  create Trainer
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createTrainer(CreateTrainerViewModels createTrainer)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("dataInvalid", "check data and missing fields.");
                return View(nameof(create), createTrainer);
            }
            bool Result = _trainerService.CreateTrainer(createTrainer);
            if (Result)
            {
                TempData["SuccessMessage"] = "Trainer created successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to create Trainer.";
            }
            return RedirectToAction(nameof(Index));

        }

        #endregion


        #region Get Trainer Data
        public ActionResult TrainerDetails(int id)
        {
            if (id <= 0)
                return RedirectToAction(nameof(Index));
            var trainer = _trainerService.GetTrainerDetails(id);

            if (trainer == null)
                return RedirectToAction(nameof(Index));


            return View(trainer);
        }

        #endregion


        #region updateTrainer

        public ActionResult TrainerEdit(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id cannot be zero or negative";
                return View(nameof(Index));
            }
            var trainer = _trainerService.GetTrainerToUpdate(id);
            if (trainer is null)
            {
                TempData["ErrorMessage"] = " member is ot found";

            }

            return View(trainer);

        }

        [HttpPost]
        public ActionResult TrainerEdit([FromRoute] int id, TrainerToUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                return View(viewModel);
            }
            var Result = _trainerService.UpdateTrainerDetails(viewModel, id);
            if (Result)
            {
                TempData["SuccessMessage"] = "trainer update successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update trainer";
            }
            return RedirectToAction(nameof(Index));


        }

        #endregion



        #region Delete Member
        public ActionResult DeleteTrainer(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id cannot be zero or negative";
                return RedirectToAction(nameof(Index));
            }
            var Result = _trainerService.GetTrainerDetails(id);
            if (Result is null)
            {

                TempData["ErrorMessage"] = "Failed to delete member.";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.memberId = id;
            return View(Result);
        }
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {

            var Result = _trainerService.RemoveTrainer(id);
            if (Result)
            {
                TempData["SuccessMessage"] = "trainer delete successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete Trainer";
            }
            return RedirectToAction(nameof(Index));
        }


        #endregion

    }
}
