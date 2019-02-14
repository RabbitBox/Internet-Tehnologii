using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldV1.Models
{
    public class Movie
    {
        public int Rank { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public Movie(int rank, string title, int year)
        {
            this.Rank = rank;
            this.Title = title;
            this.Year = year;
        }

    }
}