using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoupeDuMonde.classes
{
    public class CommonBet : Bet
    {
        private bool isdeathmatch;
        public bool IsDeathMatch { get => isdeathmatch; set => isdeathmatch = value; }

        public CommonBet() : base()
        {
            this.IsDeathMatch = false;
        }

        public CommonBet(int id,string heading, int maxPoints, DateTime deadLine,string discriminant, bool isdeathmatch) : base(id,heading, maxPoints, deadLine,discriminant)
        {
            this.IsDeathMatch = isdeathmatch;
        }

        public CommonBet(string heading,int maxPoints,DateTime deadLine): base(heading,maxPoints,deadLine)
        {
            this.Heading= heading;
            this.MaxPoints= maxPoints;
            this.DeadLine= deadLine;
        }
		public CommonBet(string heading, int maxPoints, DateTime deadline, bool cool) : base()
		{
			this.Heading = heading;
			this.MaxPoints = maxPoints;
			this.DeadLine = deadline;
			this.Score = 0;
			this.Discriminant = "C";
			this.Penalty = 0;
            this.Gaps = 0;
            this.IsDeathMatch = cool;

		}
	}
}
