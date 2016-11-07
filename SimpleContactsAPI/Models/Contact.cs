using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleContactsAPI.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Memo { get; set; }

        public static explicit operator Contact(Task<IHttpActionResult> v)
        {
            throw new NotImplementedException();
        }
    }
}