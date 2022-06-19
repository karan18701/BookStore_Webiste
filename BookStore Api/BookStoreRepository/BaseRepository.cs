using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreModels.ViewModels;
using BookStoreModels.Models;

namespace BookStoreRepository
{
    public class BaseRepository
    {
        protected readonly BookStoreContext _context = new BookStoreContext();
    }
}
