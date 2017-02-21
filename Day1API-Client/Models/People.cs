using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Day1API_Client.Models
{
    class People
    {
        //Property name MUST match api property (case-sensitive in JS and Python)
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public Uri Homeworld { get; set; }

        public Planet HomeworldDetail (HttpClient client)
        {
            var response = client.GetAsync(Homeworld).Result;
            Planet homeWorld = response.Content.ReadAsAsync<Planet>().Result;
            
            return homeWorld;
        }
    }

    class PeopleCollection
    {
        //When getting a collection of results from the api
        public string Count { get; set; }
        public Uri Next { get; set; }
        public Uri Previous { get; set; }
        public List<People> Results { get; set; }               

        public PeopleCollection GetPrevious(HttpClient client)
        {
            return GetPage(client, Previous);
        }

        public PeopleCollection GetNext(HttpClient client)
        {
            return GetPage(client, Next);
        }

        private PeopleCollection GetPage(HttpClient client, Uri page)
        {
            

            if (page != null)
            {
                string pageNum = page.Query; //Gets the query from the Uri
                var allPeopleResponse = client.GetAsync($"people{pageNum}").Result;
                return allPeopleResponse.Content.ReadAsAsync<PeopleCollection>().Result;
            }
            return this;
        }

    }
}
