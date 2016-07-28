using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Policy> Policies { get; set; }

        public Category()
        {
            this.Policies = Policies;
        }
    }
}
