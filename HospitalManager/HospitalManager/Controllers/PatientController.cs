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
        


    }
}
