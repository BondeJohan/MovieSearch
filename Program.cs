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
                            Console.Clear();
                            SearchWithTitle();
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
                    Console.WriteLine("Not correct input.\n");
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
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine("\nNo movie could be found.");
                }

            }

            async Task SearchWithTitle()
            {
                try
                {
                    string title = MovieByTitle.SearchMovieByTitle();
                    string uriTitle = $"https://api.themoviedb.org/3/search/movie?api_key={key}&query={title}";
                    var titleRespone = await client.GetAsync(uriTitle);
                    
                    titleRespone.EnsureSuccessStatusCode();
                    string titleResponeContent = await titleRespone.Content.ReadAsStringAsync();
                    
                    ListOfMovies allmovies = JsonConvert.DeserializeObject<ListOfMovies>(titleResponeContent);
                    
                    foreach (var item in allmovies.Results)
                    {
                        Console.WriteLine("\n{0}: {1}", allmovies.Results.IndexOf(item), item.Title);
                    }
                    
                    Console.Write("Select Index: ");
                    if(int.TryParse(Console.ReadLine(), out int indexID))
                    {
                        int movieID = allmovies.Results[indexID].Id;
                        string titleUri = $"https://api.themoviedb.org/3/movie/{movieID}?api_key={key}";
                        var movieIdRespone = await client.GetAsync(titleUri);
                        movieIdRespone.EnsureSuccessStatusCode();
                        string movieIdResponeContent = await movieIdRespone.Content.ReadAsStringAsync();
                        MovieByID movieByIndexID = JsonConvert.DeserializeObject<MovieByID>(movieIdResponeContent);
                        movieByIndexID.DisplayFoundMoive();
                    }
                    else
                    {
                        Console.WriteLine("Not correct Input");
                    }

                }
                catch (HttpRequestException)
                {
                    Console.WriteLine("\nNo movie could be found.");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
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
                    Console.WriteLine("Not correct Input.\n");
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
