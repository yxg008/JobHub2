using Microsoft.AspNetCore.Mvc;
using JobHub.Models;
using System.Collections.Generic;
using System.Linq;
using JobHub.Service;
using JobHub.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace JobHub.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly JobHubDbContext _dbContext;

        // Constructor: Initializes the controller with the database context
        public CompanyController(JobHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        // Index action: Displays the list of companies with optional filtering by company name and skill
        public async Task<ViewResult> Index(string searchByCompanyName, string selectedSkill)
        {
            // Apply filters based on the provided search criteria
            var companies = FilterCompaniesBySearchTerm(searchByCompanyName);
            companies = FilterCompaniesBySkill(companies, selectedSkill);

            // Get a list of all available skills for filtering on the UI
            var availableSkills = await GetAllAvailableSkills();

            // Pass data to the view via ViewBag
            ViewBag.AvailableSkills = availableSkills;
            ViewBag.SearchByCompanyName = searchByCompanyName;

            // Execute the query and convert to list to avoid multiple enumerations
            var companyList = await companies.ToListAsync();
            ViewBag.Companies = companyList; // Pass the list to the view

            return View(companyList);
        }

        // Filters companies by the first character of their name
        private IQueryable<Company> FilterCompaniesBySearchTerm(string searchByCompanyName)
        {
            var query = _dbContext.Companies.AsQueryable();

            // Filter by first character if a search term is provided
            if (!string.IsNullOrEmpty(searchByCompanyName))
            {
                var firstChar = searchByCompanyName.Substring(0, 1).ToLower();
                query = query.Where(comp => comp.Name.Substring(0, 1).ToLower() == firstChar);
            }

            return query;
        }

        // Filters companies by the selected skill
        private IQueryable<Company> FilterCompaniesBySkill(IQueryable<Company> companies, string selectedSkill)
        {
            // Further filter by skill if one is selected
            if (!string.IsNullOrEmpty(selectedSkill) && Enum.TryParse<Skills>(selectedSkill, out var skill))
            {
                companies = companies.Where(comp => comp.Skill == skill);
            }

            return companies;
        }

        // Retrieves a list of all distinct skills available in the companies
        private async Task<IEnumerable<Skills>> GetAllAvailableSkills()
        {
            // Select and order distinct skills for filtering options
            return await _dbContext.Companies
                                   .Select(comp => comp.Skill)
                                   .Distinct()
                                   .OrderBy(skill => skill)
                                   .ToListAsync();
        }



        // Display all companies in the list LINQ
        //public viewresult index(string searchbycompanyname, string selectedskill)
        //{
        //    iqueryable<company> companies = _dbcontext.companies;

        //    if (!string.isnullorempty(searchbycompanyname)) // narrow down the list of companies to display
        //    {
        //        // take the first character of the search term and make it lowercase
        //        var firstchar = searchbycompanyname.substring(0, 1).tolower();

        //        // use substring to compare the first character of the company name
        //        companies = companies.where(comp => comp.name!.substring(0, 1).tolower() == firstchar);
        //    }
        //    if(!selectedskill.isnullorempty())
        //    {
        //        companies = companies.where(comp => comp.skill == enum.parse<skills>(selectedskill));
        //    }
        //    //get a list of all skills for the list of comapines
        //    //var avaliableskills = from comp in companies
        //    //                      orderby comp.skill
        //    //                      select comp.skill;
        //    //avaliableskills = avaliableskills.distinct();
        //    var avaliableskills = companies.select(comp => comp.skill) //linq
        //                                    .distinct()
        //                                    .orderby(skill =>skill);

        //    viewbag.avaliableskills = avaliableskills;
        //    viewbag.searchbycompanyname = searchbycompanyname;
        //    return view(companies.tolist());
        //}



        // Redirect to the Index action to display all companies
        [AllowAnonymous]
        public RedirectToActionResult ShowAll()
        {
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        // Display details for a single company by its ID
        public IActionResult ShowDetails(int id)
        {
            var company = _dbContext.Companies.SingleOrDefault(c => c.ID == id);
            if (company == null)
            {
                return NotFound("Company with the provided ID does not exist.");
            }
            if (company != null) //did we find an isntructors?
            {
                if (company.CorporateLogoData != null) //we have an image stored in the database
                {
                    //covert the byte array back into an image
                    string imageBase64Data = Convert.ToBase64String(company.CorporateLogoData);
                    string companyProfilePhoto = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                    ViewBag.companyProfilePhoto = companyProfilePhoto;
                }
            }

            ViewBag.id = id;
            return View(company);
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
        public IActionResult Create(Company newCompany)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new();
                file.CopyTo(ms);
                newCompany.CorporateLogoData = ms.ToArray();
                ms.Close();
                ms.Dispose();
            }
            _dbContext.Companies.Add(newCompany);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // Render the Edit view for an existing company [GET]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var company = _dbContext.Companies.FirstOrDefault(c => c.ID == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // Update an existing company's details [POST]
        [HttpPost]
        public IActionResult Edit(Company changedCompany)
        {
            if (!ModelState.IsValid)
            {
                return View(changedCompany);
            }

            var company = _dbContext.Companies.FirstOrDefault(c => c.ID == changedCompany.ID);
            if (company == null)
            {
                return NotFound();
            }

            company.OpenPosition = changedCompany.OpenPosition;
            company.YearRequirement = changedCompany.YearRequirement;
            company.Salary = changedCompany.Salary;
            company.Skill = changedCompany.Skill;
            company.PostDate = changedCompany.PostDate;
            company.Location = changedCompany.Location;


            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var company = _dbContext.Companies.FirstOrDefault(c => c.ID == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var company = _dbContext.Companies.FirstOrDefault(c => c.ID == id);
            if (company == null)
            {
                return NotFound();
            }

            _dbContext.Companies.Remove(company);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}





