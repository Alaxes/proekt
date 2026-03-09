using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MovieManager
    {
        // Наша "база даних" у пам'яті
        private List<Movie> _movies;

        public MovieManager()
        {
            _movies = new List<Movie>();
        }

        // CREATE: Додавання фільму
        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
            Console.WriteLine($"\nУспіх! Фільм '{movie.Title}' успішно додано.");
        }

        // READ: Отримання всіх фільмів
        public void ShowAllMovies()
        {
            if (_movies.Count == 0)
            {
                Console.WriteLine("\nСписок фільмів порожній.");
                return;
            }

            Console.WriteLine("\n--- Ваш список фільмів ---");
            foreach (var movie in _movies)
            {
                Console.WriteLine(movie.ToString());
            }
            Console.WriteLine("--------------------------");
        }

        // DELETE: Видалення фільму за початком ID
        public void RemoveMovie(string idSubstring)
        {
            // Шукаємо фільм, ID якого починається на введений рядок
            var movieToRemove = _movies.FirstOrDefault(m => m.Id.ToString().StartsWith(idSubstring));

            if (movieToRemove != null)
            {
                _movies.Remove(movieToRemove);
                Console.WriteLine($"\nФільм '{movieToRemove.Title}' успішно видалено.");
            }
            else
            {
                Console.WriteLine($"\nПомилка: Фільм з ID '{idSubstring}' не знайдено.");
            }
        }
    }
}
