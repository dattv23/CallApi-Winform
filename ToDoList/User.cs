using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class User
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int gender { get; set; }

        public User() { }

        public User(string name, string phone, string address, string email, int gender) 
        {
                this.name = name;  
                this.phone = phone; 
                this.address = address;
                this.email = email;
                this.gender = gender;
        }
    }
}
