using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreModels.Models;
using BookStoreModels.ViewModels;

namespace BookStoreRepository
{
    public class CategoryRepository : BaseRepository
    {
        public ListResponse<Category> GetCategories(int pageIndex, int pageSize, string? keyword)
        {
            keyword = keyword?.ToLower()?.Trim();

            var query = _context.Categories.Where(c => keyword == null || c.Name.ToLower().Contains(keyword));

            int totalRecords = query.Count();

            List<Category> categories = query.Skip((pageIndex) * pageSize).Take(pageSize).ToList();

            return new ListResponse<Category>()
            {
                Records = categories,
                TotalRecords = totalRecords
            };
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.SingleOrDefault(c => c.Id == id);
        }

        public Category AddCategory(Category category)
        {
            var entry = _context.Categories.Add(category);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Category UpdateCategory(Category category)
        {
            var entry = _context.Categories.Update(category);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeleteCategory(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null)
                return false;
            var entry = _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }
    }
}
