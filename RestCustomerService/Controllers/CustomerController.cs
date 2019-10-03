using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestCustomerService.Model;

namespace RestCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public static int NextId = 0;

        public static List<Customer> cList = new List<Customer>()
        {
            new Customer(NextId++, "John", "Doe", 2015),
            new Customer(NextId++, "Maher", "Khachehan", 2000),
            new Customer(NextId++, "Pasoon", "Ilham", 2005)
        };

        // GET: api/Customer
        [HttpGet]
        public List<Customer> Get()  // or public IEnumerable<string> Get()
        {
            return cList;
        }


        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public Customer Get(int id)
        {
            foreach (Customer customer in cList)
            {
                if (customer.Id == id)
                    return customer;
            }

            return null;
        }

        // POST: api/Customer
        [HttpPost("Ins", Name = "Ins")]
        public void InsertCustomer([FromBody] Customer c)
        {
            cList.Add(c);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}", Name = "Upd")]
        public void UpdateCustomer(int id,[FromBody] Customer c)
        {
            //cList[id] = c;
            foreach (Customer customer in cList)
            {
                if (customer.Id == id)
                {
                    int index = cList.IndexOf(customer);
                    cList[index] = c;
                }
            }
        }

        // DELETE: 
        [HttpDelete("{id}", Name = "Del")]
        public void DeleteCustomer(int id)
        {
            //cList.RemoveAt(id);
            foreach (Customer customer in cList)
            {
                if (customer.Id == id)
                {
                    int index = cList.IndexOf(customer);
                    cList.RemoveAt(index);
                }
            }
        }
    }
}
