using HospitalLibrary.DataAccess;
using HospitalLibrary.Repository;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Service
{
    public class TreatmentPlanService : ITreatmentPlanService
    {
        private readonly ITreatmentPlanRepository _treatmentPlanRepository;

        public TreatmentPlanService(ITreatmentPlanRepository treatmentPlanRepository)
        {
            _treatmentPlanRepository = treatmentPlanRepository;
        }

        public bool AddTreatmentPlan(TreatmentPlan treatmentPlan)
        {
            if (treatmentPlan == null) throw new ArgumentNullException(nameof(treatmentPlan));
            treatmentPlan.CreatedAt = DateTime.Now;
            _treatmentPlanRepository.AddTreatmentPlan(treatmentPlan);
            return true;
        }

        public bool DeleteTreatmentPlan(int id)
        {
            return _treatmentPlanRepository.DeleteTreatmentPlan(id);
        }

        public IEnumerable<TreatmentPlan> GetAllTreatmentPlans()
        {
            return _treatmentPlanRepository.GetAllTreatmentPlans();
        }

        public TreatmentPlan GetTreatmentPlantById(int id)
        {
            return _treatmentPlanRepository.GetTreatmentPlantById(id);
        }

        public bool UpdateTreatmentPlan(TreatmentPlan treatmentPlan)
        {
            if (treatmentPlan == null) throw new ArgumentNullException(nameof(treatmentPlan));
            treatmentPlan.UpdateAt = DateTime.Now;
            return _treatmentPlanRepository.UpdateTreatmentPlan(treatmentPlan);
        }
    }
}
