using Microsoft.AspNetCore.Mvc;
using JobHub.Models;
using JobHub.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace JobHub.Controllers
{
    [Authorize]
    public class JobSeekerController : Controller
    {
        private readonly JobHubDbContext _dbContext;

        public JobSeekerController(JobHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(string searchByFirstLetter)
        {
            var jobSeekers = await FilterJobSeekersByFirstLetter(searchByFirstLetter).ToListAsync();
            ViewBag.SearchByFirstLetter = searchByFirstLetter;
            return View(jobSeekers);
        }

        private IQueryable<JobSeeker> FilterJobSeekersByFirstLetter(string searchByFirstLetter)
        {
            var query = _dbContext.JobSeekers.AsQueryable();

            if (!string.IsNullOrEmpty(searchByFirstLetter))
            {
                var lowerCaseLetter = searchByFirstLetter.ToLower();
                query = query.Where(job => job.firstName.ToLower().StartsWith(lowerCaseLetter)
                                        || job.lastName.ToLower().StartsWith(lowerCaseLetter));
            }

            return query;
        }

        public RedirectToActionResult ShowAll()
        {
            return RedirectToAction("Index");
        }

        // Display details for a single job seeker by its ID
        public IActionResult ShowDetails(int id)
        {
            var jobSeeker = _dbContext.JobSeekers.SingleOrDefault(j => j.ID == id);
            if (jobSeeker == null)
            {

                return NotFound("JobSeeker with the provided ID does not exist.");
            }
            return View(jobSeeker);
        }

        // Render the Create view [GET]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        // Add a new company to the list [POST]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobSeeker newJobSeeker)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _dbContext.JobSeekers.Add(newJobSeeker);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // Render the Edit view for an existing JobSeeker [GET]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var jobSeeker = _dbContext.JobSeekers.FirstOrDefault(j => j.ID == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }
            return View(jobSeeker);
        }

        // Update an existing JobSeeker's details [POST]
        [HttpPost]
        public IActionResult Edit(JobSeeker changedJobSeeker)
        {
            if (!ModelState.IsValid)
            {
                return View(changedJobSeeker);
            }

            var jobSeeker = _dbContext.JobSeekers.FirstOrDefault(j => j.ID == changedJobSeeker.ID);
            if (jobSeeker == null)
            {
                return NotFound();
            }

                  
            jobSeeker.EmailAddress = changedJobSeeker.EmailAddress;
            jobSeeker.PhoneNumber = changedJobSeeker.PhoneNumber;
            jobSeeker.Address = changedJobSeeker.Address;
            jobSeeker.JobTitle = changedJobSeeker.JobTitle;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var jobSeeker = _dbContext.JobSeekers.FirstOrDefault(j => j.ID == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }
            return View(jobSeeker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var jobSeeker = _dbContext.JobSeekers.FirstOrDefault(c => c.ID == id);
            if (jobSeeker == null)
            {
                return NotFound();
            }

            _dbContext.JobSeekers.Remove(jobSeeker);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
