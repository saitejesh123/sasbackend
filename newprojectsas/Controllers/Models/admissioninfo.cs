using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace newprojectsas.Controllers.Models
{
    public class admissioninfo
    {

        [Required]
        [Key]

        public int addid { get; set; }





        public int stdid { get; set; }
        public virtual stdinfo stdinfo { get; set; }

        public string stdname { get; set; }



        [ForeignKey("course")]

        public int courseid { get; set; }
        public virtual course course { get; set; }

        public string coursename { get; set; }  
    }
}
