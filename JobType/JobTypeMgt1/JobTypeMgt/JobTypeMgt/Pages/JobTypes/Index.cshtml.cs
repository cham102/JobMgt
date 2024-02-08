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
    public class IndexModel : PageModel
    {
        private readonly JobTypeMgt.Data.JobTypeMgtContext _context;

        public IndexModel(JobTypeMgt.Data.JobTypeMgtContext context)
        {
            _context = context;
        }

        public IList<JobTypeHed> JobTypeHed { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.JobTypeHeds != null)
            {
                JobTypeHed = await _context.JobTypeHeds.ToListAsync();
            }
        }
    }
}
