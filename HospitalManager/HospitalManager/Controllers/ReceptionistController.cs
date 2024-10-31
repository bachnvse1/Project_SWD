using HospitalLibrary.DataAccess;
using HospitalLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Controllers
{
    public class ReceptionistController : Controller
    {
        private readonly DBContext _context;
        private IPatientService _patientService;
        private readonly IPaymentService _paymentService;
        public ReceptionistController(DBContext context, IPaymentService paymentService, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
            _paymentService = paymentService;
        }
        public IActionResult Index(string searchTerm)
        {
            var lst = _patientService.SearchPatient(searchTerm);
            return View(lst);
        }
        

        [HttpGet]
        public IActionResult CreateBill(int patientId)
        {
            var patient = _patientService.GetPatientServiceById(patientId);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        public IActionResult CreateBill(Payment payment)
        {
            if (ModelState.IsValid)
            {
                var patient = _patientService.GetPatientServiceById(payment.PatientId);
                if (patient == null)
                {
                    return NotFound();
                }

                payment.Amount = patient.Services.Sum(s => s.ServiceFee) ?? 0;
                _paymentService.CreatePayment(payment);

                _patientService.MarkPatientAsDeleted(payment.PatientId);

                TempData["SuccessMessage"] = "Payment successful for " + patient.PatientName;
                return RedirectToAction("Index");
            }

            return View(payment);
        }
    }



}


