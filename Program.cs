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

            while (true)
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
                            SearchWithId().Wait();
                            break;
                        case 2:
                            Console.Clear();
                            SearchWithTitle().Wait();
                            break;
                        case 3:
                            Environment.Exit(0);
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
                    Console.WriteLine("Not correct input.");
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
                    SearchAgain();
                }
                catch (HttpRequestException)
                {
                    Console.Clear();
                    Console.WriteLine("No movie could be found.");
                    SearchAgain();
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
                    Console.Clear();
                    Console.WriteLine("List of Movies:\n");
                    if (allmovies.Results.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("No movies found.");
                        SearchAgain();
                    }
                    foreach (var item in allmovies.Results)
                    {
                        Console.WriteLine("Index: {0}: {1}", allmovies.Results.IndexOf(item), item.Title);
                    }
                    
                    try
                    {
                        Console.Write("Select Index: ");
                        if (int.TryParse(Console.ReadLine(), out int indexID))
                        {
                            int movieID = allmovies.Results[indexID].Id;
                            string titleUri = $"https://api.themoviedb.org/3/movie/{movieID}?api_key={key}";
                            var movieIdRespone = await client.GetAsync(titleUri);
                            movieIdRespone.EnsureSuccessStatusCode();
                            string movieIdResponeContent = await movieIdRespone.Content.ReadAsStringAsync();
                            MovieByID movieByIndexID = JsonConvert.DeserializeObject<MovieByID>(movieIdResponeContent);
                            movieByIndexID.DisplayFoundMoive();
                            SearchAgain();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Not correct Input");
                            SearchAgain();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        SearchAgain();
                    }
                }
                catch (HttpRequestException)
                {
                    Console.Clear();
                    Console.WriteLine("\nNo movie could be found.");
                    SearchAgain();
                }
 
            }

            void SearchAgain()
            {
                Console.WriteLine("\nDo you want to search for another movie?");
                Console.WriteLine("1. Yes.");
                Console.WriteLine("2. No.");
                Console.Write("Enter a number: ");
                if (int.TryParse(Console.ReadLine(), out int searchChoice))
                {
                    switch (searchChoice)
                    {
                        case 1:
                            Console.Clear();
                            MainMenu();
                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not correct Input.\n");
                }
            }
        }
    }
}
