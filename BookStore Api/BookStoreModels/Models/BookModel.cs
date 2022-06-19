using BookStoreModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModels.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Base64image { get; set; }
        public int CategoryId { get; set; }
        public int? PublisherId { get; set; }
        public int? Quantity { get; set; }

        public string? Category { get; set; }
        public BookModel() { }
        public BookModel(Book book)
        {
            this.Id = book.Id;
            this.Name = book.Name;
            this.Price = book.Price;
            this.Description = book.Description;
            this.Base64image = book.Base64image;
            this.CategoryId = book.Categoryid;
            this.PublisherId = book.Publisherid;
            this.Quantity = book.Quantity;
            this.Category = " ";
        }
    }
}
