using GymManagmentBLL.Services.Interface;
using GymManagmentBLL.ViewModels.MemberViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentPL.Controllers
{
    public class MemberController1 : Controller
    { private readonly IMemberService _memberService;
        public MemberController1(IMemberService memberService)
        {
            _memberService = memberService;
        }

       // public IMemberService MemberService { get; }
        #region Get All Members
          public ActionResult Index()
        {
            var members = _memberService.GetAllMember();
            return View(members);
        }

        #endregion


        #region Get Member Data
        public ActionResult MemberDetails(int id)
        {
            if(id<=0)
                return RedirectToAction(nameof(Index));
            var member = _memberService.GetMemberDetails(id);
            
            if(member==null)
                return RedirectToAction(nameof(Index));


            return View(member);
        }




        public ActionResult HealthRecordDetails(int id)
        {

            if (id <= 0)
                return RedirectToAction(nameof(Index));
            var healthRecord = _memberService.GetMemberHealthRecord(id);

            if ( healthRecord== null)
                return RedirectToAction(nameof(Index));

            return View(healthRecord);
        }

        #endregion


        #region  create Member
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createMember(CreateMemberViewModel createMember)
        {
           if(!ModelState.IsValid)
            {
                ModelState.AddModelError("dataInvalid", "check data and missing fields.");
           return View(nameof(create),createMember);
            }
           bool Result= _memberService.CreateMember(createMember);
            if(Result)
            {
               TempData["SuccessMessage"] = "Member created successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to create member.";
            }
            return RedirectToAction(nameof(Index));

        }

        #endregion

        #region updateMember

        public ActionResult MemberEdit(int id)
        {
            if (id<=0)
            {
                TempData["ErrorMessage"] = "Id cannot be zero or negative";
                return View(nameof(Index));
            }
            var member= _memberService.GetMemberForUpdate(id);
            if (member is null)
            { TempData["ErrorMessage"] = " member is ot found";
             
            }
     
            return View(member);

        }

        [HttpPost]
        public ActionResult MemberEdit([FromRoute]int id,MemberToUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                
                return View(viewModel);
            }
            var Result = _memberService.UpdateMemberDetails(id,viewModel);
            if (Result)
            {
                TempData["SuccessMessage"] = "Member update successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update member.";
            }
            return RedirectToAction(nameof(Index));


        }

        #endregion


        #region Delete Member
        public ActionResult DeleteMember(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id cannot be zero or negative";
                return RedirectToAction(nameof(Index));
            }
            var Result = _memberService.GetMemberDetails(id);
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

            var Result = _memberService.RemoveMember(id);
            if (Result)
            {
                TempData["SuccessMessage"] = "Member delete successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete member.";
            }
            return RedirectToAction(nameof(Index));
        }


        #endregion

    }
}
