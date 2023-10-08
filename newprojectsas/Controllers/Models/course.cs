using System;
using System.ComponentModel.DataAnnotations;


namespace newprojectsas.Controllers.Models
{
    public class course
    {
        [Required]
        [Key]

        public int courseid { get; set; }


        [Required]
        public string coursename { get; set; }

        [Required]
        public int coursefees { get; set; }

        [Required]
        public string coursedescription { get; set; }

        [Required]
        public string courselink { get; set; }
    }
}
