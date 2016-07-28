using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Models;

namespace HRPortal.Data.DataRepositories
{
    public class CategoryInData : ICategoryRepository
    {
        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategoriesByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories(Company company)
        {
            throw new NotImplementedException();
        }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void EditCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
