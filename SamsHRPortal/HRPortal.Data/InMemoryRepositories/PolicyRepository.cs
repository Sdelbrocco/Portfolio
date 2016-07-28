using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Models;

namespace HRPortal.Data.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private static List<Policy> _policies;

        static PolicyRepository()
        {
            _policies = new List<Policy>
            {
                new Policy {Id = 1, PolicyName = "Equal Opportunity"},
                new Policy {Id = 2, PolicyName = "Attendance and Time Off"},
                new Policy {Id = 3, PolicyName = "Substance Abuse"}
            };
        }

        public Policy GetPolicy(int id)
        {
            return _policies.FirstOrDefault(p => p.Id == id);
        }

        public List<Policy> GetPolicyByCategory(Category category)
        {
            return _policies.FindAll(p => p.PolicyName == category.Id.ToString());
        }

        public IEnumerable<Policy> GetAllPolicies()
        {
            return _policies;
        }
    }
}
