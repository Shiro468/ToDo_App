using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoApp.Models;
using ToDoApp.Interfaces;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobsRepository _jobsRepository;

        public HomeController(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Jobs> jobs = await _jobsRepository.GetAll();
            return View(jobs);
        }

        public IActionResult Formula()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Jobs jobs)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            _jobsRepository.Add(jobs);
            return RedirectToAction("Index");
            // dodac jeszcze walidacje przy bledzie bo ten brzydko wyglada slowa klucze validation of model  
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}