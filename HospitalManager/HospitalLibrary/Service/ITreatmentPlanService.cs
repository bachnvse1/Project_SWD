using HospitalLibrary.DataAccess;
using System.Collections.Generic;

namespace HospitalLibrary.Service
{
    public interface ITreatmentPlanService
    {
        bool AddTreatmentPlan(TreatmentPlan treatmentPlan);
        IEnumerable<TreatmentPlan> GetAllTreatmentPlans();
        TreatmentPlan GetTreatmentPlantById(int treatmentPlanId);
        bool UpdateTreatmentPlan(TreatmentPlan treatmentPlan);
        bool DeleteTreatmentPlan(int treatmentPlanId);
      
    }
}
