using System;
using System.Collections.Generic;
using HospitalLibrary.DataAccess;

namespace HospitalLibrary.Repository
{
    public interface ITreatmentPlanRepository
    {
        TreatmentPlan AddTreatmentPlan(TreatmentPlan treatmentPlan);
        IEnumerable<TreatmentPlan> GetAllTreatmentPlans();
        TreatmentPlan GetTreatmentPlantById(int treatmentPlanID);
        bool UpdateTreatmentPlan(TreatmentPlan treatmentPlan);
        bool DeleteTreatmentPlan(int treatmentPlanId);
        
    }
}
