using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamgenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] commandArgs = command.Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries);

                switch (commandArgs[0])
                {
                    case "Team":
                        //•	"Team;<TeamName>" – add a new team;
                        string teamName = commandArgs[1];
                        try
                        {
                            Team team = new Team(teamName);
                            teams.Add(team);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    case "Add":
                        //•	"Add;<TeamName>;<PlayerName>;<Endurance>;<Sprint>;<Dribble>;<Passing>;<Shooting>" 
                        teamName = commandArgs[1];
                        string playerName = commandArgs[2];
                        int endurance = int.Parse(commandArgs[3]);
                        int sprint = int.Parse(commandArgs[4]);
                        int dribble = int.Parse(commandArgs[5]);
                        int passing = int.Parse(commandArgs[6]);
                        int shooting = int.Parse(commandArgs[7]);

                        try
                        {
                            Team teamA = teams.FirstOrDefault(t => t.Name == teamName);
                            if (teamA == null)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                teamA.AddPlayer(player);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    case "Remove":
                        //•	"Remove;<TeamName>;<PlayerName>" – remove the player from the team;
                        teamName = commandArgs[1];
                        playerName = commandArgs[2];

                        Team teamR = teams.FirstOrDefault(t => t.Name == teamName);
                        if (teamR == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            teamR.RemovePlayer(playerName);
                        }

                        break;

                    case "Rating":
                        //•	"Rating;<TeamName>" – print the team rating, rounded to an integer.
                        teamName = commandArgs[1];
                        Team tearmRate = teams.FirstOrDefault(t => t.Name == teamName);
                        if (tearmRate == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine($"{teamName} - {tearmRate.GetRating()}");
                        }
                        break;
                }
            }
        }
    }
}