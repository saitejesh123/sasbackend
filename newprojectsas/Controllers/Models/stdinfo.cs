using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace newprojectsas.Controllers.Models
{
    public class stdinfo
    {

        [Required]
        [Key]

        public int stdid { get; set; }

        [Required]
        public string stdname { get; set; }


        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string address { get; set; }


        [Required]


        public string phoneno { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string email { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string password { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        [Compare("password", ErrorMessage = "this is same as password")]
        public string confirm_password { get; set; }

        [MinLength(2)]
        [MaxLength(255)]
        public string usertype { get; set; }


    }
}
