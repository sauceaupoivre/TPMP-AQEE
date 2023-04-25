using System;
using System.Collections.Generic;
using System.Text;

namespace CoupeDuMonde.classes
{
    public class Bet
    {
        private int id;
        public int Id { get => id; set => id = value; }
        private string heading;
        public string Heading { get => heading; set => heading = value; }
        private int maxpoints;
        public int MaxPoints { get => maxpoints; set => maxpoints = value; }
        private DateTime deadline;
        public DateTime DeadLine { get => deadline; set => deadline = value; }
        private int score;
        public int Score { get => score; set => score = value; }
        private string discriminant;
        public string Discriminant { get => discriminant; set => discriminant = value; }
        
        private int isdeathmatch;
        public int IsDeathMatch { get => isdeathmatch; set => isdeathmatch = value; }
        private int penalty;
        public int Penalty { get => penalty; set => penalty = value; }
        private int gap;
        public int Gaps { get => gap; set => gap = value; } 

        

        public Bet()
        {
            this.Heading = "";
            this.MaxPoints = 0;
            this.DeadLine = new DateTime();
            this.Score = 0;

        }

        public Bet (string heading, int maxPoints, DateTime deadLine)
        {
            this.Heading = heading;
            this.MaxPoints = maxPoints;
            this.DeadLine = deadLine;
            this.Score = 0;
        }

        public Bet(int id,string heading, int maxPoints, DateTime deadLine)
        {
            this.id = id;
            this.Heading = heading;
            this.MaxPoints = maxPoints;
            this.DeadLine = deadLine;
            this.Score = 0;
        }

        public Bet(int id, string heading, int maxPoints, DateTime deadLine, string discriminant)
        {
            this.id = id;
            this.Heading = heading;
            this.MaxPoints = maxPoints;
            this.DeadLine = deadLine;
            this.Score = 0;
            this.Discriminant = discriminant;
        }

        public Bet(int id, string heading, int maxpoints, DateTime deadline, int score, string discriminant, bool isdeathmatch, int penalty, int gap) 
        {

        }
        //SANS ID
		public Bet( string heading, int maxpoints, DateTime deadline, string discriminant, int penalty, int gap)
		{

		}

		public static implicit operator string(Bet v)
        {
            throw new NotImplementedException();
        }
    }
}
