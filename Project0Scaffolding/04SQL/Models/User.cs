namespace Models
{
    public class User
    {
        public User() {}
        public User(string name, int id, string username, string password, bool isadmin)
        {
            this.Name = name;
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.isAdmin = isadmin; 

        }
        //look into how this is set up
        public string Name {get; set;}
        public int Id {get;set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
    }
}