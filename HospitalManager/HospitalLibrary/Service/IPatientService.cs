using HospitalLibrary.DataAccess;
using System.Collections.Generic;

namespace HospitalLibrary.Service
{
    public interface IPatientService
    {
        void AddPatient(Patient patient);
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int patientId);
        void UpdatePatient(Patient patient);
        void DeletePatient(int patientId);
        IEnumerable<Patient> GetDeletedPatients();
        void RestorePatient(int patientId);
        IEnumerable<Patient> SearchPatient(string searchname);
        Patient GetPatientServiceById(int? patientId);
        void MarkPatientAsDeleted(int? patientId);
        void CreateHospitalAdmissionProcedure(Patient patient);
    }
}
