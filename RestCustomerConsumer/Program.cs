using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestCustomerConsumer
{
    class Program
    {
        private static string CustomersUri = "https://localhost:44329/api/customer/";
        static void Main(string[] args)
        {
            IList<Customer> cIList = GetCustomersAsync().Result;

            foreach (Customer customer in cIList)
            {
                Console.WriteLine(customer);
            }
        }

        public static async Task<IList<Customer>> GetCustomersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(CustomersUri);
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;
            }
        }

    }
}
