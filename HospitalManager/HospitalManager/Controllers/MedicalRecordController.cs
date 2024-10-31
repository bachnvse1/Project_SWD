using HospitalLibrary.DataAccess;
using HospitalLibrary.Service;
using Microsoft.AspNetCore.Mvc;



namespace HospitalManager.Controllers
{
    public class MedicalRecordController
    {
        private readonly DBContext _context;
        private IMedicalRecordService _MedicalRecordService;
        public MedicalRecordController(DBContext context, IMedicalRecordService medicalRecordService)
        {
            _context = context;
            _MedicalRecordService = medicalRecordService;
        }
    }
}
