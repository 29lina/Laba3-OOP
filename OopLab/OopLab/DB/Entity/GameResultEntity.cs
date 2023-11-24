using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.DB.Entity
{
    public class GameResultEntity
    {
        public string OpponentName { get; set; }
        public string Won { get; set; }
        public int RatingChange { get; set; }
    }
}
