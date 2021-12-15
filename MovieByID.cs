using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieSearch
{
    class MovieByID
    {
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Original_Language { get; set; }
        public int Runtime { get; set; }
        public string Release_Date { get; set; }
        public double Vote_Average { get; set; }
        public string HomePage { get; set; }
        public string Poster_Path { get; set; }

        public static int SearchForMovieByid()
        {
            while (true)
            {
                Console.Write("Enter Id for a movie: ");
                if (int.TryParse(Console.ReadLine(), out int movieID))
                {
                    return movieID;
                }
                else
                {
                    Console.WriteLine("Invalid Inpput");
                }
            }
        }

        public void DisplayFoundMoive()
        {
            Console.Clear();
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("\nDescription: {0}", Overview);
            Console.WriteLine("\nLanguage: {0}", Original_Language.ToUpper());
            Console.WriteLine("Runtime: {0} min", Runtime);
            Console.WriteLine("Release date: {0}", Release_Date);
            Console.WriteLine("Avreage Vote: {0}", Vote_Average);
            Console.WriteLine("Homepage: {0}", HomePage);
            Console.WriteLine($"Poster: https://image.tmdb.org/t/p/w500{Poster_Path}");
        }
    }

}
