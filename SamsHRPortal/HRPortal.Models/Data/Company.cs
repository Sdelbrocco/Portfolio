using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class Company
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter a company name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please enter a job description")]
        public string Description { get; set; }

        public List<Job> Jobs { get; set; }

        public Company()
        {
            this.Jobs = Jobs;
        }
    }
}
