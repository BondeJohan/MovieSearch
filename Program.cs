//Johan Andersson 2021-12-07

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieSearch
{
    class Program
    {
        public static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            DotNetEnv.Env.TraversePath().Load();
            string key = Environment.GetEnvironmentVariable("API_KEY");

            int id = 100;
            string title = "Deadpool";

            string uriID = $"https://api.themoviedb.org/3/movie/{id}?api_key={key}";

            string search = $"https://api.themoviedb.org/3/search/movie?api_key={key}&query={title}";

            var respone = await client.GetAsync(uriID);
            respone.EnsureSuccessStatusCode();
            
            var searchRespone = await client.GetAsync(search);
            respone.EnsureSuccessStatusCode();

            string responeContent = await respone.Content.ReadAsStringAsync();
            string searchResponeContent = await searchRespone.Content.ReadAsStringAsync();

            FindMovieByID test = JsonConvert.DeserializeObject<FindMovieByID>(responeContent);

            test.DisplayFoundMoive();
        }
    }
}
