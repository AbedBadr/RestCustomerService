using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestCustomerService.Controllers;
using RestCustomerService.Model;

namespace RestCustomerServiceTest
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void GetTest()
        {
            // ARRANGE
            CustomerController customerController = new CustomerController();

            // ACT
            List<Customer> cList = customerController.Get();

            // ASSERT
            //Assert.AreEqual(CustomerController.cList, cList, "Are not equal");
        }

        [TestMethod]
        public void GetSpecificTest()
        {
            // ARRANGE
            CustomerController cc = new CustomerController();

            // ACT
            cc.Get(1);

            // ASSERT

        }

        [TestMethod]
        public void PostTest()
        {
            // ARRANGE

            // ACT

            // ASSERT

        }

        [TestMethod]
        public void PutTest()
        {
            // ARRANGE

            // ACT

            // ASSERT

        }

        [TestMethod]
        public void DeleteTest()
        {
            // ARRANGE

            // ACT

            // ASSERT

        }
    }
}
