using GymManagmentBLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnalyticsService _analyticsService;

        public HomeController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }
        public ActionResult Index() { 
        var data =_analyticsService.GetAnalyticsData();
            return View(data);
        }
    }
}
