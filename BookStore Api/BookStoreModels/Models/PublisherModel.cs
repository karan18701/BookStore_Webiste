using BookStoreModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreModels.Models
{
    public class PublisherModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }

        public PublisherModel() { }
        public PublisherModel(Publisher publisher)
        {
            this.Id = publisher.Id;
            this.Name = publisher.Name;
            this.Address = publisher.Address;
            this.Contact = publisher.Contact;
        }
    }
}
