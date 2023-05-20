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
        Kaloqn
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
                    Striker striker = new Striker(Convert.ToString((Names)rnd.Next(0, 11)), 19 + rnd.Next(1,20), rnd.Next(0, 99), 150 + rnd.Next(10, 60));
                    System.Threading.Thread.Sleep(10);
                    return striker;
                case 1:
                    Midfield midfield = new Midfield(Convert.ToString((Names)rnd.Next(0, 11)), 19 + rnd.Next(1, 20), rnd.Next(0, 99), 150 + rnd.Next(10, 60));
                    System.Threading.Thread.Sleep(10);
                    return midfield;
                case 2:
                    Defender defender = new Defender(Convert.ToString((Names)rnd.Next(0, 11)), 19 + rnd.Next(1, 20), rnd.Next(0, 99), 150 + rnd.Next(10, 60));
                    System.Threading.Thread.Sleep(10);
                    return defender;
                case 3:
                    Goalkeeper goalkeeper = new Goalkeeper(Convert.ToString((Names)rnd.Next(0, 11)), 19 + rnd.Next(1, 20), rnd.Next(0, 99), 150 + rnd.Next(10, 60));
                    System.Threading.Thread.Sleep(10);
                    return goalkeeper;
            }
            return player;
        }
        public static List<FootballPlayer> GenerateTeamPlayers(FootballPlayer[] allPlayers)
        {
            List<FootballPlayer> players = new List<FootballPlayer>();
            Random rnd = new Random();
            for (int i = 0; i < 11; i++)
            {
                players.Add(allPlayers[rnd.Next(0, allPlayers.Length)]);
                System.Threading.Thread.Sleep(10);
            }
            return players;
        }
        static void Main(string[] args)
        {
            #region Data Entry and Valitadtion
            int numOfGames = 0;
            int numOfPlayers = 0;
            do
            {
                Console.Write("Enter number of games: ");
                numOfGames = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter number of players per team (between 11 and 22): ");
                numOfPlayers = Convert.ToInt32(Console.ReadLine());
            } while (numOfGames < 0 || numOfGames > 10 || numOfPlayers < 11 || numOfPlayers > 22);

            Coach[] coaches = new Coach[numOfGames * 2];
            FootballPlayer[] allPlayers = new FootballPlayer[coaches.Length*numOfPlayers];
            Team[] teams = new Team[numOfGames*2];
            Game[] games = new Game[numOfGames];
            Random rnd = new Random();
            Referee referee = new Referee(Convert.ToString((Names)rnd.Next(0, 11)), 30);
            Referee assistantRef1 = new Referee(Convert.ToString((Names)rnd.Next(0, 11)), 20);
            Referee assistantRef2 = new Referee(Convert.ToString((Names)rnd.Next(0, 11)), 19);
            #endregion

            #region Generating Games
            for (int i = 0; i < coaches.Length; i++)
            {
                Coach newCoach = new Coach(Convert.ToString((Names)rnd.Next(0,11)), 19 + i);
                coaches[i]=newCoach;
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
                Game game = new Game(teams[rnd.Next(0,teams.Length)], teams[rnd.Next(0, teams.Length)],referee,assistantRef1,assistantRef2);
                games[i] = game;
            }
            #endregion

            #region Playing Games
            Console.WriteLine();

            foreach (var game in games)
            {
                Console.WriteLine("___________________________________________________________");
                Console.WriteLine();
                Console.WriteLine(game.Play());
            }
            #endregion
            Console.ReadKey();
        }
    }
}
