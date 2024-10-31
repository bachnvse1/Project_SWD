using HospitalLibrary.DataAccess;
using HospitalLibrary.Service;
using Microsoft.AspNetCore.Mvc;



namespace HospitalManager.Controllers
{
    public class MedicalRecordController : Controller
    {
        private readonly DBContext _context;
        private IMedicalRecordService _MedicalRecordService;
        public MedicalRecordController(DBContext context, IMedicalRecordService medicalRecordService)
        {
            _context = context;
            _MedicalRecordService = medicalRecordService;
        }
        [HttpGet]
        public IActionResult CreateMedicalRecord(int patientId)
        {
            ViewData["PatientId"] = patientId;
            return View();
        }

        [HttpPost]
        public IActionResult CreateMedicalRecord(int PatientId, string DetailMedicalRecord)
        {
            if (ModelState.IsValid)
            {
                var medicalMax = _context.MedicalRecords.Select(x => x.MedicalRecordId).Max();
                if(_MedicalRecordService.checkExistMedicalRecord(PatientId)) {
                    MedicalRecord record = new MedicalRecord()
                    {
                        MedicalRecordId = medicalMax + 1,
                        Detail = DetailMedicalRecord,
                        PatientId = PatientId
                    };
                    _MedicalRecordService.AddMedicalRecord(record);
                    return RedirectToAction("patientDetail", "Patient", new { id = record.PatientId });
                }
                   
            }
            return RedirectToAction("patientDetail", "Patient", new { id = PatientId });
        }

        public IActionResult UpdateMedicalRecord(int PatientId, string DetailMedicalRecord)
        {
            if (ModelState.IsValid)
            {
                var medicalRecord = _context.MedicalRecords.FirstOrDefault(x => x.PatientId == PatientId);
                if (medicalRecord != null)
                {
                    medicalRecord.Detail = DetailMedicalRecord;
                    _context.SaveChanges();
                    return RedirectToAction("patientDetail", "Patient", new { id = PatientId });
                }
            }
            return View();
        }
    }
}
