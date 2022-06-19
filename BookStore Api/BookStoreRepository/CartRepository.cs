using BookStoreModels.Models;
using BookStoreModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepository
{
    public class CartRepository: BaseRepository
    {
        public ListResponse<Cart> GetCart(int userId)
        {
            var query = _context.Carts.Where(c => c.Userid == userId);
            int totalRecords = query.Count();
            List<Cart> cart = query.ToList();

            foreach (Cart cartItem in cart)
            {
                cartItem.Book = _context.Books.FirstOrDefault(c => c.Id == cartItem.Bookid);
            }

            return new ListResponse<Cart>()
            {
                Records = cart,
                TotalRecords = totalRecords,
            };
        }

        public Cart AddItem(Cart cart)
        {
            var entry = _context.Carts.Add(cart);
            _context.SaveChanges();
            return entry.Entity;
        }
        public Cart UpdateItem(Cart cart)
        {
            var entry = _context.Carts.Update(cart);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Cart DeleteItem(int id)
        {
            var cartItem = _context.Carts.SingleOrDefault(c => c.Id == id);
            if (cartItem == null)
                return null;
            var entry = _context.Carts.Remove(cartItem);
            _context.SaveChanges();
            return entry.Entity;
        }
    }
}
