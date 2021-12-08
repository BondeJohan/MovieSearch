using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSearch
{
    class FindMovieByID
    {
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Original_Language { get; set; }
        public int RunTime { get; set; }
        public string Release_Date { get; set; }
        public Genre[] Genres { get; set; }
        public double Vote_Average { get; set; }
        public string HomePage { get; set; }
        public string Poster_Path { get; set; }
        public class Genre
        {
            public string Name { get; set; }
        }

        public void SearchForMoiveByid()
        {

        }
        public void DisplayFoundMoive() 
        {
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("\nDescreption: {0}", Overview);
            Console.WriteLine("\nLanguage: {0}", Original_Language);
            Console.WriteLine("Runtime: {0} min", RunTime);
            Console.WriteLine("Release date: {0}", Release_Date);
            ShowAllGenres();
            Console.WriteLine("Avreage Vote: {0}", Vote_Average);
            Console.WriteLine("Homepage: {0}", HomePage);
            Console.WriteLine("Poster adress: {0}", Poster_Path);
        }
        public void ShowAllGenres()
        {
            foreach (var genre in Genres)
            {
                Console.WriteLine(genre.Name);
            }
        }
    }

}
