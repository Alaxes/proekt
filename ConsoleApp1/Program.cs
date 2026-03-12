using System;
using ConsoleApp1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            MovieManager manager = new MovieManager();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n=== Менеджер списку фільмів ===");
                Console.WriteLine("1. Показати всі фільми");
                Console.WriteLine("2. Додати фільм");
                Console.WriteLine("3. Видалити фільм");
                Console.WriteLine("4. Вийти");
                Console.Write("Оберіть дію (1-4): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.ShowAllMovies();
                        break;
                    case "2":
                        AddMovieUI(manager);
                        break;
                    case "3":
                        RemoveMovieUI(manager);
                        break;
                    case "4":
                        manager.SaveToFile();
                        Console.WriteLine("Збереженно! Вихід з програми...");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Помилка: Невідома команда. Введіть число від 1 до 4.");
                        break;
                }
            }
        }

        // Метод для збору даних з консолі при додаванні фільму
        static void AddMovieUI(MovieManager manager)
        {
            Console.WriteLine("\n--- Додавання нового фільму ---");

            Console.Write("Введіть назву: ");
            string title = Console.ReadLine();

            Console.Write("Введіть жанр: ");
            string genre = Console.ReadLine();

            // Захист від введення тексту замість року
            int year;
            Console.Write("Введіть рік випуску: ");
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.Write("Помилка! Введіть числове значення для року: ");
            }

            // Захист від введення неправильної оцінки
            int rating;
            Console.Write("Введіть оцінку (1-10): ");
            while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 10)
            {
                Console.Write("Помилка! Введіть ціле число від 1 до 10: ");
            }

            // Створюємо фільм і передаємо в менеджер
            Movie newMovie = new Movie(title, year, genre, rating);
            manager.AddMovie(newMovie);
        }

        // Метод для видалення фільму через UI
        static void RemoveMovieUI(MovieManager manager)
        {
            Console.Write("\nВведіть ID фільму для видалення: ");

            // Перевіряємо, чи користувач ввів саме число
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                manager.RemoveMovie(id);
            }
            else
            {
                Console.WriteLine("Помилка! Введіть коректне числове ID.");
            }
        }
    }
}