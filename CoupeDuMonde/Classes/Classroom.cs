using System;
using System.Collections.Generic;
using System.Text;

namespace CoupeDuMonde.classes
{
    public class Classroom
    {
        private int id;
        public int Id { get => id; set => id = value; }
        private string name;
        public string Name { get => name; set => name = value; }
        private List<User> users;
        public List<User> Users { get => users; set => users = value; }
        private int classPoints;
        public int ClassPoints { get => classPoints; set => classPoints = value; }

        public Classroom(string name)
        {
            Name = name;
            Users = new List<User> ();
        }

        public Classroom(int id,string name)
        {
            Id = id;
            Name = name;
            Users = new List<User>();
        }

        public Classroom(string name, List<User> users)
        {
            this.name = name;
            this.users = users;
        }
        public Classroom(int id, string name, List<User> users)
        {
            this.id = id;
            this.name = name;
            this.users = users;
        }

        public void AddUser(User user)
        {
            user.Classroom=this;
            this.users.Add(user);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

}
