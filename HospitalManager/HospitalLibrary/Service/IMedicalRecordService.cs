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
        MedicalRecord GetMedicalRecordByPatientID(int patientID);
        void AddMedicalRecord(MedicalRecord record);
        void UpdateMedicalRecord(MedicalRecord record);
        public bool checkExistMedicalRecord(int patientID);
    }
}
