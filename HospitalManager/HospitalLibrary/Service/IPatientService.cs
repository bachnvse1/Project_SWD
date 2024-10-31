using HospitalLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Service
{
    public interface IPatientService
    {
        public void getAllPatient(Patient patient);
        Patient getPatientByID(int id);
    }
}
