using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobTypeMgt.Data;
using JobTypeMgt.models;

namespace JobTypeMgt.Pages.JobTypes
{
    public class DetailsModel : PageModel
    {
        private readonly JobTypeMgt.Data.JobTypeMgtContext _context;

        public DetailsModel(JobTypeMgt.Data.JobTypeMgtContext context)
        {
            _context = context;
        }

        public JobTypeHed JobTypeHed { get; set; }

        public JobTypeDet jobTypeDet { get; set; }

        public IList<JobTypeDet> JobTypeDetList{ get; set; } = default!;

       
        //2023/12/19--
        [TempData]
        public string ErrMsg { get; set; } = "";

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ErrMsg = string.Empty;
            if (id == null || _context.JobTypeHeds == null)
            {
                return NotFound();
            }

            var jobtypehed = await _context.JobTypeHeds.FirstOrDefaultAsync(m => m.JobTypePk == id);
            if (jobtypehed == null)
            {
                return NotFound();
            }
            else 
            {
                JobTypeHed = jobtypehed;
                var jobtypedet = await _context.jobTypeDet.Where(m => m.JobTypePk == id).ToListAsync();
               

                if (jobtypedet == null)
                {
                    ErrMsg = "Data Not Found";
                }
                else
                {
                    JobTypeDetList = jobtypedet;
                }
                
            }
            return Page();
        }
    }
}
