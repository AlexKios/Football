using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public enum Names
    {
        Ivan,
        Asen,
        Georgi,
        Alexander,
        Vasil,
        Stoqn,
        Rosen,
        Martin,
        Dimiter,
        Nikola,
        Viktor,
        Kaloqn,
        Boris,
        Evgenii,
        Chanko,
        Canko,
        Peter,
        Krasimir,
        Rangel,
        Qsen,
        Adam
    }
    class Program
    {
        public static  FootballPlayer GeneratePlayer()
        {
            Random rnd = new Random();
            FootballPlayer player= new FootballPlayer();
            int type = rnd.Next(0, 3);
            switch (type)
            {
                case 0:
                    Striker striker = new Striker(Convert.ToString((Names)rnd.Next(0, 20)), rnd.Next(19,40), rnd.Next(0, 99), rnd.Next(160, 210));
                    System.Threading.Thread.Sleep(5);
                    return striker;
                case 1:
                    Midfield midfield = new Midfield(Convert.ToString((Names)rnd.Next(0, 20)), rnd.Next(19, 40), rnd.Next(0, 99), rnd.Next(160, 210));
                    System.Threading.Thread.Sleep(5);
                    return midfield;
                case 2:
                    Defender defender = new Defender(Convert.ToString((Names)rnd.Next(0, 20)), rnd.Next(19, 40), rnd.Next(0, 99), rnd.Next(160, 210));
                    System.Threading.Thread.Sleep(5);
                    return defender;
                case 3:
                    Goalkeeper goalkeeper = new Goalkeeper(Convert.ToString((Names)rnd.Next(0, 20)), rnd.Next(19, 40), rnd.Next(0, 99), rnd.Next(160, 210));
                    System.Threading.Thread.Sleep(5);
                    return goalkeeper;
            }
            return player;
        }
        public static FootballPlayer[] GenerateTeamPlayers(FootballPlayer[] allPlayers)
        {
            FootballPlayer[] players = new FootballPlayer[11];
            Random rnd = new Random();
            for (int i = 0; i < 11; i++)
            {
                players[i] = allPlayers[rnd.Next(0, allPlayers.Length)];
                System.Threading.Thread.Sleep(5);
            }
            return players;
        }
        static void Main(string[] args)
        {
            int numOfGames = 0;
            int numOfPlayers = 0;
            do
            {
                Console.Write("Enter number of games: ");
                numOfGames = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter number of players per team (between 11 and 22): ");
                numOfPlayers = Convert.ToInt32(Console.ReadLine());
            } while (numOfGames < 0 || numOfGames > 10 || numOfPlayers < 11 || numOfPlayers > 22);

            Random rnd = new Random();
            Coach[] coaches = new Coach[numOfGames * 2];
            FootballPlayer[] allPlayers = new FootballPlayer[coaches.Length*numOfPlayers];
            Team[] teams = new Team[numOfGames*2];
            Game[] games = new Game[numOfGames];
            Referee referee = new Referee(Convert.ToString((Names)rnd.Next(0, 20)), 30);
            Referee assistantRef1 = new Referee(Convert.ToString((Names)rnd.Next(0, 20)), 20);
            Referee assistantRef2 = new Referee(Convert.ToString((Names)rnd.Next(0, 20)), 19);

            for (int i = 0; i < coaches.Length; i++)
            {
                Coach newCoach = new Coach(Convert.ToString((Names)rnd.Next(0,11)), 19 + i);
                coaches[i] = newCoach;
            }

            for (int i = 0; i < allPlayers.Length; i++)
            {
                allPlayers[i] = GeneratePlayer();
            }

            for (int i = 0; i < teams.Length; i++)
            {
                Team team = new Team(coaches[i], GenerateTeamPlayers(allPlayers));
                teams[i] = team;
            }

            for (int i = 0; i < games.Length; i++)
            {
                Game game = new Game(teams[rnd.Next(0, teams.Length)], teams[rnd.Next(0, teams.Length)], referee, assistantRef1, assistantRef2);
                games[i] = game;
            }
           
            Console.WriteLine();

            foreach (var game in games)
            {
                Console.WriteLine("______________________________________");
                Console.WriteLine();
                Console.WriteLine(game.Play());
            }

            Console.ReadKey();
        }
    }
}
