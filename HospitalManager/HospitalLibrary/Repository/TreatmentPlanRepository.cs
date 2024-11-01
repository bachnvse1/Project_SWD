using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.DataAccess;   // Adjust this according to your data context namespace

namespace HospitalLibrary.Repository
{
    public class TreatmentPlanRepository : ITreatmentPlanRepository
    {
        private readonly DBContext _context; // Assuming you have a context class for your database

        public TreatmentPlanRepository(DBContext context)
        {
            _context = context;
        }

        public TreatmentPlan AddTreatmentPlan(TreatmentPlan TreatmentPlan)
        {
            _context.TreatmentPlans.Add(TreatmentPlan);
            _context.SaveChanges();
            return TreatmentPlan;
        }

        public TreatmentPlan GetTreatmentPlantById(int treatmentPlanId)
        {
            return _context.TreatmentPlans.Find(treatmentPlanId);
        }

        public IEnumerable<TreatmentPlan> GetAllTreatmentPlans()
        {
            return _context.TreatmentPlans.ToList();
        }

        public bool UpdateTreatmentPlan(TreatmentPlan treatmentPlan)
        {
            _context.TreatmentPlans.Update(treatmentPlan);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTreatmentPlan(int treatmentPlanId)
        {
            var user = GetTreatmentPlantById(treatmentPlanId);
            if (user != null)
            {
                _context.TreatmentPlans.Remove(user);
                _context.SaveChanges();
                return true;
            }
            else {
                return false;
            }
        }
    }
}
