using HospitalLibrary.DataAccess;

namespace HospitalLibrary.Repository
{
    public class WorkscheduleRepository : IWorkscheduleRepository
    {
        private readonly DBContext _context;

        public WorkscheduleRepository(DBContext context)
        {
            _context = context;
        }

        public WorkSchedule CreateWorkSchedule(WorkSchedule workSchedule)
        {
            workSchedule.CreatedAt = DateTime.Now;
            _context.WorkSchedules.Add(workSchedule);
            _context.SaveChanges();
            return workSchedule;
        }

        public bool DeleteWorkSchedule(int id)
        {
            var workSchedule = _context.WorkSchedules.Find(id);
            if (workSchedule == null)
            {
                return false;
            }

            _context.WorkSchedules.Remove(workSchedule);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<WorkSchedule> GetAllWorkSchedules()
        {
            return _context.WorkSchedules.ToList();
        }

        public WorkSchedule GetWorkScheduleById(int id)
        {
            return _context.WorkSchedules.Find(id);
        }

        public bool UpdateWorkSchedule(WorkSchedule workSchedule)
        {
            var existingSchedule = _context.WorkSchedules.Find(workSchedule.ScheduleId);
            if (existingSchedule == null)
            {
                return false;
            }

            existingSchedule.TimeSlot = workSchedule.TimeSlot;
            existingSchedule.PatientId = workSchedule.PatientId;
            existingSchedule.UserId = workSchedule.UserId;
            existingSchedule.UpdateBy = workSchedule.UpdateBy;
            existingSchedule.UpdateAt = DateTime.Now;

            _context.SaveChanges();
            return true;
        }
    }
}
