using System;
using System.Collections.Generic;

namespace HospitalLibrary.DataAccess;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? PatientName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public int? RoomId { get; set; }

    public string? HealthInsurance { get; set; }

    public string? HealthCondition { get; set; }

    public bool? IsDelete { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Room? Room { get; set; }

    public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; } = new List<TreatmentPlan>();

    public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();

    public virtual ICollection<HospitalService> Services { get; set; } = new List<HospitalService>();
}
