using HospitalLibrary.DataAccess;
using HospitalLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Service
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }
        public MedicalRecord GetMedicalRecordByPatientID(int patientID)
        {
            return _medicalRecordRepository.GetMedicalRecordByPatientID(patientID);
        }
        public void AddMedicalRecord(MedicalRecord record)
        {
            record.CreatedAt = DateTime.Now;
            _medicalRecordRepository.AddMedicalRecord(record);
        }
        public void UpdateMedicalRecord(MedicalRecord record)
        {
            record.CreatedAt = DateTime.Now;
            _medicalRecordRepository.UpdateMedicalRecord(record);   
        }
        public bool checkExistMedicalRecord(int patientID)
        {
            if (_medicalRecordRepository.GetMedicalRecordByPatientID(patientID) != null) return false;
            return true;
        }
    }
}
