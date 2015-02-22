﻿using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shurly.Core.WebApi.Models;

namespace Shurly.Tests.ShurlyController
{
    /// <summary>
    /// Summary description for ShurlyControllerRegisterActionShould
    /// </summary>
    [TestClass]
    public class StatisticActionShould
    {
        public StatisticActionShould()
        {
            _shurlyController = new Web.Controllers.ShurlyController();
        }

        private TestContext _testContextInstance;
        private Web.Controllers.ShurlyController _shurlyController;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
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
        public void ReturnKeyValuePairCollection()
        {
            var mockAccountId = "TestAccountId";

            var mockAccountRequestBody = new Mock<IAccountRequestBody>();
            mockAccountRequestBody.Setup(x => x.AccountId).Returns(mockAccountId);
            _shurlyController.Account(mockAccountRequestBody.Object);

            var mockUrl = "http://facebook.com";
            var mockRegisterRequestBody = new Mock<IRegisterRequestBody>();
            mockRegisterRequestBody.Setup(x => x.Url).Returns(mockUrl);
            _shurlyController.Register(mockAccountId, mockRegisterRequestBody.Object);

            var httpActionResult = _shurlyController.Statistic(mockAccountId);

            OkNegotiatedContentResult<Dictionary<string, int>> negResult = httpActionResult as OkNegotiatedContentResult<Dictionary<string, int>>;
            Assert.IsNotNull(negResult);
            Assert.IsTrue(negResult.Content.Count > 0);
        }

    }
}
