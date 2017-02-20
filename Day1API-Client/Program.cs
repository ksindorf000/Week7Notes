using Day1API_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Day1API_Client
{
    class Program
    {
        //Create Access to Client
        private static HttpClient client = new HttpClient();

        /*****************************
         * Boilerplate set-up
         ****************************/
        private static void SetUpClient()
        {            
            client.DefaultRequestHeaders.Accept.Clear();
            
            //client.D...R...Headers.[Name of Header].Add(type of data to return)
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Uri to access API
            client.BaseAddress = new Uri("https://swapi.co/api/");
        }

        /*****************************
         * Main()
         ****************************/
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Star Wars API!");
            SetUpClient();

            //Make request to the api
            var response = client.GetAsync("people/1").Result;

            //Bring data back as string
            /*var luke = response.Content.ReadAsStringAsync().Result;*/

            //Bring data in as Model Type
            People luke = response.Content.ReadAsAsync<People>().Result;

            var allPeopleResponse = client.GetAsync("people").Result;
            PeopleCollection allPeeps = allPeopleResponse.Content.ReadAsAsync<PeopleCollection>().Result;
            var lukeHomeWorld = luke.HomeworldDetail(client);

            Console.WriteLine(luke.Name + " : " + lukeHomeWorld.Name);


            //allPeeps.GetNext(client);
        }

        /**
         * GetPerson()
         **/

        /**
         * GetHomeworldByPerson()
         **/

        /**
         * GetFilmsByPerson()
         **/
    }
}
