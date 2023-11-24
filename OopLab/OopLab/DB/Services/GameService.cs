using Aloop;
using Lecture_23_10_2023_Alt.DB.Services;
using OopLab.DB.Entity.Games;
using OopLab.DB.Repositories;
using OopLab.DB.Repositories.Base;
using OopLab.DB.Services.Base;
using OopLab.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.DB.Services
{
    public class GameService : IGameService
    {
        GameRepository repository;
        GameAccountService _serviceAcc;
        public GameService(DbContext context)
        {
            repository = new GameRepository(context);
            _serviceAcc= new GameAccountService(context);
        }
        public void Create(Game entity)
        {
            repository.Create(Map(entity));
        }
        public void Delete(Game entity)
        {
            repository.Delete(Map(entity));
        }
        public List<Game> GetAll()
        {
            var list = repository.GetAll().Select(x => Map(x)).ToList();
            return list;
        }
        public Game GetById(int id)
        {
            return Map(repository.GetById(id));
        }
        public void Update(Game entity)
        {
            repository.Update(Map(entity));
        }
        private GameEntity Map(Game game)
        {
            return new GameEntity
            {
                Id = game.Id,
                Player1 = game.player1,
                Player2 = game.player2,
                PlayRating = game.playRating,
                
            };
        }
        private Game Map(GameEntity game)
        {
            return new Game(game.Player1, game.Player2, this)
            {
                Id = game.Id,
                player1 = game.Player1,
                player2 = game.Player2,
                playRating = game.PlayRating,
            };
        }
        private GameOnePlayerRatingEntity Map(GameOnePlayerRating game)
        {
            return new GameOnePlayerRatingEntity
            {
                Id = game.Id,
                Player1 = game.player1,
                Player2 = game.player2,
                PlayRating = game.playRating,

            };
        }
        private GameOnePlayerRating Map(GameOnePlayerRatingEntity game)
        {
            return new GameOnePlayerRating(game.Player1, game.Player2, this)
            {
                Id = game.Id,
                player1 = game.Player1,
                player2 = game.Player2,
                playRating = game.PlayRating,
            };
        }
        private GameWithoutRatingEntity Map(GameWithoutRating game)
        {
            return new GameWithoutRatingEntity
            {
                Id = game.Id,
                Player1 = game.player1,
                Player2 = game.player2,
                PlayRating = game.playRating,

            };
        }
        private GameWithoutRating Map(GameWithoutRatingEntity game)
        {
            return new GameWithoutRating(game.Player1, game.Player2, this)
            {
                Id = game.Id,
                player1 = game.Player1,
                player2 = game.Player2,
                playRating = game.PlayRating,
            };
        }
    }
}
