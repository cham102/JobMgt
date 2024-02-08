using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTypeMgt.models
{
    //public class JobType
    //{
    public class JobTypeHed
    {
        [Key]
        public int JobTypePk { get; set; }

        [Required]
        [StringLength(10)]
        public string JobTypecode { get; set; }

        [Required]
        [StringLength(150)]
        public string JobTypeDescription { get; set; }

        [Required]
        [StringLength(100)]
        public string JobTypPrefix { get; set; }

        [Required]
        [StringLength(50)]
        public string JobTypActive { get; set; }

        //public int AddUser { get; set; }

        //public DateTime AddDate { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string AddMach { get; set; }

        //[StringLength(int.MaxValue)]
        //public string Session { get; set; }

        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int RecordId { get; set; }

        //[Timestamp]
        //public byte[] timestamp_column { get; set; }


    }
    public class JobTypeDet
    {
        [Key]
        public int JobTypeDetPk { get; set; }

        [ForeignKey("JobTypeHed")]
        public int JobTypePk { get; set; }

        public virtual JobTypeHed JobTypeHed { get; set; }

        public string JobTypeMilestone { get; set; }

        public string JobTypStatus { get; set; }


    }
//}
}
