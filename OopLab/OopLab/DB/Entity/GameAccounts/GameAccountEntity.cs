using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.DB.Entity
{
    public class GameAccountEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; } // Ім'я гравця
        public int CurrentRating { get; set; } // Поточний рейтинг гравця
        public int GamesCount { get; set; } = 0; // Кількість ігор гравця
        public List<GameResultEntity> GameHistory { get; set; }
    }
}
