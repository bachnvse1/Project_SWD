﻿using HospitalLibrary.DataAccess;
using HospitalLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HospitalManager.Controllers
{
    public class HospitalManagerController : Controller
    {
        private readonly DBContext _context;
        private IWorkscheduleService _workscheduleService;
        private IPatientService _patientService;
        private IUserService _userService;

        public HospitalManagerController(DBContext context, IWorkscheduleService workscheduleService, IPatientService patientService, IUserService userService)
        {
            _context = context;
            _workscheduleService = workscheduleService;
            _patientService = patientService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var workSchedules = _workscheduleService.GetAllWorkSchedules();
            ViewBag.WorkSchedules = workSchedules;
            var listPatient = _patientService.GetAllPatients();
            ViewBag.Patients = listPatient;
            var listUser = _userService.GetAllUsers();
            ViewBag.Users = listUser;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int scheduleId, DateTime timeSlot, int? patientId, int? userId)
        {
            if (ModelState.IsValid)
            {
                var existingSchedule = _context.WorkSchedules
                    .FirstOrDefault(ws => ws.TimeSlot == timeSlot && ws.PatientId == patientId && ws.UserId == userId);

                if (existingSchedule != null && existingSchedule.ScheduleId != scheduleId)
                {
                    return Json(new { success = false, message = "Một lịch làm việc đã tồn tại cho bệnh nhân và người dùng này vào khoảng thời gian đã chọn." });
                }

                var workSchedule = new WorkSchedule
                {
                    ScheduleId = scheduleId,
                    TimeSlot = timeSlot,
                    PatientId = patientId,
                    UserId = userId,
                    UpdateBy = userId,
                    UpdateAt = DateTime.Now
                };

                _context.Entry(workSchedule).State = EntityState.Modified;
                var result = _context.SaveChanges() > 0;

                if (result)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "Cập nhật không thành công." });
                }
            }

            return Json(new { success = false, message = "Dữ liệu không hợp lệ." });
        }


        [HttpPost]
        public IActionResult Create(DateTime TimeSlot, int PatientId, int UserId)
        {
            if (ModelState.IsValid)
            {
                var existingSchedule = _context.WorkSchedules
                    .FirstOrDefault(ws => ws.TimeSlot == TimeSlot && ws.PatientId == PatientId && ws.UserId == UserId);

                if (existingSchedule != null)
                {
                    return Json(new { success = false, message = "Một lịch làm việc đã tồn tại cho bệnh nhân và người dùng này vào khoảng thời gian đã chọn." });
                }

                var idMax = _context.WorkSchedules.ToList().Select(x => x.ScheduleId).Max();

                var workSchedule = new WorkSchedule
                {
                    ScheduleId = idMax + 1,
                    TimeSlot = TimeSlot,
                    PatientId = PatientId,
                    UserId = UserId,
                    UpdateAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    CreatedBy = UserId,
                };

                _context.WorkSchedules.Add(workSchedule);
                var result = _context.SaveChanges() > 0;

                if (result)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "Cập nhật không thành công." });
                }
            }

            return Json(new { success = false, message = "Dữ liệu không hợp lệ." });
        }
    }
}
