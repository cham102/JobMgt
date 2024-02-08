using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobTypeMgt.Data;
using JobTypeMgt.models;

namespace JobTypeMgt.Pages.JobTypes
{
    public class EditModel : PageModel
    {
        private readonly JobTypeMgt.Data.JobTypeMgtContext _context;

        public EditModel(JobTypeMgt.Data.JobTypeMgtContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JobTypeHed JobTypeHeds { get; set; } = default!;
        [BindProperty]
        public JobTypeDet jobTypeDet { get; set; } = default!;

        [BindProperty]
        public IList<JobTypeDet> JobTypeDetList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.JobTypeHeds == null)
            {
                return NotFound();
            }

            var jobtypehed = await _context.JobTypeHeds.FirstOrDefaultAsync(m => m.JobTypePk == id);
            if (jobtypehed == null)
            {
                return NotFound();
            }
            JobTypeHeds = jobtypehed;
            var jobtypedet = await _context.jobTypeDet.Where(m => m.JobTypePk == id).ToListAsync();
            //jobtypedet.JobTypeDetPk
            if (jobtypedet == null)
            {
                return NotFound();
            }
            JobTypeDetList = jobtypedet;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Attach(JobTypeHeds).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                   
                    foreach (var item in JobTypeDetList)
                    {
                        var existingJobTypeDet = await _context.jobTypeDet.FirstOrDefaultAsync(j => j.JobTypeDetPk == item.JobTypeDetPk);

                        if (existingJobTypeDet != null)
                        {
                                 existingJobTypeDet.JobTypeMilestone = item.JobTypeMilestone;
                                 existingJobTypeDet.JobTypStatus = item.JobTypStatus;
                                 existingJobTypeDet.JobTypePk = item.JobTypePk;
                                  _context.Attach(existingJobTypeDet).State = EntityState.Modified;
                                  await _context.SaveChangesAsync();

                        }           
                        else
                        {
                            JobTypeDet objJobDet = new JobTypeDet();
                            objJobDet.JobTypeMilestone = item.JobTypeMilestone;
                            objJobDet.JobTypStatus = item.JobTypStatus;
                            objJobDet.JobTypePk = JobTypeHeds.JobTypePk;
                            objJobDet.timestamp_column = JobTypeHeds.timestamp_column;
                            objJobDet.RecordId = JobTypeHeds.RecordId;
                            _context.jobTypeDet.Add(objJobDet);
                            await _context.SaveChangesAsync();

                        }

                    }


               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTypeHedExists(JobTypeHeds.JobTypePk))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobTypeHedExists(int id)
        {
            return _context.JobTypeHeds.Any(e => e.JobTypePk == id);
        }



        public async Task<IActionResult> OnPostDeleteMilestoneAsync(int MilestoneID)
        {
            string msgSuccess = "";
            //2023/12/19--
            var jobtypedlt = await _context.jobTypeDet.FirstOrDefaultAsync(j => j.JobTypeDetPk == MilestoneID);

            if (jobtypedlt != null)
            {
                jobTypeDet = jobtypedlt;
                _context.jobTypeDet.Remove(jobTypeDet);
                await _context.SaveChangesAsync();
                msgSuccess = "Success";
            }
            else
            {
                 msgSuccess = "UnSuccess";
            }

            // return msgSuccess = "Success";
            return new JsonResult(new { data = msgSuccess });
            //return RedirectToPage("./Index");

        }
    }
}
