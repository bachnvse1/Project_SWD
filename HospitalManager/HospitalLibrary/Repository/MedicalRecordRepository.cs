using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.DataAccess;

namespace HospitalLibrary.Repository
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly DBContext _context;
        public MedicalRecordRepository()
        {
            _context = new DBContext(); 
        }
        public MedicalRecord GetMedicalRecordByPatientID(int patientID)
        {
            return _context.MedicalRecords.FirstOrDefault(x => x.PatientId == patientID);
        }
        public void AddMedicalRecord(MedicalRecord record)
        {
            _context.MedicalRecords.Add(record);
            _context.SaveChanges();
        }
        public void UpdateMedicalRecord(MedicalRecord record)
        {
            _context.MedicalRecords.Update(record);
            _context.SaveChanges(); 
        }
    }
}
