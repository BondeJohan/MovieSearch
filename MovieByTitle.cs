using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSearch
{
    class MovieByTitle
    {
        public Result[] Results { get; set; }

        public class Result
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }

        public static string SearchMovieByTitle()
        {            
            Console.Write("Enter search words: ");
            string search = Console.ReadLine();
            return search;
        }

    }
}
