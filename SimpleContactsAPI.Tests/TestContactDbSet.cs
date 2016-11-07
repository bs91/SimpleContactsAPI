using System.Linq;
using SimpleContactsAPI.Models;

namespace SimpleContactsAPI.Tests
{
    class TestContactDbSet : TestDbSet<Contact>
    {
        public override Contact Find(params object[] keyValues)
        {
            return this.SingleOrDefault(contact => contact.ID == (int)keyValues.Single());
        }
    }
}