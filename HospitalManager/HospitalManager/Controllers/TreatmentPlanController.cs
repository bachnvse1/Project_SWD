using HospitalLibrary.DataAccess;
using HospitalLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Controllers
{
    public class TreatmentPlanController : Controller
    {
       
        private IPatientService _patientService;
        private ITreatmentPlanService _treatmentPlanService;

        public TreatmentPlanController( ITreatmentPlanService treatmentPlanService, IPatientService patientService)
        {
            _treatmentPlanService = treatmentPlanService;
            _patientService = patientService;
        }
        public IActionResult Index()
        {
            ViewBag.patients = _patientService.GetAllPatientsWithTreatmentPlans();
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Diagnosis, string MedicineSection, string TreatmentMethodSection, string DoctorInCharge, DateTime StartDate, DateTime EndDate, int PatientId,DateTime TreatmentTime)
        {
            TreatmentPlan treatmentPlan = new TreatmentPlan() { 
                MedicineSection = MedicineSection,
                TreatmentMethodSection = TreatmentMethodSection,
                PatientId = PatientId,
                DoctorInCharge = DoctorInCharge,
                StartDate = StartDate,
                EndDate = EndDate,
                TreatmentTime = TreatmentTime,
                Diagnosis = Diagnosis

            };
            _treatmentPlanService.AddTreatmentPlan(treatmentPlan);
            return RedirectToAction("Index", "TreatmentPlan");

        }

    }
}
