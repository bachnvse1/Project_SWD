using HospitalLibrary.DataAccess;
using HospitalLibrary.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Controllers
{
    public class HospitalManagerController : Controller
    {
        private readonly DBContext _context;
        private IWorkscheduleService _workscheduleService;

        public HospitalManagerController(DBContext context, IWorkscheduleService workscheduleService)
        {
            _context = context;
            _workscheduleService = workscheduleService;
        }

        public IActionResult Index()
        {
            var workSchedules = _workscheduleService.GetAllWorkSchedules();
            ViewBag.WorkSchedules = workSchedules;
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

    }
}
