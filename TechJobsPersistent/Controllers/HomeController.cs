using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            List<Skill> viewSkills = context.Skills.ToList();
            AddJobViewModel addJobViewModel = new AddJobViewModel();
            addJobViewModel.Skills = viewSkills;
            

            //ViewBag.Employers = context.Employers.ToList();
            List<Employer> employerList = context.Employers.ToList();
            List<SelectListItem> selectListItemList = new List<SelectListItem>();

            foreach (Employer employer in employerList)
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = employer.Name,
                    Value = employer.Id.ToString()
                };
                selectListItemList.Add(selectListItem);
            }
            //ViewBag.Employers = selectListItemList;
            addJobViewModel.Employers = selectListItemList;
            return View(addJobViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {
            if (!ModelState.IsValid)
            {
                return View("AddJob", addJobViewModel); //TODO, SelectItemList does not repopulate on validation error
            }
            Employer employerToFind = context.Employers.Find(addJobViewModel.EmployerId);
            if (employerToFind != null)
            {
                Job job = new Job
                {
                    Name = addJobViewModel.Name,
                    EmployerId = (int)addJobViewModel.EmployerId,
                    Employer = employerToFind,
                };

                for(int i = 0; i < selectedSkills.Length; i++)
                {
                    JobSkill skill = new JobSkill
                    {
                        JobId = job.Id,
                        Job = job,
                        SkillId = Int32.Parse(selectedSkills[i])
                    };
                    context.JobSkills.Add(skill);
                }
                context.Jobs.Add(job);
                context.SaveChanges();
                return Redirect("/");
            }

            return Redirect("/AddJob");
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
