using System;
using System.Collections.Generic;

namespace HospitalLibrary.DataAccess;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public bool? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public bool? IsAvailable { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? DepartmentId { get; set; }

    public int? RoleId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; } = new List<TreatmentPlan>();

    public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
}
