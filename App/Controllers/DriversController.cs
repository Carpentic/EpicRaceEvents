using App.Data;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class DriversController : Controller
    {
        IRepository _repository;

        public DriversController(IRepository repo)
        {
            _repository = repo;
        }

        public IActionResult Index(int page = 1)
        {
            return View(new Models.ViewModels.Drivers.IndexModel(_repository, page));
        }
    }
}
