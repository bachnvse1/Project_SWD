using HospitalLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Repository
{
    public interface IMedicalRecordRepository
    {
        MedicalRecord GetMedicalRecordByPatientID(int PatientID);
        void AddMedicalRecord(MedicalRecord record);
        void UpdateMedicalRecord(MedicalRecord record);    
    }
}
