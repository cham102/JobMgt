using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTypeMgt.models
{
    public class JobTypeDet
    {
        [Key]
        public int JobTypeDetPk { get; set; }

        [ForeignKey("JobTypeHed")]
        public int JobTypePk { get; set; }

        public  JobTypeHed JobTypeHed { get; set; }

        [Display(Name = "Milestone")]
        public string JobTypeMilestone { get; set; }

        [Display(Name = "Loading Stage")]
        public string JobTypStatus { get; set; }

        public int RecordId { get; set; }

        [Timestamp]
        public byte[] timestamp_column { get; set; }

    }
}
