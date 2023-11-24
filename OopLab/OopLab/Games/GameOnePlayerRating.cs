using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lecture_23_10_2023_Alt.DB.Services;
using OopLab;
using OopLab.DB.Entity;
using OopLab.DB.Services;
using OopLab.Games;

namespace Aloop
{

    public class GameOnePlayerRating : Game
    {
        int playRating1 { get; set; }
        int playRating2 { get; set; }
        public GameOnePlayerRating(GameAccount player1, GameAccount player2, GameService service) : base(player1, player2, service)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
        }

        public override int getPlayRating(GameAccount player)
        {
            if (player.UserName == player1.UserName) {  return playRating1; }
            if (player.UserName == player2.UserName) {  return playRating2; }
            return 0;
        }
        override public void StartGame()
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
        override public void Play()
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
            if (playRating > player1.CurrentRating - 1 && playRating > player2.CurrentRating - 1)
            {
                Console.WriteLine("У одного з гравців недостатньо рейтингу.");
                Play();
                return;
            }
            ChosePlayer();


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
                Console.WriteLine($"Переміг {player1.UserName}!");
                player1.GetStats();
                player2.GetStats();
            }
            if (player1Roll < player2Roll)
            {
                player2.WinGame(player1.UserName, this);
                player1.LoseGame(player2.UserName, this);
                Console.WriteLine($"Переміг {player2.UserName}!");
                player1.GetStats();
                player2.GetStats();
            }
            if (player1Roll == player2Roll)
            {
                Console.WriteLine("Нічия");
            }

            // Питання про гру ще раз.
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
        public void ChosePlayer()
        {

            Console.Write("Виберіть, у якого гравця не зміниться рейтинг (1 або 2): ");
            int temp = Convert.ToInt32(Console.ReadLine());
            if (temp == 1)
            {
                playRating1 = 0; playRating2 = playRating;
                
                return;
            }
            if (temp == 2)
            {
                playRating2 = 0; playRating1 = playRating;
               
                return;
            }

            else
            {
                Console.WriteLine("Введено некоректне значення!");
                ChosePlayer();
            }
        }
    }
}
