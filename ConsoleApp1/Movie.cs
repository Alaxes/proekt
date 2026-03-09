using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Movie
    {
        // Унікальний ідентифікатор, генерується автоматично при створенні
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; } // Оцінка від 1 до 10

        // Конструктор для зручного створення фільму
        public Movie(string title, int year, string genre, int rating)
        {
            Title = title;
            Year = year;
            Genre = genre;
            Rating = rating;
        }

        // Порожній конструктор потрібен для майбутнього JSON-збереження
        public Movie() { }

        // Перевизначаємо метод ToString() для красивого виводу в консоль
        public override string ToString()
        {
            return $"[{Id.ToString().Substring(0, 8)}] {Title} ({Year}) - {Genre} | Оцінка: {Rating}/10";
        }
    }
}
