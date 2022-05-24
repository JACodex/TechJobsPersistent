using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {

        JobDbContext dbContext;

        public EmployerController(JobDbContext context) { dbContext = context; }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = dbContext.Employers.ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", addEmployerViewModel);
            }
            Employer newEmployer = new Employer
            {
                Name = addEmployerViewModel.Name,
                Location = addEmployerViewModel.Location,
            };
            dbContext.Employers.Add(newEmployer);
            dbContext.SaveChanges();

            return Redirect("/");
        }

        public IActionResult About(int id)
        {
           Employer employer =  dbContext.Employers.Find(id);
            return View(employer);
        }
    }
}
