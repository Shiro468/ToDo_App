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

        [HttpPost]
        public IActionResult Create([FromForm] Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                _jobsRepository.Add(jobs);
                return RedirectToAction("Index");
            }
            return View("Formula");

        }

        //add to Views Delete.cshtml with
        //question about confirmation to delete task 
        public async Task<IActionResult> Delete(int id) 
        {
            var tasksDetails = await _jobsRepository.GetByIdAsync(id);
            if (tasksDetails == null) return View("Error");
            return View(tasksDetails);
        }

        [HttpPost, ActionName("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var tasksDetails = await _jobsRepository.GetByIdAsync(id);
            if (tasksDetails == null) return View("Error");

            _jobsRepository.Delete(tasksDetails);
            return RedirectToAction("Index");
        }
        public IActionResult Formula()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}