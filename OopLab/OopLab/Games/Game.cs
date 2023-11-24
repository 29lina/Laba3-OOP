using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lecture_23_10_2023_Alt.DB.Services;
using OopLab.DB.Entity;
using OopLab.DB.Services;

namespace OopLab.Games
{
    // Клас, що представляє гру між двома гравцями.
    public class Game
    {
        public int Id { get; set; }   
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public GameAccount Winner { get; set; }
        public int playRating { get; set; } = 0;
        public GameService _service { get; set; }
        public Game(GameAccount player1, GameAccount player2, GameService service)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
        }

        public virtual int getPlayRating(GameAccount player) { return playRating; }
        // Розпочати гру між гравцями.
        public virtual void StartGame()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Ласкаво просимо до гри!\n");

            // Введення імен гравців та початкового рейтингу.
            Console.Write("Введіть ім'я першого гравця: ");
            player1.UserName = Console.ReadLine().Trim();

            Console.Write("Введіть ім'я другого гравця: ");
            player2.UserName = Console.ReadLine().Trim();

            //Console.Write("\nВведіть початковий рейтинг: ");
            //int startRating = Convert.ToInt32(Console.ReadLine());
            //while (startRating <= 0)
            //{
            //    Console.WriteLine("Початковий рейтинг повинен бути більше 0");
            //    Console.Write("Введіть початковий рейтинг: ");
            //    startRating = Convert.ToInt32(Console.ReadLine());
            //}
            //player1.CurrentRating = startRating;
            //player2.CurrentRating = startRating;
            // Початок гри.
            Play();
        }

        // Метод, що виконує гру між гравцями.
        public virtual void Play()
        {

            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.Write("Введіть рейтинг на який граєте: ");
            playRating = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (playRating < 0)
            {
                Console.WriteLine("Некоректне значення. Введіть додатнє число.");
                Play();
                return;
            }
            if (playRating > player1.CurrentRating - 1 || playRating > player2.CurrentRating - 1)
            {
                Console.WriteLine("У одного з гравців недостатньо рейтингу.");
                Play();
                return;
            }

            // Симуляція кидання кубиків і визначення переможця.
            Random random = new Random();
            int player1Roll = random.Next(1, 7);
            int player2Roll = random.Next(1, 7);
            Console.WriteLine($"{player1.UserName} кинув кубик і випало {player1Roll}");
            Console.WriteLine($"{player2.UserName} кинув кубик і випало {player2Roll}");
            if (player1Roll > player2Roll)
            {
                player1.WinGame(player2.UserName, this);
                player2.LoseGame(player1.UserName, this);
                Winner = player1;
                _service.Create(this);
                Console.WriteLine($"Переміг {player1.UserName}!");
                player1.GetStats();
                player2.GetStats();
            }
            if (player1Roll < player2Roll)
            {
                player2.WinGame(player1.UserName, this);
                player1.LoseGame(player2.UserName, this);
                Winner = player2;
                _service.Create(this);
                Console.WriteLine($"Переміг {player2.UserName}!");
                player1.GetStats();
                player2.GetStats();
            }
            if (player1Roll == player2Roll)
            {
                player1.draw(player2.UserName);
                player2.draw(player1.UserName);
                Console.WriteLine("Нічия");
            }
            End();
           
        }
        public virtual void End() 
        {
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.Write("Хочете зіграти ще одну гру? (Так/Ні): ");
            string playAgainResponse = Console.ReadLine().Trim();

            bool playAgain = true;
            if (!playAgainResponse.Equals("Так", StringComparison.OrdinalIgnoreCase))
            {
                playAgain = false;
            }
            if (playAgain) Play();
        }

    }

}

