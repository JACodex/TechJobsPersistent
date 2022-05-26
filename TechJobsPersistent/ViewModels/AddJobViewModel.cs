using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "Job Requires A Name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Please enter a Min length is 2, Max Length 100 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Requires A Employer to be selected")]
        public int EmployerId { get; set; }

        public List<SelectListItem> Employers { get; set; }

        public List<Skill> Skills { get; set; }

        public List<int> SkillId { get; set; }

        public AddJobViewModel()
        {

        }

        public AddJobViewModel( List<Employer> employers , List<Skill> skills) {

            Skills = skills;
            Employers = new List<SelectListItem>();

            foreach (var employer in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });
            }
        }
        /**          TODO     update home controller so skills data is being shared  **/
    }
}
