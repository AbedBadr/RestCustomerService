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
            int expected = 4;

            // ACT
            List<Customer> cList = customerController.Get();

            // ASSERT
            Assert.AreEqual(expected, cList.Count);
            //Assert.AreEqual(CustomerController.cList, cList, "Are not equal");
        }

        [TestMethod]
        public void GetSpecificTest()
        {
            // ARRANGE
            CustomerController cc = new CustomerController();
            Customer expected = new Customer(1,"Navn", "Efternavn", 1996);

            // ACT
            cc.Get(1);

            // ASSERT

        }

        [TestMethod]
        public void GetNotExistingCustomer()
        {
            // ARRANGE
            CustomerController customerController = new CustomerController();

            // ACT
            Customer c = customerController.Get(15);

            // ASSERT
            Assert.IsNull(c);
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
            CustomerController cc = new CustomerController();
            Customer c = cc.Get(1);

            // ACT
            c.FirstName = c.FirstName + "A";

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
