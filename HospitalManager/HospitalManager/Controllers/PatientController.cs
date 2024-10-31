using HospitalLibrary.DataAccess;
using HospitalLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HospitalManager.Controllers
{
    public class PatientController : Controller
    {
        private readonly DBContext _context;
        private IPatientService _patientService;
        private IRoomService _roomService;

        public PatientController(DBContext context, IRoomService roomService, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
            _roomService = roomService;
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
                    PatientId = _patientService.GetAllPatients().Select(p => p.PatientId).Max() + 1,
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

                _patientService.CreateHospitalAdmissionProcedure(patient);
                return RedirectToAction("Index1"); // Redirect to the patient list after creation
            }

            return View(); // Re-display the form if there are validation errors
        }

        // Display all patients
        public IActionResult GetAllPatients()
        {
            IEnumerable<Patient> patients = _patientService.GetAllPatients();
            return View(patients);
        }

        public IActionResult Index1()
        {
            var patients = _patientService.GetAllPatients();
            ViewBag.patients = patients;
            ViewBag.rooms = _roomService.GetAllRooms().Where(x=>x.IsAvailable==true).ToList();
            return View();
        }
    }
}
