using Lecture_23_10_2023_Alt.DB.Entity.GameAccounts;
using OopLab.DB.Entity;
using OopLab.DB.Entity.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.DB
{
    public class DbContext
    {
        public List<GameEntity> Games { get; set; }
        public List<GameAccountEntity> Accounts { get; set; }

        public DbContext()
        {
            Games = new List<GameEntity>();
            Accounts = new List<GameAccountEntity>();
        }
    }
}