using System.Data.Entity;
using SimpleContactsAPI.Models;

namespace SimpleContactsAPI.Tests
{
    public class TestSimpleContactsAPIContext : ISimpleContactsAPIContext
    {
        public TestSimpleContactsAPIContext()
        {
            this.Contacts = new TestContactDbSet();
        }

        public DbSet<Contact> Contacts { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Contact contact) { }
        public void Dispose() { }
    }
}