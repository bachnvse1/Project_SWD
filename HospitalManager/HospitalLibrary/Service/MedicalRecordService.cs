using HospitalLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Service
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly DBContext _context;
        public MedicalRecordService()
        {
            _context = new DBContext(); 
        }
        public void AddMedicalRecord(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Add(medicalRecord);
            _context.SaveChanges();
        }

        public void UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Update(medicalRecord);
            _context.SaveChanges();
        }
        public MedicalRecord GetMedicalRecordByPatientId(int id)
        {
            return _context.MedicalRecords.FirstOrDefault(m => m.MedicalRecordId == id);
        }
    }
}
