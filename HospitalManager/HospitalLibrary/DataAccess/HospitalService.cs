using System;
using System.Collections.Generic;

namespace HospitalLibrary.DataAccess;

public partial class HospitalService
{
    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public double? ServiceFee { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; } = new List<TreatmentPlan>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
