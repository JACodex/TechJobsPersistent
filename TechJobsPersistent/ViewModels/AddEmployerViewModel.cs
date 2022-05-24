using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage ="Job Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Job Location Required")]
        public string Location { get; set; }
    }
}
