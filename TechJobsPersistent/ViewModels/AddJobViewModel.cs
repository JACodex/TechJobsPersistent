using System.Collections.Generic;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        public string Name { get; set; }
        public int selectedEmployerId { get; set; }

        public List<Employer> Employers { get; set; }
    }
}
