using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IdentityDay.Services;
using IdentityDay.Controllers;
using IdentityDay.Models;
using Moq;
using System.Linq;
using System.Web.Mvc;

namespace IdentityDayTest.Test
{
    [TestClass]
    public class AccountServicesTest
    {
        [TestMethod]
        public void ListUsers()
        {
            //Arrange
            var users = new List<ApplicationUser>
            {
                new ApplicationUser {FirstName = "John", LastName ="Dianala" },
                new ApplicationUser {FirstName = "Joleo", LastName ="Dianala" }

            };

            var mocRepo = new Mock<IRepository>();
            mocRepo.Setup(Mock => Mock.Query<ApplicationUser>()).Returns(users.AsQueryable());
            ManageUsersController myController = new ManageUsersController();

            //Act
            var results = myController.Index() as ViewResult;
            var model = results.Model as IList<ApplicationUser>;           

            // Assert
            Assert.AreEqual("John", model.First().UserName);
        }
    }
}
