using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo
{
    class Program
    {
        static void  Main(string[] args)
        {
            getmethodAsync().Wait(); 

        }

         static async Task getmethodAsync()
        {
            List<Person> peoples = new List<Person>();

            using (var client = new HttpClient())
            {
                //Sample API collection https://github.com/typicode/jsonplaceholder#how-to
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //GET Method  
                HttpResponseMessage response =   client.GetAsync("users").Result;

                if (response.IsSuccessStatusCode)
                {
                    //var a =  await response.Content.ReadAsStreamAsync();
                    peoples =  await response.Content.ReadAsAsync<List<Person>>();
                    foreach(var pop in peoples)
                    Console.WriteLine("Id:{0}\tName:{1}", pop.id, pop.name);
                    //Console.WriteLine("No of Employee in Department: {0}", department.Employees.Count);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            Console.ReadKey();
        }
    }
}
