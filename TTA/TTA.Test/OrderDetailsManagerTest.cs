using TTA.DataManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TTA.Model;
using System.Collections.Generic;

namespace TTA.Test
{
    
    
    /// <summary>
    ///This is a test class for OrderDetailsManagerTest and is intended
    ///to contain all OrderDetailsManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OrderDetailsManagerTest
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
        //
        #endregion


        /// <summary>
        ///A test for GetAllOrderDetails
        ///</summary>
        [TestMethod()]
        public void GetAllOrderDetailsTest()
        {
            OrderDetailsManager target = new OrderDetailsManager(); // TODO: Initialize to an appropriate value
            //List<OrderDetailsBE> expected = null; // TODO: Initialize to an appropriate value
            List<OrderDetailsBE> actual;
            actual = target.GetAllOrderDetails();
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetOrderDetailsByOrderId
        ///</summary>
        [TestMethod()]
        public void GetOrderDetailsByOrderIdTest()
        {
            OrderDetailsManager target = new OrderDetailsManager(); // TODO: Initialize to an appropriate value
            int orderId = 5; // TODO: Initialize to an appropriate value
            //List<OrderDetailsBE> expected = null; // TODO: Initialize to an appropriate value
            List<OrderDetailsBE> actual;
            actual = target.GetOrderDetailsByOrderId(orderId);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            OrderManager orderManager = new OrderManager(); // TODO: Initialize to an appropriate value
            OrderBE orderBE = new OrderBE() 
            {
                CreateTime = DateTime.Now,
                CustomerId = 1,
                OrderStatusId = 1,
                Customer = new CustomerBE()
                {
                    CustomerId = 1,
                    Address = new AddressBE()
                    {
                        AddressId = 1
                    }
                },
                OrderStatus = new OrderStatusBE()
                {
                    OrderStatusId = 1
                }
            }; // TODO: Initialize to an appropriate value  
            OrderBE order;
            order = orderManager.Insert(orderBE);
            OrderDetailsManager target = new OrderDetailsManager(); // TODO: Initialize to an appropriate value
            OrderDetailsBE orderdetailsBE = new OrderDetailsBE() 
            {
                OrderId = order.OrderId,
                ProductId = 1,
                Quantity = 0,
                TotalPrice = 0,
                IsDeleted = false
            }; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = !(target.Insert(orderdetailsBE));
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            OrderDetailsManager target = new OrderDetailsManager(); // TODO: Initialize to an appropriate value
            OrderDetailsBE orderdetailsBE = new OrderDetailsBE()
            {
                OrderDetailId = 204,
                OrderId = 110,
                ProductId = 1,
                Quantity = 1,
                TotalPrice = 5,
                IsDeleted = false
            };  // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = !(target.Update(orderdetailsBE));
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            OrderDetailsManager target = new OrderDetailsManager(); // TODO: Initialize to an appropriate value
            int id = 204; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = !(target.Delete(id));
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Close
        ///</summary>
        [TestMethod()]
        public void CloseTest()
        {
            OrderDetailsManager target = new OrderDetailsManager(); // TODO: Initialize to an appropriate value
            OrderDetailsBE odBE = new OrderDetailsBE(); // TODO: Initialize to an appropriate value
            odBE.OrderDetailId = 204;
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = !(target.Close(odBE));
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteOrderTest()
        {
            OrderManager target = new OrderManager(); // TODO: Initialize to an appropriate value
            int id = 110; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = !(target.Delete(id));
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OpenOrder
        ///</summary>
        [TestMethod()]
        public void OpenOrderTest()
        {
            OrderManager orderManager = new OrderManager(); // TODO: Initialize to an appropriate value
            int id = 110; // TODO: Initialize to an appropriate value
            OrderBE order;
            order = orderManager.GetById(id);
            OrderManager target = new OrderManager(); // TODO: Initialize to an appropriate value
            order.OrderStatusId = 1;
            order.OrderStatus.OrderStatusId = 1;
            order.OrderStatus.StatusName = "Open";
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = !(target.Update(order));
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
