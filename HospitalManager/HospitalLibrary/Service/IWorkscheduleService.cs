using HospitalLibrary.DataAccess;
using System.Collections.Generic;

namespace HospitalLibrary.Service
{
    public interface IWorkscheduleService
    {
        bool AddWorkSchedule(WorkSchedule schedule);
        bool validateWorkSchedule(DateTime timeSlot, int patientId, int userId);
        IEnumerable<WorkSchedule> GetAllWorkSchedules();
        WorkSchedule GetWorkScheduleById(int id);
        bool UpdateWorkSchedule(WorkSchedule schedule);
        bool DeleteWorkSchedule(int id);
    }
}
