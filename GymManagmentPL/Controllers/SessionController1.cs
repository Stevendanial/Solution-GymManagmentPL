using GymManagmentBLL.Services.Classes;
using GymManagmentBLL.Services.Interface;
using GymManagmentBLL.ViewModels.SessionViewModels;
using GymManagmentBLL.ViewModels.TrainerViewModel;
using GymManagmentDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymManagmentPL.Controllers
{
    public class SessionController1 : Controller
    {
        private readonly ISessionService _sessionService;

        public SessionController1(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        #region GetAllSessions
        public ActionResult Index()
        {
            var sessions = _sessionService.GetAllSession();
            return View(sessions);
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
            var session = _sessionService.GetSessionById(id);
            if (session == null)
            {
                TempData["ErrorMessage"] = "Plan not found";
                return RedirectToAction(nameof(Index));
            }
            return View(session);
        }
        #endregion


        #region Create

        public ActionResult Create()
        {

            LoadDropDownForCategory();
            LoadDropDownforTrainer();
            return View();
        }
        [HttpPost]

        public ActionResult Create(CreateSessionViewModel createSession)
        {
            if (!ModelState.IsValid)
            {
                LoadDropDownforTrainer();
                LoadDropDownForCategory();
                return View(createSession);
            }
            var Result = _sessionService.CreateSession(createSession);
            if (Result)
            {
                TempData["SuccessMessage"] = "Plan update successfully.";
                 return RedirectToAction(nameof(Index));
            }
            else
            {
                LoadDropDownForCategory();
                LoadDropDownforTrainer();
                TempData["ErrorMessage"] = "Failed to update Plan";
                return View(createSession);
            }
            




        }






        #endregion

        #region Edit Session

        public ActionResult Edit(int id)
        {
            if(id<=0)
            {
               TempData["ErrorMessage"] = "Invalid id";
                return RedirectToAction(nameof(Index));
            }
            var session = _sessionService.UpdateSessionViewModel(id);

            if (session is null)
            {
                TempData["ErrorMessage"] = "plan can not be update";
                return RedirectToAction(nameof(Index));
            }
            LoadDropDownforTrainer();  
            return View(session);
        }

        [HttpPost]
        public ActionResult Edit([FromRoute]int id,UpdateSessionViewModel updateSession)
        {
            if (!ModelState.IsValid)
            {
                LoadDropDownforTrainer();
                return View(updateSession);
            }
            var Result = _sessionService.UpdateSession(id,updateSession);
            if (Result)
            {
                TempData["SuccessMessage"] = "session update successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update session";
            }
            return RedirectToAction(nameof(Index));


        }


        #endregion


        #region Delete
        public ActionResult Delete(int id)
        { if (id<=0)
            {
                TempData["ErrorMessage"] = "Invalid Session Id";
                return RedirectToAction(nameof(Index));
            }
            var Result = _sessionService.GetSessionById(id);
            if (Result is null)
            {
                TempData["ErrorMessage"] = "Session Not Found";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SessionId = Result.Id;
            return View();


        }


        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var result = _sessionService.RemoveSession(id);
            if (result) {

                TempData["sussessMessage"] = "session Delete";
            
            }
            else
            {
                TempData["ErrorMessage"] = "session can not Be Delete";

            }
            return RedirectToAction(nameof(Index)); 
        }


        #endregion


        #region Helper
        private void LoadDropDownForCategory()
        {
            var category = _sessionService.GetCategoryForDropDown();
            ViewBag.Category = new SelectList(category, "Id", "Name");

 
        }

        private void LoadDropDownforTrainer()
        {
            
            var trainer = _sessionService.GetTrainerForDropDown();
            ViewBag.Trainer = new SelectList(trainer, "Id", "Name");
        }


        #endregion


    }

}
