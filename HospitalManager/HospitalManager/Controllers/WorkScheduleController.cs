using HospitalLibrary.DataAccess;
using HospitalLibrary.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Controllers
{
    public class WorkScheduleController : Controller
    {
        private readonly DBContext _context;
        private IWorkscheduleService _workscheduleService;

        public WorkScheduleController(DBContext context, IWorkscheduleService workscheduleService)
        {
            _context = context;
            _workscheduleService = workscheduleService;
        }

        public IActionResult Index()
        {
            var workSchedules = _context.WorkSchedules.ToList();
            ViewBag.WorkSchedules = workSchedules;
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

    }
}
