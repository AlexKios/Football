using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    public class Game
    {
        private Team Team1 { get; set; }
        private Team Team2 { get; set; }
        private Referee Referee { get; set; }
        private Referee AssistantRef1 { get; set; }
        private Referee AssistantRef2 { get; set; }
        private class Goal 
        {
            public int Minute { get; set; }
            public string Player { get; set; }
        }

        private string GameResult;
        private string Winner;
        public Game(Team team1,Team team2,Referee referee,Referee assRef1,Referee assRef2)
        {
            Team1 = team1;
            Team2 = team2;
            Referee = referee;
            AssistantRef1 = assRef1;
            AssistantRef2 = assRef2;
        }
        public string Play()
        {
            Random rnd = new Random();
            int teamAdvantage = 0;
            int team1Goals = 0;
            int team2Goals = 0;
            Goal goal = new Goal();

            if (Team1.AvarageAge < Team2.AvarageAge) 
            {
                teamAdvantage = 1;
            }
            if (Team1.AvarageAge > Team2.AvarageAge)
            {
                teamAdvantage = 2;
            }
            else if(Team1.AvarageAge == Team2.AvarageAge)
            {
                teamAdvantage = 0;
            }

            //90 Minute Game
            for (int i = 0; i < 90; i++)
            {
                if (teamAdvantage == 1)
                {
                    if (rnd.Next(1, 100) > 90)
                    {
                        goal.Player = Team1.Players[rnd.Next(1, Team1.Players.Count)].Name;
                        goal.Minute = i;
                        GameResult +=  goal.Player + " scored in " + goal.Minute + " minute for Team 1. \n";
                        team1Goals++;
                    }
                    if (rnd.Next(1, 100) > 95)
                    {
                        goal.Player = Team2.Players[rnd.Next(1, Team2.Players.Count)].Name;
                        goal.Minute = i;
                        GameResult += goal.Player + " scored in " + goal.Minute + " minute for Team 2. \n";
                        team2Goals++;
                    }
                }
                else if(teamAdvantage == 2)
                {
                    if (rnd.Next(1, 100) > 95)
                    {
                        goal.Player = Team1.Players[rnd.Next(1, Team1.Players.Count)].Name;
                        goal.Minute = i;
                        GameResult += goal.Player + " scored in " + goal.Minute + " minute for Team 1. \n";
                        team1Goals++;
                    }
                    if (rnd.Next(1, 100) > 90)
                    {
                        goal.Player = Team2.Players[rnd.Next(1, Team2.Players.Count)].Name;
                        goal.Minute = i;
                        GameResult += goal.Player + " scored in " + goal.Minute + " minute for Team 2. \n";
                        team2Goals++;
                    }
                }
                else if(teamAdvantage == 0)
                {
                    if (rnd.Next(1, 100) > 98)
                    {
                        goal.Player = Team1.Players[rnd.Next(1, Team1.Players.Count)].Name;
                        goal.Minute = i;
                        GameResult += goal.Player + " scored in " + goal.Minute + " minute for Team 1. \n";
                        team1Goals++;
                    }
                    if (rnd.Next(1, 100) > 98)
                    {
                        goal.Player = Team2.Players[rnd.Next(1, Team2.Players.Count)].Name;
                        goal.Minute = i;
                        GameResult += goal.Player + " scored in " + goal.Minute + " minute for Team 2. \n";
                        team2Goals++;
                    }
                }
            }

            if (team1Goals > team2Goals) 
            {
                Winner = "Team 1";
            }
            else if (team1Goals < team2Goals)
            {
                Winner = "Team 2";
            }
            else if(team1Goals == team2Goals)
            {
                Winner = "Draw";
            }

            System.Threading.Thread.Sleep(100);
            return GameResult + "\n Team 1: " + team1Goals + " | Team 2: " + team2Goals + "\n The Winner is " + Winner;
        }
    }
}
