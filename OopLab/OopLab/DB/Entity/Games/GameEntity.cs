using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lecture_23_10_2023_Alt.DB.Entity.GameAccounts;

namespace OopLab.DB.Entity.Games
{
    public class GameEntity
    {
        public int Id { get; set; }
        public GameAccount Player1 { get; set; }
        public GameAccount Player2 { get; set; }
        public int PlayRating { get; set; }
    }
}
