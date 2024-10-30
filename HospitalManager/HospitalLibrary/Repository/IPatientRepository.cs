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
    }
}
