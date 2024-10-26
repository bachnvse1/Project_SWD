﻿using System;
using System.Collections.Generic;

namespace HospitalLibrary.DataAccess;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
