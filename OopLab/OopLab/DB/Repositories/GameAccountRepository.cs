using Lecture_23_10_2023_Alt.DB.Entity.GameAccounts;
using OopLab.DB.Entity;
using OopLab.DB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.DB.Repositories
{
    public class GameAccountRepository : IGameAccountRepository
    {
        DbContext context;
        public GameAccountRepository(DbContext context) 
        { 
            this.context = context; 
        }
        public void AddGameResult(GameResultEntity gameResult, GameAccountEntity entity)
        {
            context.Accounts[entity.Id].GameHistory.Add(gameResult);
        }

        public void Create(GameAccountEntity entity)
        {
            context.Accounts.Add(entity);
        }
        public void Delete(GameAccountEntity entity)
        {
            context.Accounts.RemoveAt(entity.Id);
            int ID = 1;
            foreach (var gameAccount in context.Accounts) { context.Accounts[ID].Id = ID; ID++; }
        }
        public List<GameAccountEntity> GetAll()
        {
            return context.Accounts;
        }
        public GameAccountEntity GetById(int id)
        {
            return context.Accounts[id];
        }
        public List<GameResultEntity> GetHistory(GameAccountEntity entity)
        {
            return entity.GameHistory;
        }
        public void Update(GameAccountEntity entity)
        {
            context.Accounts.RemoveAt(entity.Id);
            context.Accounts.Insert(entity.Id, entity);
        }
    }
}
