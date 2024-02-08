using JobTypeMgt.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobTypeMgt.Pages.JobTypes
{
    public class CreateJobTypeModel : PageModel
    {
        public JobTypeHed JobType { get; set; }
        public  JobTypeDet JobTypeDet { get; set; }
        public PageResult OnGet()
        {
            return Page();
        }
    }
}
