using HospitalLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Service
{
    public interface IWorkscheduleService
    {
        public void addWorkschedule(WorkSchedule schedule);
    }
}
