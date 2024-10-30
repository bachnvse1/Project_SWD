using System.Collections.Generic;
using HospitalLibrary.DataAccess;
using HospitalLibrary.Repository;

namespace HospitalLibrary.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void AddPatient(Patient patient)
        {
            _patientRepository.AddPatient(patient);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _patientRepository.GetAllPatients();
        }

        public Patient GetPatientById(int patientId)
        {
            return _patientRepository.GetPatientById(patientId);
        }

        public void UpdatePatient(Patient patient)
        {
            _patientRepository.UpdatePatient(patient);
        }

        public void DeletePatient(int patientId)
        {
            _patientRepository.DeletePatient(patientId);
        }

        public IEnumerable<Patient> GetDeletedPatients()
        {
            return _patientRepository.GetDeletedPatients();
        }

        public void RestorePatient(int patientId)
        {
            _patientRepository.RestorePatient(patientId);
        }
    }
}
