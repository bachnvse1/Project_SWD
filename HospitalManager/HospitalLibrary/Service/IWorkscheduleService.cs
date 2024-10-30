﻿using HospitalLibrary.DataAccess;
using System.Collections.Generic;

namespace HospitalLibrary.Service
{
    public interface IWorkscheduleService
    {
        bool AddWorkSchedule(WorkSchedule schedule);
        IEnumerable<WorkSchedule> GetAllWorkSchedules();
        WorkSchedule GetWorkScheduleById(int id);
        bool UpdateWorkSchedule(WorkSchedule schedule);
        bool DeleteWorkSchedule(int id);
    }
}
