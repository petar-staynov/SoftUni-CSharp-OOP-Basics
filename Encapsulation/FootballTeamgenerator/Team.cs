using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamgenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault(p => p.Name == playerName);
            if (player == null)
            {
                Console.WriteLine($"Player {playerName} is not in {Name} team.");
            }
            else
            {
                this.players.Remove(player);
            }
        }

        public double GetRating()
        {
            if (players.Count <= 0)
            {
                return 0;
            }
            double totalRating = 0;
            foreach (Player player in this.players)
            {
                totalRating += player.GetSkillLevel();
            }

            return  (int)Math.Round(totalRating / this.players.Count);
        }
    }
}