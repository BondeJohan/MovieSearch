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

            int id = MovieByID.SearchForMovieByid();
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
                test.DisplayFoundMoive();
                ListOfMovies allmovies = JsonConvert.DeserializeObject<ListOfMovies>(searchResponeContent);
                Console.WriteLine(allmovies.results.Count);
                foreach (var item in allmovies.results)
                {
                    Console.WriteLine("{0}: {1}", allmovies.results.IndexOf(item), item.title);
                }

            }
            catch(HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
