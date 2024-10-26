using System;
using System.Collections.Generic;

namespace HospitalLibrary.DataAccess;

public partial class Room
{
    public int RoomId { get; set; }

    public string? RoomName { get; set; }

    public bool? IsAvailable { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdateBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
