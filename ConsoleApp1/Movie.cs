using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }

        // Конструктор для зручного створення фільму
        public Movie(string title, int year, string genre, int rating)
        {
            Title = title;
            Year = year;
            Genre = genre;
            Rating = rating;
        }


        public Movie() { }

        
        public override string ToString()
        {
            return $"[{Id}] {Title} ({Year}) - {Genre} | Оцінка: {Rating}/10";
        }
    }
}
