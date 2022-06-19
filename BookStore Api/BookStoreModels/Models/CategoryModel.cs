using BookStoreModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModels.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CategoryModel() { }
        public CategoryModel(Category category)
        {
            Id = category.Id;    
            Name = category.Name;
        }
    }
}
