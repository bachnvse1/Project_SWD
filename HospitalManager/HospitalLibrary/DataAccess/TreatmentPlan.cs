using System;
using System.Collections.Generic;

namespace HospitalLibrary.DataAccess;

public partial class TreatmentPlan
{
    public int PatientId { get; set; }

    public string MedicineSection { get; set; } = null!;

    public string? TreatmentMethodSection { get; set; }

    public string? DoctorInCharge { get; set; }

    public DateTime TreatmentTime { get; set; }

    public int? UserId { get; set; }

    public int? ServiceId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual HospitalService? Service { get; set; }

    public virtual User? User { get; set; }
}
