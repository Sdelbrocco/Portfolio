using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Models;

namespace HRPortal.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private static List<Category> _categories;

        static CategoryRepository()
        {
            _categories = new List<Category>
            {
                new Category { Id = 1, Name = "Marketing"},
                new Category { Id = 2, Name = "IT"},
                new Category { Id = 3, Name = "Software"},
                new Category { Id = 4, Name = "Advertising"}
            };
        }

        public Category GetCategory(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public List<Category> GetCategoriesByName(string name)
        {
            return _categories.FindAll(c => c.Name == name);
        }

        public IEnumerable<Category> GetAllCategories(Company company)
        {
            return _categories;
        }

        public void AddCategory(Category newcategory)
        {
            newcategory.Id = GetNextID();
            _categories.Add(newcategory);
        }

        public void EditCategory(Category category)
        {
            var selectedApp = _categories.First(a => a.Id == category.Id);

            selectedApp.Name = category.Name;
            selectedApp.Policies = category.Policies;
        }

        public void DeleteCategory(int id)
        {
            _categories.Remove(_categories.FirstOrDefault(c => c.Id == id));
        }

        private int GetNextID()
        {
            if (_categories.Count == 0)
            {
                return 1;
            }
            int id = _categories.First(x => x.Id == _categories.Max(n => n.Id)).Id;
            return ++id;
        }
    }
}
