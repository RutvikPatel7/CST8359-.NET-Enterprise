using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class Person
    {
        [Required]
        public string FirstName
        {
            get; set;
        }
        
        [Required]
        public string LastName
        {
            get; set;
        }

        [Required]
        public int Age
        {
            get; set;
        }
        
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string EmailAddress
        {
            get; set;
        }
        
        [Required]
        [DataType(DataType.Date)]
     /*   [DisplayFormat(DataFormatString = "{mm/dd/yyyy}")]*/
        public string DOB
        {
            get; set;
        }
        
        [Required]
        [StringLength(100)]
        public string Password
        {
            get; set;
        }
        
        [Required]
        public string Description
        {
            get; set;
        }

        [Required]
        public int bottle
        {
            get; set;
        }
    }
}
