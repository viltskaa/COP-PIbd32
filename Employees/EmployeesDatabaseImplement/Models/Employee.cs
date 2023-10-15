﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDatabaseImplement.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Autobiography { get; set; }
        [Required]
        public string Post { get; set; }

        public DateTime Upgrade { get; set; }

    }
}
