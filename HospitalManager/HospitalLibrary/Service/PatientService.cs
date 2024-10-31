using HospitalLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Service
{
    public class PatientService : IPatientService
    {
        private readonly DBContext _context;
        public PatientService()
        {
            _context = new DBContext();
        }
        public void getAllPatient(Patient patient)
        {

        }
        public Patient getPatientByID(int id)
        {
            return _context.Patients.FirstOrDefault(p => p.PatientId == id);
        }
    }
}
