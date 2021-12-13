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
        public virtual System.Net.HttpStatusCode StatusCode { get; }
        static async Task Main(string[] args)
        {
            DotNetEnv.Env.TraversePath().Load();
            string key = Environment.GetEnvironmentVariable("API_KEY");

            int id = 550;
            string title = "Fight Club";

            string uriID = $"https://api.themoviedb.org/3/movie/{id}?api_key={key}";

            string search = $"https://api.themoviedb.org/3/search/movie?api_key={key}&query={title}";

            var respone = await client.GetAsync(uriID);
            var searchRespone = await client.GetAsync(search);
            try
            {
                respone.EnsureSuccessStatusCode();
                searchRespone.EnsureSuccessStatusCode();
                string responeContent = await respone.Content.ReadAsStringAsync();
                string searchResponeContent = await searchRespone.Content.ReadAsStringAsync();
                MovieByID test = JsonConvert.DeserializeObject<MovieByID>(responeContent);
                MovieByTitle test2 = JsonConvert.DeserializeObject<MovieByTitle>(searchResponeContent);
                MovieByTitle.MovieList.Add(test2);
                test.DisplayFoundMoive();
                test2.DisplayListOfMovies();
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
