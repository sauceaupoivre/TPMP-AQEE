using CoupeDuMonde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoupeDuMonde.Classes
{
    public class BetUser 
    {
        private int iduser;
        public int Iduser { get => iduser; set => iduser = value; }

        private int idpari;
        public int Idpari { get => idpari; set => idpari = value; }

        private int bet;
        public int Bet { get => bet; set => bet = value; }


        public BetUser(int iduser, int idpari, int bet)
        {
            this.Iduser = iduser;
            this.Idpari = idpari;
            this.Bet = bet;
        }

    }
}
