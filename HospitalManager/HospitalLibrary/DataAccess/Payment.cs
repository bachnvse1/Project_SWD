using System;
using System.Collections.Generic;

namespace HospitalLibrary.DataAccess;

public partial class Payment
{
    public int PaymentId { get; set; }

    public double? Amount { get; set; }

    public int? PatientId { get; set; }

    public DateTime? TransactionTime { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Patient? Patient { get; set; }
}
