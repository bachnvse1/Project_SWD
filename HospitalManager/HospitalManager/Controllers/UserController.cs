using HospitalLibrary.DataAccess;
using HospitalLibrary.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Controllers
{
    public class UserController : Controller
    {
        private readonly DBContext _context;
        private IUserService _userService;
        

        public UserController(DBContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
          
        }
        public IActionResult CreateUser(
         string username,
         bool? gender,
         string? phone,
         string? email,
         string? passwordHash,
         DateTime? createdDate,
         int? departmentId,
         int? roleId
         
     )
        {
            // Tạo đối tượng User trống
            var user = new User();

            // Gán từng thuộc tính cho User
            user.UserId = _userService.GetAllUsers().Select(p => p.UserId).Max() + 1;
            user.Username = username;
            user.Gender = gender;
            user.Phone = phone;
            user.Email = email;
            user.PasswordHash = passwordHash;
            user.IsAvailable = true;
            user.CreatedDate = createdDate;
            user.DepartmentId = departmentId;
            user.RoleId = roleId;
            user.CreatedBy = 0;
            user.UpdateBy = 0;
            user.CreatedAt = DateTime.Now;
            user.UpdateAt = DateTime.Now;

            // Lưu đối tượng User thông qua UserService
            _userService.CreateUser(user);

            // Chuyển hướng đến trang Index sau khi thêm thành công
            return RedirectToAction("Index");
        }
        // Hiển thị danh sách người dùng
        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        // Hiển thị form để thêm người dùng mới
        public IActionResult Create()
        {
            return View();
        }
        // Form để chỉnh sửa thông tin người dùng
        public IActionResult Edit(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Xử lý việc cập nhật thông tin người dùng
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Xóa người dùng theo ID
        public IActionResult Delete(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Xử lý việc xóa người dùng
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.RemoveUser(id);
            return RedirectToAction("Index");
        }
    }      
    }


