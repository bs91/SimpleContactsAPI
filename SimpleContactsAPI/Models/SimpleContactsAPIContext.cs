using System.Data.Entity;

namespace SimpleContactsAPI.Models
{
    public class SimpleContactsAPIContext : DbContext, ISimpleContactsAPIContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public SimpleContactsAPIContext() : base("name=SimpleContactsAPIContext")
        {
        }

        public System.Data.Entity.DbSet<SimpleContactsAPI.Models.Contact> Contacts { get; set; }
        public void MarkAsModified(Contact item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}