using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Models;

namespace HRPortal.Data.DataRepositories
{
    public class PolicyInData : IPolicyRepository
    {
        public Policy GetPolicy(int id)
        {
            throw new NotImplementedException();
        }

        public List<Policy> GetPolicyByCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Policy> GetAllPolicies()
        {
            throw new NotImplementedException();
        }
    }
}
