using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lecture_23_10_2023_Alt.DB.Services;
using OopLab.DB.Entity;
using OopLab.DB.Services;
using OopLab.Games;

namespace Aloop
{
    public class GameFactory
    {
        public Game CreateGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new Game(player1, player2, service);
        }
        public Game CreateGameWithoutRating(GameAccount player1, GameAccount player2, GameService service)
        {
            return new GameWithoutRating(player1, player2, service);
        }

        public Game CreateGameOnePlayerRating(GameAccount player1, GameAccount player2, GameService service)
        {
            return new GameOnePlayerRating(player1, player2, service);
        }

    }
}
