using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data.Interfaces
{
    public interface IPolicyRepository
    {
        Policy GetPolicy(int id);
        List<Policy> GetPolicyByCategory(Category category);
        IEnumerable<Policy> GetAllPolicies();
    }
}
