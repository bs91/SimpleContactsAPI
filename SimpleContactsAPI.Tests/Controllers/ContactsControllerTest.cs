using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleContactsAPI.Controllers;
using SimpleContactsAPI.Models;
using System.Web.Http.Results;
using System.Net;

namespace SimpleContactsAPI.Tests.Controllers
{
    [TestClass]
    public class ContactsControllerTest
    {
        [TestMethod]
        public void GetContacts_ShouldReturnAllContacts()
        {
            // Arrange
            var context = new TestMyContactsContext();
            context.Contacts.Add(new Contact { ID = 1, FirstName = "Blake", LastName = "Smith", Memo = "Self" });
            context.Contacts.Add(new Contact { ID = 2, FirstName = "Danielle", LastName = "Hildebrande", Memo = "Girlfriend" });
            context.Contacts.Add(new Contact { ID = 3, FirstName = "Kalon", LastName = "Hinds", Memo = "Friend" });

            var controller = new ContactsController(context);

            // Act
            IEnumerable<Contact> result = controller.GetContacts() as TestContactDbSet;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Blake", result.ElementAt(0).FirstName);
            Assert.AreEqual("Danielle", result.ElementAt(1).FirstName);
            Assert.AreEqual("Kalon", result.ElementAt(2).FirstName);
        }

        [TestMethod]
        public void GetContact_ShouldReturnContactById()
        {
            // Arrange
            var context = new TestMyContactsContext();
            context.Contacts.Add(new Contact { ID = 1, FirstName = "Blake", LastName = "Smith", Memo = "Self" });
            context.Contacts.Add(new Contact { ID = 2, FirstName = "Danielle", LastName = "Hildebrande", Memo = "Girlfriend" });
            context.Contacts.Add(new Contact { ID = 3, FirstName = "Kalon", LastName = "Hinds", Memo = "Friend" });

            var controller = new ContactsController(context);

            // Act
            var result = controller.GetContact(1) as OkNegotiatedContentResult<Contact>;

            // Assert
            Assert.AreEqual(1, result.Content.ID);
            Assert.AreEqual("Blake", result.Content.FirstName);
            Assert.AreEqual("Smith", result.Content.LastName);
            Assert.AreEqual("Self", result.Content.Memo);
        }

        [TestMethod]
        public void PostContact_ShouldReturnSameContact()
        {
            // Arrange
            var controller = new ContactsController(new TestMyContactsContext());
            Contact test = new Contact() { ID = 4, FirstName = "TestFirst", LastName = "TestLast", Memo = "TestMemo" };

            // Act
            var result = controller.PostContact(test) as CreatedAtRouteNegotiatedContentResult<Contact>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("DefaultApi", result.RouteName);
            Assert.AreEqual(4, result.Content.ID);
            Assert.AreEqual("TestFirst", result.Content.FirstName);
            Assert.AreEqual("TestLast", result.Content.LastName);
            Assert.AreEqual("TestMemo", result.Content.Memo);
        }

        [TestMethod]
        public void PutContact_ShouldReturnStatusCode()
        {
            // Arrange
            var context = new TestMyContactsContext();
            context.Contacts.Add(new Contact { ID = 1, FirstName = "Blake", LastName = "Smith", Memo = "Self" });
            context.Contacts.Add(new Contact { ID = 2, FirstName = "Danielle", LastName = "Hildebrande", Memo = "Girlfriend" });
            context.Contacts.Add(new Contact { ID = 3, FirstName = "Kalon", LastName = "Hinds", Memo = "Friend" });

            var controller = new ContactsController(context);
            Contact test = new Contact() { ID = 4, FirstName = "TestFirstNew", LastName = "TestLastNew", Memo = "TestMemoNew" };

            // Act
            var result = controller.PutContact(4, test) as StatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutContact_ShouldFail_WhenDifferentID()
        {
            // Arrange
            var controller = new ContactsController(new TestMyContactsContext());

            // Act
            var badresult = controller.PutContact(4, new Contact { ID = 1, FirstName = "Blake", LastName = "Smith", Memo = "Self" });

            // Assert
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }


        [TestMethod]
        public void DeleteContact_ShouldDeleteContactById()
        {
            // Arrange
            var context = new TestMyContactsContext();
            var contact = new Contact { ID = 1, FirstName = "Blake", LastName = "Smith", Memo = "Self" };
            context.Contacts.Add(contact);
            var controller = new ContactsController(context);

            // Act
            var result = controller.DeleteContact(1) as OkNegotiatedContentResult<Contact>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(contact.ID, result.Content.ID);
        }

    }
}