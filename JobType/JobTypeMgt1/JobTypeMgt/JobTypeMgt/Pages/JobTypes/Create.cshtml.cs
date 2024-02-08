using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobTypeMgt.Data;
using JobTypeMgt.models;

namespace JobTypeMgt.Pages.JobTypes
{
    public class CreateModel : PageModel
    {
        private readonly JobTypeMgt.Data.JobTypeMgtContext _context;

        public CreateModel(JobTypeMgt.Data.JobTypeMgtContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [TempData]
        public string ErrMsg { get; set; }

        [BindProperty]
        public JobTypeHed JobTypeHeds { get; set; }

        //2023/12/14--
        [BindProperty]
        public IList<JobTypeDet> JobTypeDetList { get; set; } = default!;

        [BindProperty]
        public JobTypeDet jobTypeDet { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            JobTypeHeds.AddUser = 123;
            JobTypeHeds.Session = "chami";
            JobTypeHeds.AddDate = DateTime.Now;
            JobTypeHeds.AddMach = "Dell";
            JobTypeHeds.RecordId = 1123;
            JobTypeHeds.timestamp_column = default;
            //----
            
            jobTypeDet.RecordId = JobTypeHeds.RecordId;
            jobTypeDet.timestamp_column = JobTypeHeds.timestamp_column;
            _context.JobTypeHeds.Add(JobTypeHeds);

            await _context.SaveChangesAsync();
            //2023/12/10--

            var existingJobTypeHed = await _context.JobTypeHeds.FindAsync(JobTypeHeds.JobTypePk);
            if(existingJobTypeHed != null) {
                foreach (var item in JobTypeDetList)
                {
                    item.JobTypePk = existingJobTypeHed.JobTypePk;
                    _context.jobTypeDet.Add(item);
                    await _context.SaveChangesAsync();

                }
              

            }
            else
            {

            }
            

            return RedirectToPage("./Index");
        }



        //public async Task<IActionResult> OnPostMilestoneAsync(List<>)
        //{

        //}
    }
}
