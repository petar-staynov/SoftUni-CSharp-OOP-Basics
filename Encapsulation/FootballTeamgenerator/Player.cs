using System;

namespace FootballTeamgenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Endurance
        {
            get => endurance;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Sprint should be between 0 and 100.");
                }

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Dribble should be between 0 and 100.");
                }

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                }

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100.");
                }

                shooting = value;
            }
        }

        public double GetSkillLevel()
        {
            return (Endurance + Sprint + Dribble + Passing + Shooting) / 5D;
        }
    }
}