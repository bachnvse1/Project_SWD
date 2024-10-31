using System;
using System.Collections.Generic;
using HospitalLibrary.DataAccess;

namespace HospitalLibrary.Repository
{
    public interface IPatientRepository
    {
        void AddPatient(Patient patient);
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int patientId);
        void UpdatePatient(Patient patient);
        void DeletePatient(int patientId);
        IEnumerable<Patient> GetDeletedPatients();
        void RestorePatient(int patientId);
        public int CountPatientsInRoom(int roomId);
        public void CreateHospitalAdmissionProcedure(Patient patient);
        IEnumerable<Patient> SearchPatients(string searchname);
        Patient GetPatientServiceById(int? patientId);
    }
}
