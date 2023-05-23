using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public class Team
    {
        private Coach Coach { get; set; }
        public FootballPlayer[] Players { get; set; }
        public double AvarageAge;
        public Team(Coach coach, FootballPlayer[] players)
        {
            Coach = coach;
            Players = players;
            int allPlayersAge = 0;
            for (int i = 0; i < players.Length; i++)
            {
                allPlayersAge += players[i].Age;
            }
            AvarageAge = allPlayersAge / players.Length;
        }
    }
}
