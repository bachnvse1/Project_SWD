using HospitalLibrary.DataAccess;
using HospitalLibrary.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Controllers
{
    public class HospitalManagerController : Controller
    {
        private readonly DBContext _context;
        private IWorkscheduleService _workscheduleService;
        private IPatientService _petientService;

        public HospitalManagerController(DBContext context, IWorkscheduleService workscheduleService, IPatientService patientService)
        {
            _context = context;
            _workscheduleService = workscheduleService;
            _petientService = patientService;
        }

        public IActionResult Index()
        {
            var workSchedules = _workscheduleService.GetAllWorkSchedules();
            ViewBag.WorkSchedules = workSchedules;
            var listPatient = _petientService.GetAllPatients().Where(x => x.RoomId == null);
            ViewBag.Patients = listPatient;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int scheduleId, DateTime timeSlot, int? patientId, int? userId)
        {
            if (ModelState.IsValid)
            {

                var workSchedule = new WorkSchedule
                {
                    ScheduleId = scheduleId,
                    TimeSlot = timeSlot,
                    PatientId = patientId,
                    UserId = userId,
                    UpdateBy = 1,
                    UpdateAt = DateTime.Now
                };


                var result = _workscheduleService.UpdateWorkSchedule(workSchedule);

                if (result)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "Update failed." });
                }
            }

            return Json(new { success = false, message = "Invalid data." });
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

    }
}
