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
        public static List<Customer> cList = new List<Customer>();
        public static int nextid = 0;

        // GET: api/Customer
        [HttpGet]
        public List<Customer> Get()  // or public IEnumerable<string> Get()
        {
            return cList;
        }


        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // POST: api/Customer
        [HttpPost("Ins", Name = "Ins")]
        public void InsertCustomer(Customer c)
        {

        }

        // PUT: api/Customer/5
        [HttpPut("{id}", Name = "Upd")]
        public void UpdateCustomer(int id, Customer c)
        {

        }

        // DELETE: 
        [HttpDelete("{id}", Name = "Del")]
        public void DeleteCustomer(int id)
        {

        }
    }
}
