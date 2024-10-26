using System;
using System.Collections.Generic;

namespace HospitalLibrary.DataAccess;

public partial class WorkSchedule
{
    public int ScheduleId { get; set; }

    public DateTime TimeSlot { get; set; }

    public int? PatientId { get; set; }

    public int? UserId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual User? User { get; set; }
}
