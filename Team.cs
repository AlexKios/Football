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
        public List<FootballPlayer> Players { get; set; }
        public double AvarageAge;
        public Team(Coach coach, List<FootballPlayer> players)
        {
            Coach = coach;
            if (players.Count<11||players.Count>22)
            {
                Console.WriteLine("Player count must be between 11 and 22. Try Again.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Players = players;
                int allPlayersAge = 0;
                for (int i = 0; i < players.Count; i++)
                {
                    allPlayersAge += players[i].Age;
                }
                AvarageAge = allPlayersAge / players.Count;
            }
        }
    }
}
