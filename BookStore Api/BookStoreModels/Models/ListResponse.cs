using BookStoreModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModels.Models
{
    public class ListResponse<T> where T : class
    {
        public List<T> Records { get; set; }

        public int TotalRecords { get; set; }
    }
}
