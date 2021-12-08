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

            string uri = $"";

            var respone = await client.GetAsync(uri);
            respone.EnsureSuccessStatusCode();

            string responeContent = await respone.Content.ReadAsStringAsync();

            FindMovieByID test = JsonConvert.DeserializeObject<FindMovieByID>(responeContent);

            test.DisplayFoundMoive();
        }
    }
}
