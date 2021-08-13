using EBS.Business;
using EBS.Entities.BaseEntities;
using EBS.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EBS.Tests
{
    /// <summary>
    /// Summary description for UserTest
    /// </summary>
    [TestClass]
    public class UserTest
    {
        public UserTest()
        {
            ConfigurationHelper.SetConnectionString();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Insert()
        {
            // Arrange
            int ret;
            string name = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            Random rand = new Random();

            var user = new User()
                        {
                            Email = string.Format("{0}@somedomain.com", name),
                            Password = Guid.NewGuid().ToString(),
                            Type = rand.Next(1, 5),
                            FirstName = "User",
                            LastName = name,
                            UpdatedBy = 1
                        };


            // Act
            ret = BusinessFactory.UserBusiness.Insert(user);

            // Assert
            Assert.IsNotNull(ret);
            Assert.AreEqual(1, ret);
        }

        [TestMethod]
        public void GetAll()
        {
            // Arrange
            List<User> users;

            // Act
            users = BusinessFactory.UserBusiness.GetAll();

            // Assert
            Assert.AreEqual(1, users[0].UserId);
        }
    }
}
