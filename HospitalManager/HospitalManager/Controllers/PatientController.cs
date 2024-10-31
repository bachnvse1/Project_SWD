using HospitalLibrary.DataAccess;
using HospitalLibrary.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Controllers
{
    public class PatientController : Controller
    {
        private readonly DBContext _context;
        private IPatientService _patientServices;
        private IMedicalRecordService _medicalRecordService;
        private IRoomService _roomService;
        public class PatientDetailViewModel
        {
            public Patient Patient { get; set; }
            public MedicalRecord MedicalRecord { get; set; }
        }
        public PatientController(DBContext context, IPatientService patientServices, IMedicalRecordService medicalRecordService, IRoomService roomService)
        {
            _context = context;
            _patientServices = patientServices;
            _medicalRecordService = medicalRecordService;
            _roomService = roomService;
        }
        public IActionResult Index()
        {
            var patient = _context.Patients.ToList();
            ViewBag.Patients = patient;
            return View();
        }
        public IActionResult PatientDetail(int id)
        {
            var patient = _patientServices.GetPatientById(id);
            if (patient == null) return NotFound();

            var medicalRecord = _medicalRecordService.GetMedicalRecordByPatientID(id) ?? new MedicalRecord { PatientId = id, Detail = "" };

            var viewModel = new PatientDetailViewModel
            {
                Patient = patient,
                MedicalRecord = medicalRecord
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateHospitalAdmission(
            string patientName,
            DateTime? dateOfBirth,
            string? gender,
            string? phone,
            int? roomId,
            string? healthInsurance,
            string? healthCondition,
            int createdBy)
        {
            if (ModelState.IsValid)
            {
                var patient = new Patient
                {
                    PatientId = _patientServices.GetAllPatients().Select(p => p.PatientId).Max() + 1,
                    PatientName = patientName,
                    DateOfBirth = dateOfBirth,
                    Gender = gender,
                    Phone = phone,
                    RoomId = roomId,
                    HealthInsurance = healthInsurance,
                    HealthCondition = healthCondition,
                    CreatedBy = createdBy,
                    CreatedAt = DateTime.Now,
                    IsDelete = false
                };

                _patientServices.CreateHospitalAdmissionProcedure(patient);
                return RedirectToAction("Index1"); // Redirect to the patient list after creation
            }

            return View(); // Re-display the form if there are validation errors
        }

        // Display all patients  
        public IActionResult GetAllPatients()
        {
            IEnumerable<Patient> patients = _patientServices.GetAllPatients();
            return View(patients);
        }

        public IActionResult Index1()
        {
            var patients = _patientServices.GetAllPatients();
            ViewBag.patients = patients;
            ViewBag.rooms = _roomService.GetAllRooms().Where(x => x.IsAvailable == true).ToList();
            return View();
        }
    }
}
