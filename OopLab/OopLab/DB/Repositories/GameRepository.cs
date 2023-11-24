using OopLab.DB.Entity.Games;
using OopLab.DB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.DB.Repositories
{
    public class GameRepository : IGameRepository
    {
        private DbContext context;
        public GameRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(GameEntity entity)
        {
            context.Games.Add(entity);
        }
        public void Delete(GameEntity entity)
        {
            context.Games.RemoveAt(entity.Id);
            int ID = 1;
            foreach (var game in context.Games) {context.Games[ID].Id = ID;ID++;}
        }
        public List<GameEntity> GetAll()
        {
            return context.Games;
        }
        public GameEntity GetById(int Id)
        {
            return context.Games[Id];
        }
        public void Update(GameEntity entity)
        {
            context.Games.RemoveAt(entity.Id);
            context.Games.Insert(entity.Id, entity);
        }
    }
}
