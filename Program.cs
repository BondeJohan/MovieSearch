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
            bool runApp = true;

            while (runApp)
            {
                MainMenu();
            }

            /*
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
                foreach (var item in allmovies.Results)
                {
                    Console.WriteLine("{0}: {1}", allmovies.Results.IndexOf(item), item.Title);
                }

                Console.Write("Select ID: ");
                int testid = Convert.ToInt32(Console.ReadLine());
                int movieID = allmovies.Results[testid].Id;
                string testuri = $"https://api.themoviedb.org/3/movie/{movieID}?api_key={key}";
                var responeTest = await client.GetAsync(testuri);
                responeTest.EnsureSuccessStatusCode();
                string responeTestCon = await responeTest.Content.ReadAsStringAsync();
                MovieByID testThis = JsonConvert.DeserializeObject<MovieByID>(responeTestCon);
                testThis.DisplayFoundMoive();


            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            */

            void MainMenu()
            {
                Console.WriteLine("Movie Search!");
                Console.WriteLine("\n1. Search by movie ID.");
                Console.WriteLine("2. Search by movie title");
                Console.WriteLine("3. Quit Movie Search!");
                Console.Write("\nEnter number: ");

                if (int.TryParse(Console.ReadLine(), out int mainMenuChoice))
                {
                    switch (mainMenuChoice)
                    {
                        case 1:
                            Console.Clear();
                            SearchWithId();
                            break;
                        case 2:
                            break;
                        case 3:
                            runApp = QuitMovieSearch();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("That is not an option.\n");
                            return;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input.\n");
                }

            }

             async Task SearchWithId()
            {
                try 
                {                    
                    int id = MovieByID.SearchForMovieByid();
                    string uriID = $"https://api.themoviedb.org/3/movie/{id}?api_key={key}";
                    var respone = await client.GetAsync(uriID);
                    respone.EnsureSuccessStatusCode();
                    string responeContent = await respone.Content.ReadAsStringAsync();
                    MovieByID foundMovie = JsonConvert.DeserializeObject<MovieByID>(responeContent);
                    foundMovie.DisplayFoundMoive();
                    //SearchAgain();
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine("\nNo movie could be found.");
                }

            }

            void SearchAgain()
            {
                Console.WriteLine("\nDo you want to search for another movie?");
                Console.WriteLine("1. Yes.");
                Console.WriteLine("2. No.");
                if (int.TryParse(Console.ReadLine(), out int searchChoice))
                {
                    switch (searchChoice)
                    {
                        case 1:
                            MainMenu();
                            break;
                        case 2:
                            runApp = QuitMovieSearch();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input.\n");
                }
            }

            bool QuitMovieSearch()
            {
                bool StopApp = false;

                return StopApp;
            }
        }
    }
}
