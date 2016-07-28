using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HRPortal.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Please enter your education history")]
        public string Education { get; set; }

        [Required(ErrorMessage = "Please enter your salary requirements")]
        public string Salary { get; set; }

        [Required(ErrorMessage = "Please enter your past work experiences")]
        public string WorkHistory { get; set; }

        public Person Person { get; set; }

        public Application()
        {
            this.Person = Person;
        }

        public override string ToString()
        {
            return $"{Id},{JobId},{PersonId},\"{Education}\",\"{Salary}\",\"{WorkHistory}\"";
        }

        public void FromCSV(string input)
        {
            Regex regEx = new Regex("");
            var fields = regEx.Match(input);
            Id = int.Parse(fields.Groups[0].Value);
            JobId = int.Parse(fields.Groups[1].Value);
            PersonId = int.Parse(fields.Groups[2].Value);
            Education = fields.Groups[3].Value;
            Salary = fields.Groups[4].Value;
            WorkHistory = fields.Groups[5].Value;

        }
    }
}
