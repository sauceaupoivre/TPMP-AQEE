using System;
using System.Collections.Generic;
using System.Text;

namespace CoupeDuMonde.classes
{
    public class SpecialBet : Bet
    {
        private int penalty;
        public int Penalty { get => penalty; set => penalty = value; }
        private int gap;
        public int Gap { get => gap; set => gap = value; }
        public SpecialBet()
        {
            this.penalty = 0;
            this.gap = 0;
        }
        public SpecialBet(int id,string heading, int maxPoints, DateTime deadLine,string discriminant, int penalty, int gap) : base(id,heading, maxPoints, deadLine,discriminant)
        {
            this.Penalty = penalty;
            this.Gap = gap;
        }

        //SANS ID
        public SpecialBet(string heading, int maxPoints, DateTime deadLine, string discriminant, int penalty, int gap) : base(heading, maxPoints, deadLine, discriminant,penalty,gap)
		{
			this.Heading = heading;
            this.MaxPoints= maxPoints;
            this.DeadLine = deadLine;   
            this.Discriminant = discriminant;
            this.Penalty = penalty;
            this.gap= gap;
		}

        public SpecialBet(string heading, int maxPoints, DateTime deadline, int penalty, int gap) : base()
        {
            this.Heading = heading;
            this.MaxPoints= maxPoints;
            this.DeadLine= deadline;
            this.Score = 0;
            this.Discriminant = "S";
            this.penalty= penalty;
            this.gap= gap;
            this.IsDeathMatch = 0;

        }
	}
}
