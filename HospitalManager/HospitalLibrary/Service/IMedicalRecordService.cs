using HospitalLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Service
{
    public interface IMedicalRecordService
    {
        public void AddMedicalRecord(MedicalRecord medicalRecord);
        public void UpdateMedicalRecord(MedicalRecord medicalRecord);
        public MedicalRecord GetMedicalRecordByPatientId(int id);
    }
}
