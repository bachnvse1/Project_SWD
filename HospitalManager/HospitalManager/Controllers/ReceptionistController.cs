using Microsoft.AspNetCore.Mvc;

namespace HospitalManager.Controllers
{
    public class ReceptionistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
