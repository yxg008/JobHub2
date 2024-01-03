// MyServiceClass.cs
using JobHub.Models;
using System;
using System.Collections.Generic;

namespace JobHub.Service
{
    public class MyServiceClass : MyServiceInterface
    {
        public List<Company> AllCompanies { get; set; }

        public MyServiceClass()
        {
            AllCompanies = new List<Company>
            {
                CreateCompany(1, "Google", "SDE II", 120000, 3, Skills.Java, "Redmond, WA"),
                CreateCompany(2, "Microsoft", "SDE I", 110000, 2, Skills.CSharp, "Redmond, WA"),
                CreateCompany(3, "Amazon", "SDE III", 130000, 4, Skills.Python, "Seattle, WA"),
                CreateCompany(4, "Facebook", "Front-end Developer", 115000, 2, Skills.Javascript, "Menlo Park, CA"),
                CreateCompany(5, "Apple", "iOS Developer", 125000, 3, Skills.Swift, "Cupertino, CA")
            };
        }

        private Company CreateCompany(int id, string name, string position, int salary, int yearRequirement,
                                      Skills skill, string location)
        {
            return new Company
            {
                ID = id,
                Name = name,
                OpenPosition = position,
                Salary = salary,
                YearRequirement = yearRequirement,
                Skill = skill,
                Location = location,
                PostDate = DateTimeOffset.Now
            };
        }
    }
}
