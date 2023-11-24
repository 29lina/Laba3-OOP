using OopLab.DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.DB.Services.Base
{
    public interface IGameAccountService
    {
        public void Create(GameAccount entity);
        public List<GameAccount> GetAll();
        public GameAccount GetById(int id);
        public void Update(GameAccount entity);
        public void Delete(GameAccount entity);
        public List<GameResult> GetHistory(GameAccount entity);
        public void AddGameResult(GameResult gameResult, GameAccount entity);
    }
}
