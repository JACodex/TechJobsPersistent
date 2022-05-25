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
    }
}
