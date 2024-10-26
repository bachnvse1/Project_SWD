using System;
using System.Collections.Generic;

namespace HospitalLibrary.DataAccess;

public partial class MedicalRecord
{
    public int MedicalRecordId { get; set; }

    public string? Detail { get; set; }

    public int? PatientId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdateBy { get; set; }

    public virtual Patient? Patient { get; set; }
}
