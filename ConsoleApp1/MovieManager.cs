using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1
{
    public class MovieManager
    {
        private List<Movie> _movies;
        private const string FilePath = "movies.json"; // Назва файлу бази даних

        public MovieManager()
        {
            _movies = new List<Movie>();
            LoadFromFile(); // Автоматично завантажуємо дані при запуску програми
        }

        public void AddMovie(Movie movie)
        {
            int nextId = _movies.Count > 0 ? _movies.Max(m => m.Id) + 1 : 1;
            movie.Id = nextId;

            _movies.Add(movie);
            Console.WriteLine($"\nУспіх! Фільм '{movie.Title}' успішно додано під номером {movie.Id}.");
            
            SaveToFile(); // Зберігаємо зміни у файл
        }

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

        public void RemoveMovie(int id)
        {
            var movieToRemove = _movies.FirstOrDefault(m => m.Id == id);

            if (movieToRemove != null)
            {
                _movies.Remove(movieToRemove);
                Console.WriteLine($"\nФільм '{movieToRemove.Title}' успішно видалено.");
                
                SaveToFile(); // Зберігаємо зміни у файл
            }
            else
            {
                Console.WriteLine($"\nПомилка: Фільм з ID '{id}' не знайдено.");
            }
        }

        // МЕТОД ЗБЕРЕЖЕННЯ
        public void SaveToFile()
        {
            // Налаштування, щоб JSON файл був красиво відформатований (з відступами)
            var options = new JsonSerializerOptions { WriteIndented = true };
            
            // Перетворюємо наш список у текст формату JSON
            string jsonString = JsonSerializer.Serialize(_movies, options);
            
            // Записуємо текст у файл (якщо файлу немає - він створиться автоматично)
            File.WriteAllText(FilePath, jsonString);
        }

        // МЕТОД ЗАВАНТАЖЕННЯ
        private void LoadFromFile()
        {
            // Перевіряємо, чи взагалі існує такий файл у папці
            if (File.Exists(FilePath))
            {
                // Зчитуємо весь текст з файлу
                string jsonString = File.ReadAllText(FilePath);
                
                // Перетворюємо текст назад у список об'єктів
                _movies = JsonSerializer.Deserialize<List<Movie>>(jsonString) ?? new List<Movie>();
            }
        }
    }
}
