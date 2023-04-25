using System;
using System.Collections.Generic;
using System.Text;

namespace CoupeDuMonde.classes
{
    public class User
    {
        private string name;
        public string Name { get => name; set => name = value; }
        private string lastname;
        public string LastName { get => lastname; set => lastname = value; }
        private string username;
        public string UserName { get => username; set => username = value; }
        private string email;
        public string Email { get => email; set => email = value; }
        private string password;
        public string Password { get => password; set => password = value; }
        private int isplayer;
        public int IsPlayer { get => isplayer; set => isplayer = value; }
        private int points;
        public int Points { get => points; set => points = value; }
        private Classroom classroom;
        public Classroom Classroom { get => classroom; set => classroom = value; }
        private Dictionary<Bet, int> betuser;
        public Dictionary<Bet, int> BetUser { get => betuser; set => betuser = value; }
       

        public User()
        {
            this.Name = "";
            this.LastName = "";
            this.Email = "";
            this.Password = "";
            this.IsPlayer = 0;
            this.Points = 0;
            this.BetUser = new Dictionary<Bet,int>();
        }
        public User(string name, string lastname,string username)
        {
            this.Name = name;
            this.LastName = lastname;
            this.UserName = username;
            this.IsPlayer = 0;
            this.Points = 0;

        }
        public User(string name, string lastname,string username, string email, int isplayer)
        {
            this.Name = name;
            this.LastName = lastname;
            this.UserName = username;
            this.Email = email;
            this.IsPlayer = isplayer;
        }

        public User(string name, string lastName, string email, string password, int isPlayer, int points, Classroom classroom)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.Points = 0;
            this.IsPlayer = isPlayer;
            this.Classroom = classroom;
        }
        public User(string name, string lastName,string username, string email, string password, int isPlayer, int points, Classroom classroom)
        {
            this.Name = name;
            this.LastName = lastName;
            this.UserName = username;
            this.Email = email;
            this.Password = password;
            this.Points = points;
            this.IsPlayer = isPlayer;
            this.Classroom = classroom;
        }

    }
}
