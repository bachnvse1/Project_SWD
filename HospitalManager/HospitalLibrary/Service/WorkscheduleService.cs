using HospitalLibrary.DataAccess;
using HospitalLibrary.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Service
{
    public class WorkscheduleService : IWorkscheduleService
    {
        private readonly IWorkscheduleRepository _workscheduleRepository;

        public WorkscheduleService(IWorkscheduleRepository workscheduleRepository)
        {
            _workscheduleRepository = workscheduleRepository;
        }

        public bool AddWorkSchedule(WorkSchedule schedule)
        {
            if (schedule == null) throw new ArgumentNullException(nameof(schedule));
            schedule.CreatedAt = DateTime.Now;
            _workscheduleRepository.CreateWorkSchedule(schedule);
            return true;
        }

        public bool DeleteWorkSchedule(int id)
        {
            return _workscheduleRepository.DeleteWorkSchedule(id);
        }

        public IEnumerable<WorkSchedule> GetAllWorkSchedules()
        {
            return _workscheduleRepository.GetAllWorkSchedules();
        }

        public WorkSchedule GetWorkScheduleById(int id)
        {
            return _workscheduleRepository.GetWorkScheduleById(id);
        }

        public bool UpdateWorkSchedule(WorkSchedule schedule)
        {
            if (schedule == null) throw new ArgumentNullException(nameof(schedule));
            schedule.UpdateAt = DateTime.Now;
            return _workscheduleRepository.UpdateWorkSchedule(schedule);
        }

        public bool validateWorkSchedule(DateTime timeSlot, int patientId, int userId)
        {
            return _workscheduleRepository.validateWorkSchedule(timeSlot, patientId, userId);
        }
    }
}
