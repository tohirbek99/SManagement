using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SManagement.Models
{
    public class Staf
    {
        
        public int Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(30)]
        public string LastName { get; set; }
       
        [Required]
        [Display(Name = "Email")]
        [MaxLength(50)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Department")]
        public Departments? Department { get; set; }
        
        public string PhotoFillPath { get; set; }
    }
}
