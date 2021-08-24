using System;
using System.Collections.Generic;
namespace Models
{
    public class User
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public User() {}
        /// <summary>
        /// Constructor for User without Id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isadmin"></param>
        public User(string name, string username, string password, bool isadmin) {
            this.Name = name;
            this.Username = username;
            this.Password = password;
            this.isAdmin = isadmin;

        }
        /// <summary>
        /// Constructor for User with Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isadmin"></param>
        /// <returns></returns>
        public User(int id, string name, string username, string password, bool isadmin) : this(name, username, password, isadmin) 
        {

            this.Id = id;
        }
        //look into how this is set up
        public string Name {get; set;}
        public int Id {get;set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public List<ReviewJoin> ReviewJoins {get;set;}
    }
}

