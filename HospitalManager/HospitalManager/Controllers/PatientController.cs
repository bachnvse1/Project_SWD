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
        public class PatientDetailViewModel
        {
            public Patient Patient { get; set; }
            public MedicalRecord MedicalRecord { get; set; }
        }
        public PatientController(DBContext context, IPatientService patientServices, IMedicalRecordService medicalRecordService)
        {
            _context = context;
            _patientServices = patientServices;
            _medicalRecordService = medicalRecordService;
        }
        public IActionResult Index()
        {
            var patient = _context.Patients.ToList();
            ViewBag.Patients = patient;
            return View();
        }
        public IActionResult PatientDetail(int id)
        {
            var patient = _patientServices.getPatientByID(id);
            if (patient == null) return NotFound();

            var medicalRecord = _medicalRecordService.g(id) ?? new MedicalRecord { PatientId = id, Detail = "" };

            var viewModel = new PatientDetailViewModel
            {
                Patient = patient,
                MedicalRecord = medicalRecord
            };

            return View(viewModel);
        }

        public IActionResult addMedicalRecord(int patientID)
        {
            var medicalRecord = new MedicalRecord
            {
                PatientId = patientID
            };
            return View(medicalRecord); 
        }
        public IActionResult AddMedicalRecord(MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                // Add record to the database
                _medicalRecordService.AddMedicalRecord(medicalRecord);
                return RedirectToAction("PatientDetail", new { id = medicalRecord.PatientId });
            }
            return View(medicalRecord);
        }

        
    }
}
