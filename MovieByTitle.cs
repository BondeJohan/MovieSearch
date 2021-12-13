using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSearch
{
    class MovieByTitle
    {
        public static List<MovieByTitle> MovieList = new List<MovieByTitle>();
        public Result[] Results { get; set; }
        public int Total_Results { get; set; }


        public class Result
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
        public void SearchMovieByTitle()
        {

        }
        public void DisplayListOfMovies()
        {
            foreach (var movieFound in MovieList)
            {
                Console.WriteLine(movieFound.Total_Results);
                foreach (var item in MovieList[0].Results)
                {
                    Console.WriteLine("{0} {1}", item.Id, item.Title);
                }
            }
        }
    }
}
