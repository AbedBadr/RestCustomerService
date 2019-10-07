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

            Console.WriteLine();
            
            Customer getCustomer = GetCustomerAsync(1).Result;
            Console.WriteLine(getCustomer);
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

        public static async Task<Customer> GetCustomerAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(CustomersUri + id);
                Customer customer = JsonConvert.DeserializeObject<Customer>(content);
                return customer;
            }
        }

        public static async void PostCustomerAsync(Customer customer)
        {
            using (HttpClient client = new HttpClient())
            {
            }
        }
    }
}
