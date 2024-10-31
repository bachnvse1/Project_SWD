using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DBContext _context; // Thay YourDbContext bằng tên context thực tế

        public PatientRepository(DBContext context)
        {
            _context = context;
        }

        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.Where(p => p.IsDelete == false).ToList();
        }

        public Patient GetPatientById(int patientId)
        {
            return _context.Patients.Find(patientId);
        }

        public void UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        public void DeletePatient(int patientId)
        {
            var patient = _context.Patients.Find(patientId);
            if (patient != null)
            {
                patient.IsDelete = true;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Patient> GetDeletedPatients()
        {
            return _context.Patients.Where(p => p.IsDelete == true).ToList();
        }

        public void RestorePatient(int patientId)
        {
            var patient = _context.Patients.Find(patientId);
            if (patient != null)
            {
                patient.IsDelete = false;
                _context.SaveChanges();
            }
        }
        public IEnumerable<Patient> SearchPatients(string? searchTerm)
        {
            var query = _context.Patients.Where(p => p.IsDelete==false);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p => p.PatientName.Contains(searchTerm) || p.Phone.Contains(searchTerm));
            }

            return query.Include(p => p.Room).Include(p => p.Services).ToList();
        }

        public Patient GetPatientServiceById(int? patientId)
        {
            return _context.Patients
                  .Include(p => p.Services)
                  .FirstOrDefault(p => p.PatientId == patientId);
        }

        
    }
}
