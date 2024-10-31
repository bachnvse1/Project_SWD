using System.Collections.Generic;
using HospitalLibrary.DataAccess;

namespace HospitalLibrary.Repository
{
    public interface IWorkscheduleRepository
    {
        WorkSchedule CreateWorkSchedule(WorkSchedule workSchedule);
        bool validateWorkSchedule(DateTime timeSlot, int patientId, int userId);
        IEnumerable<WorkSchedule> GetAllWorkSchedules();
        WorkSchedule GetWorkScheduleById(int id);
        bool UpdateWorkSchedule(WorkSchedule workSchedule);
        bool DeleteWorkSchedule(int id);
    }
}
