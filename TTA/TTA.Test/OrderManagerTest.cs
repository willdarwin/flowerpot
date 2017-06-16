using TTA.DataManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TTA.DataEntity;
using System.Collections.Generic;

namespace TTA.Test
{
    
    
    /// <summary>
    ///This is a test class for OrderManagerTest and is intended
    ///to contain all OrderManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OrderManagerTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
       
        #endregion


        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            //OrderManager target = new OrderManager(); // TODO: Initialize to an appropriate value
            //TrainingProject1_Dev_1Entities dBentity = new TrainingProject1_Dev_1Entities(); // TODO: Initialize to an appropriate value
            //Order order = new Order();
            //order.StatusId = 1;
            //order.CreatedDate = DateTime.Now;
            //order.CustomerId = 1;

            ////order.Customer = new Customer() { CustomerId = 1 };// TODO: Initialize to an appropriate value
            ////order.Customer.Address = new Address();
            
           
            ////order.OrderStatus = new OrderStatus() { StatusId = 1 };
            //Order expected = null; // TODO: Initialize to an appropriate value
            //Order actual;
            //actual = target.Insert(dBentity, order);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            //OrderManager target = new OrderManager(); // TODO: Initialize to an appropriate value
            //TrainingProject1_Dev_1Entities dBEntity = null; // TODO: Initialize to an appropriate value
            //Order order = null; // TODO: Initialize to an appropriate value
            //bool expected = false; // TODO: Initialize to an appropriate value
            //bool actual;
            //actual = target.Update(dBEntity, order);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetByCondition
        ///</summary>
        [TestMethod()]
        public void GetByConditionTest()
        {
            //OrderManager target = new OrderManager(); // TODO: Initialize to an appropriate value
            //string name = "ad"; // TODO: Initialize to an appropriate value
            //string date = "2012-08-04"; // TODO: Initialize to an appropriate value
            ////string date = null;
            //string compare = ">="; // TODO: Initialize to an appropriate value
            //List<Order> expected = null; // TODO: Initialize to an appropriate value
            //List<Order> actual;
            //TrainingProject1_Dev_1Entities dBEntity = new TrainingProject1_Dev_1Entities();
            //actual = target.GetByCondition(dBEntity,name, date, compare);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetById
        ///</summary>
        [TestMethod()]
        public void GetByIdTest()
        {
            //OrderManager target = new OrderManager(); // TODO: Initialize to an appropriate value
            //TrainingProject1_Dev_1Entities dBEntity = null; // TODO: Initialize to an appropriate value
            //int id = 0; // TODO: Initialize to an appropriate value
            //Order expected = null; // TODO: Initialize to an appropriate value
            //Order actual;
            //actual = target.GetById(dBEntity, id);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Close
        ///</summary>
        [TestMethod()]
        public void CloseTest()
        {
            OrderManager target = new OrderManager(); // TODO: Initialize to an appropriate value
            TTAEntityContainer dBEntity = new TTAEntityContainer(); // TODO: Initialize to an appropriate value
            int id = 1; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Close(dBEntity, id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            OrderManager target = new OrderManager(); // TODO: Initialize to an appropriate value
            TTAEntityContainer dBEntity = new TTAEntityContainer(); // TODO: Initialize to an appropriate value
            int id = 1; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Delete(dBEntity, id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
