using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetCategory(int id);
        List<Category> GetCategoriesByName(string name);
        IEnumerable<Category> GetAllCategories(Company company);
        void AddCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int id);
    }
}
