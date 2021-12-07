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
            string uri = @"";

            var respone = await client.GetAsync(uri);
            respone.EnsureSuccessStatusCode();

            string responeContent = await respone.Content.ReadAsStringAsync();

            FindMoiveByID test = JsonConvert.DeserializeObject<FindMoiveByID>(responeContent);

            test.DisplayFoundMoive();
        }
    }
}
