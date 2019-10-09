using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestCustomerConsumer
{
    class Program
    {
        private static string CustomersUri = "https://localhost:44329/api/customer/";
        static void Main(string[] args)
        {
            HttpRequests();

            Console.ReadKey();
        }

        public static async void HttpRequests()
        {
            Console.WriteLine("GET REQUEST");
            IList<Customer> cIList = GetCustomersAsync().Result;

            foreach (Customer customer in cIList)
            {
                Console.WriteLine(customer);
            }

            Console.WriteLine("GET SPECIFIC REQUEST");
            
            Customer getCustomer = GetCustomerAsync(1).Result;
            Console.WriteLine(getCustomer);

            Console.WriteLine("POST REQUEST");
            
            Customer postCustomer = new Customer(4, "GangLand", "Mahurti", 1995);
            await PostCustomerAsync(postCustomer);
            
            List<Customer> listAfterPost = (List<Customer>)GetCustomersAsync().Result;
            foreach (Customer customer in listAfterPost)
            {
                Console.WriteLine(customer);
            }

            Console.WriteLine("PUT REQUEST");

            Customer putCustomer = new Customer(2, "MAHURTI", "MAHURTI", 1997);
            await PutCustomerAsync(putCustomer);

            IList<Customer> listAfterPut = GetCustomersAsync().Result;
            foreach (Customer customer in listAfterPut)
            {
                Console.WriteLine(customer);
            }

            /*
            Console.WriteLine("DELETE REQUEST");

            await DeleteCustomerAsync(4);

            IList<Customer> listAfterDelete = GetCustomersAsync().Result;
            foreach (Customer customer in listAfterDelete)
            {
                Console.WriteLine(customer);
            }
            */
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

        public static async Task PostCustomerAsync(Customer customer)
        {
            using (HttpClient client = new HttpClient())
            {
                string body = JsonConvert.SerializeObject(customer);

                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PostAsync(CustomersUri, content);
            }
        }

        public static async Task PutCustomerAsync(Customer customer)
        {
            using (HttpClient client = new HttpClient())
            {
                string body = JsonConvert.SerializeObject(customer);

                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage result = await client.PutAsync(CustomersUri + customer.Id, content);
            }
        }

        public static async Task DeleteCustomerAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage result = await client.DeleteAsync(CustomersUri + id);
            }
        }
    }
}
