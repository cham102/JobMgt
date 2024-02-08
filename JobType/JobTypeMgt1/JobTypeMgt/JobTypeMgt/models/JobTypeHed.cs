using System.ComponentModel.DataAnnotations;

namespace JobTypeMgt.models
{
    
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

        public int AddUser { get; set; }
        public DateTime AddDate { get; set; }
        public string AddMach { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Session { get; set; }
        public int RecordId { get; set; }
        [Timestamp]
        public byte[] timestamp_column { get; set; }

       

    }
    
}
