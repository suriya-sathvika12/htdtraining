using System.Data.Entity;

namespace ContactApp.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("ContactDbConnection") { }

        public DbSet<Contact> Contacts { get; set; }
    }
}