using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRPortal.Models
{
    public class Job
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Please choose a company")]
        public int CompanyId { get; set; }
        [Required]
        public JobStatus Status{ get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }

        public Company Company { get; set; }
        public List<Application> Applications { get; set; }


        public Job()
        {
            this.Company = new Company();
            this.Applications = new List<Application>();
        }
    }
}
