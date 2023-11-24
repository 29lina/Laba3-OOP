using Lecture_23_10_2023_Alt.DB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.DB.Entity
{
    public class AccountHalfRating : GameAccount
    {
        GameAccountService _service;
        public AccountHalfRating(GameAccountService service, int ID, int gamesCount = 0) : base(service, ID, gamesCount)
        {
            _service = service;
            Id = ID;
        }

        public override int PointsCalculate(int rating)
        {
            return rating /= 2;
        }
    }
}
