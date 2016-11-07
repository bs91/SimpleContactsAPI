using System;
using System.Data.Entity;

namespace SimpleContactsAPI.Models
{
    public interface ISimpleContactsAPIContext : IDisposable
    {
        DbSet<Contact> Contacts { get; }
        int SaveChanges();
        void MarkAsModified(Contact item);
    }
}