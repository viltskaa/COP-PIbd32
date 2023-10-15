using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDatabaseImplement.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
