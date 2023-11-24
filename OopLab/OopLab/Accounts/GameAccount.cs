using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lecture_23_10_2023_Alt.DB.Services;
using OopLab.Games;

namespace OopLab.DB.Entity
{
    public class GameAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; } // Ім'я гравця
        public int CurrentRating { get; set; } = 100; // Поточний рейтинг гравця
        public List<GameResult> GameHistory; // Історія ігор гравця
        private GameAccountService service;

        public int GamesCount { get; set; } // Кількість ігор гравця
        public int WinStreek { get; set; } = 0;
        public GameAccountService _service { get; set; }

        // Конструктор класу GameAccount, де можливо вказати початкову кількість ігор (за замовчуванням - 0).
        public GameAccount(GameAccountService service, int ID, int gamesCount = 0)
        {
            _service = service;
            GamesCount = gamesCount;
            GameHistory= _service.GetHistory(this);
            Id = ID;
           
        }


        //public GameAccount() 
        //{
        //    _service.Create(this);
        //    GameHistory = _service.GetHistory(this);
        //    Id = _service.GetAll().Count();
        //}
        // Методи для фіксації результатів гри та оновлення статистики гравця.

        public void WinGame(string opponentName, Game game)
        {
            int rating = PointsCalculate(game.getPlayRating(this));
            GamesCount++;
            CurrentRating += rating;
            var result = new GameResult(opponentName, "Перемога", rating);
            GameHistory.Add(result);
            WinStreek++;
            _service.Update(this);
        }
        public void WinGame(string opponentName)
        {

            GamesCount++;
            var result = new GameResult(opponentName, "Перемога");
            GameHistory.Add(result);
            WinStreek++;
            _service.Update(this);
        }

        public void LoseGame(string opponentName, Game game)
        {
            int rating = PointsCalculate(game.getPlayRating(this));
            GamesCount++;
            CurrentRating -= rating;
            var result = new GameResult(opponentName, "Поразка", rating);
            GameHistory.Add(result);
            WinStreek = 0;
            _service.Update(this);
        }
        public void LoseGame(string opponentName)
        {

            GamesCount++;
            var result = new GameResult(opponentName, "Поразка");
            GameHistory.Add(result);
            WinStreek = 0;
            _service.Update(this);
        }
        public void draw(string opponentName) 
        {

            GamesCount++;
            var result = new GameResult(opponentName, "Нічия");
            GameHistory.Add(result);
            _service.Update(this);
        }
        // Виведення статистики гравця на консоль.
        public void GetStats()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n.................................\n");
            if (GameHistory == null) 
            {
                Console.WriteLine($"Ім'я:{UserName}, Id: {Id}");
                return;
            }

            Console.WriteLine($"Ім'я:{UserName}, Id: {Id}");
            for (int i = 0; i < GameHistory.Count; i++)
            {
                var result = _service.GetHistory(this)[i];
                String matchResult;
                if (result.Won == null) 
                {
                    Console.WriteLine($"Гра {i + 1}: \n" +
                  $"Опонент: {result.OpponentName}\n" +
                  $"Результат: Нічия\n" +
                  $"Зміна рейтингу: {result.RatingChange}\n");
                }
                Console.WriteLine($"Гра {i + 1}: \n" +
                                  $"Опонент: {result.OpponentName}\n" +
                                  $"Результат: {(result.Won)}\n" +
                                  $"Зміна рейтингу: {result.RatingChange}\n");
            }
            Console.WriteLine($"Поточний рейтинг для {UserName}: {CurrentRating}\n" +
                              $"Кількість ігор: {GamesCount}\n");
        }
        public void GetStatsWithoutRating()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\n.................................\n");
            Console.WriteLine($"ІСТОРІЯ ІГОР для {UserName}:");
            for (int i = 0; i < GameHistory.Count; i++)
            {
                var result = GameHistory[i];
                String matchResult;
                Console.WriteLine($"Гра {i + 1}: \n" +
                                  $"Опонент: {result.OpponentName}\n" +
                                  $"Результат: {(result.Won)}\n" +
                                  $"Зміна рейтингу відсутня\n") ;

            }
            Console.WriteLine(
                              $"Кількість ігор: {GamesCount}\n");
        }

        public virtual int PointsCalculate(int rating)
        {
            return rating;
        }
    }
}
