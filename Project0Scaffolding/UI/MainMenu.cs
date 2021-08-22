using Models;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UI
{
    public class MainMenu : IMenu
    {
        //the below code allows us to access the methods from IPetBL below in Start(); due to IMenu menu = new MainMenu(new PetBL(new PetRepo(context)));
        private IReviewBL _reviewb1;
        public MainMenu(IReviewBL bl) //called from Program.cs line 22
        {
            _reviewb1 = bl;
        }

        public void Start() //this is called from Program.cs line 23
        {
            bool repeat = true;
            do
            {
                //have another do while loop and switch case, where it asks if you are a user or an admin, and gives an option to go to the next method. 
                //case 1 is user where you call a method and either create a new user or access an already existing user, case two is admin and log in either using default user and pass or access one that already exists, case three is exit
                //

                /*
                Adduser, AddAdmin, 
                AddReview, SearchUser, SearchRestaurant, SearchReview
                - add a new user AddUser
                - ability to search user as admin SearchUser
                - display details of a restaurant for user SearchRestaurant
                - add reviews to a restaurant as a user AddReview
                - view details of restaurants as a user SearchRestaurant
                - view reviews of restaurants as a user SearchRestaurant
                - calculate reviews’ average rating for each restaurant SearchRestuarant
                - search restaurant (by name, rating, zip code, etc.)  SearchRestaurant.
                */
                Console.WriteLine("Welcome to Scream, your local guide to anything Restaurant Reviews!");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("[1] Add a User");
                Console.WriteLine("[2] Add a Admin");
                Console.WriteLine("[3] Add a Restaurant");
                Console.WriteLine("[4] Add a Review");
                Console.WriteLine("[5] Search a User");
                Console.WriteLine("[6] Search a Restaurant");
                Console.WriteLine("[7] Search a Review");

                switch(Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("Thanks for using Scream! Remember that whenever you need to Scream into the void about a Restaurant, think about Scream!");
                        repeat = false;
                    break;

                    case "1": //adding a new user
                    AddUser();
                    break;

                    case "2": //adding a new admin
                    AddAdmin();
                    break;

                    case "3": //adding a new restaurant
                    AddRestaurant();
                    break;

                    case "4": //adding a new review
                    AddReview();
                    break;

                    case "5": //search user work in progress
                    SearchUser();
                    break;

                    case "6": //search restaurant
                    SearchRestaurant();
                    break;

                    case "7": //search review
                    SearchReview();
                    break;

                    default:
                        Console.WriteLine("We don't understand what you're doing");
                    break;
                }
            } while(repeat);
        }

        // private void AddACat() //add a user
        // {
        //     string input;
        //     Cat catToAdd;

        //     Console.WriteLine("Enter details for the cat to add");
            
        //     do
        //     {
        //         Console.WriteLine("Name: ");
        //         input = Console.ReadLine();

        //     } while(String.IsNullOrWhiteSpace(input));


        //     catToAdd = new Cat(input);
        //     catToAdd = _petbl.AddACat(catToAdd);

        //     Console.WriteLine($"{catToAdd.Name} was successfully added!");
        // }
        private void AddUser() 
        {
            //to ask for name, username and password
            string name;
            string username;
            string password;
            User userToAdd;
            do
            {
                System.Console.WriteLine("What is your name? ");
                name = Console.ReadLine();

            } while(String.IsNullOrWhiteSpace(name));
            do
            {
                System.Console.WriteLine("What is the username? "); //check if its included in the database already
                username = Console.ReadLine();

            } while(String.IsNullOrWhiteSpace(username));
            do
            {
                System.Console.WriteLine("What is your password? "); //potentially check against good passwords
                password = Console.ReadLine();

            } while(String.IsNullOrWhiteSpace(password));
            userToAdd = new User(name, username, password, false);
            userToAdd = _reviewb1.AddUser(userToAdd);
            System.Console.WriteLine($"{userToAdd.Name} was successfully added!");

        }
        private void AddAdmin()
        {
            //to ask for default password, if its correct, ask for username and password
            bool check = false;
            string username;
            string input; 
            string name; 
            string password; 
            
            do
            {
                System.Console.WriteLine("Please enter the default Admin Password, or press [0] to exit");
                input = Console.ReadLine();
                if (input == "7294") {
                    check = true;
                }
                else if (input == "0") {
                    goto Endofmethod;
                }
            }while(check != true);
            System.Console.WriteLine("Welcome Admin!");
            do
            {
                System.Console.WriteLine("What's your name? ");
                name = Console.ReadLine();
            }while (String.IsNullOrWhiteSpace(name));
            do 
            {
                System.Console.WriteLine("What do you want your username to be? ");
                username = Console.ReadLine();
            }while (String.IsNullOrWhiteSpace(username));
            do
            {
                System.Console.WriteLine("What do you want to change your default password to? ");
                password = Console.ReadLine();
            }while (String.IsNullOrWhiteSpace(password));
            User userToAdd;
            userToAdd = new User(name, username, password, check);
            userToAdd = _reviewb1.AddUser(userToAdd);
            System.Console.WriteLine($"{userToAdd.Name} was successfully added as an Admin!");
            Endofmethod: Console.WriteLine("Please choose another option!");
        }
        private void AddReview()
        {
            string rest = "";
            string title = "";
            string body = "";
            decimal ratinghere;
            System.Console.WriteLine("Welcome to adding a review!");
             do
            {
                System.Console.WriteLine("What Restaurant do you want to add a review for? ");
                rest = Console.ReadLine();
            }while (String.IsNullOrWhiteSpace(rest));
            bool Screaming = true;
             do
            {
                System.Console.WriteLine("What Review do you give this restaurant out of 5? ");
                if (decimal.TryParse(Console.ReadLine(), out ratinghere))
                    Screaming = false;
            }while (Screaming);
            do
            {
                System.Console.WriteLine("What title do you give this review? ");
                title = Console.ReadLine();
            }while (String.IsNullOrWhiteSpace(title));
            do
            {
                System.Console.WriteLine("What is the content, the body, of your review? ");
                body = Console.ReadLine();
            }while (String.IsNullOrWhiteSpace(body));
            Review reviewToAdd;
            reviewToAdd = new Review(title, body, ratinghere);
            reviewToAdd = _reviewb1.AddReview(reviewToAdd);
        }
        private void AddRestaurant()
        {
            string rast = "";
            bool check = true;
            int zipcode;
            System.Console.WriteLine("Welcome to adding a restaurant! ");
            do 
            {
                System.Console.WriteLine("What's the name of the Restaurant you want to add? or press [0] to exit");
                rast = Console.ReadLine();
                if (SearchRestaurant(rast) == false)
                    check = false;
                else 
                    Console.WriteLine("We are sorry, the Restaurant you are trying to add is already in our system");
            }while(check);
            check = true;
            do
            {
                System.Console.WriteLine("What's the zipcode of your Restaurant? ");
                if (int.TryParse(Console.ReadLine(), out zipcode))
                    check = false;
            }while(check);



        }
        private void SearchRestaurant()
        {
           List<Restaurant> restaurants = AllRestaurants();
           foreach (var res in restaurants)
           {
              
           }

        }
        private bool SearchRestaurant(string name)
        {
           List<Restaurant> restaurants = AllRestaurants();
           foreach (var res in restaurants)
           {
              if (res.Name == name)
                return true;
           }
           return false;

        }
        private List<Restaurant> AllRestaurants() //helper method to return restaurants with their name, zipcode and rating
        {
            return _reviewb1.AllRestaurants();
        }
        private void SearchReview()
        {
            List<Review> reviews = AllReviews();
        }
        private List<Review> AllReviews() //helper method to return reviews with title, body, rating, name, restaurant name
        {
            return _reviewb1.AllReviews();
            //this will need to grab the name of the restaurant and name of the user for that restaurant
        }
        private void SearchUser()
        {
            // bool admin = true;
            // do
            // {
            //     System.Console.WriteLine("What's your name? Or Press [0] to go back if you aren't an admin");
            //     string name = Console.ReadLine();
            //     if (name == "0")
            //     {
            //         admin = false;
            //         goto endofsearch;
            //     }
            //     if (AllUsers().Where(s.Name == s.name && s.isAdmin == True).Count() == 1)
            //         admin = false;

            // }while(admin);
            // start:
            // System.Console.WriteLine("Welcome Admin!");
            // bool test = true;
            // string answer;
            // User founduser;
            // do 
            // {
            //     System.Console.WriteLine("Do you want to search by [0]: Username or [1]: Name or [2]: Choose a different option? ");
            //     switch(Console.ReadLine())
            //     {

            //         case "2":
            //         test = false;
            //         goto endofsearch;
            //         break;

            //         case "0":
            //         test = false;
            //         answer = "Username"; 
            //         break;

            //         case "1":
            //         test = false;
            //         answer = "Name";
            //         break;

            //         default:
            //         System.Console.WriteLine("We don't understand what you just typed, please try again.");
            //         break;
            //     }
            // }while(test);
            // if (answer == "Name")
            //     System.Console.WriteLine("Please enter the name you want to search on ");
            // else 
            //     System.Console.WriteLine("Please enter the username you want to search on ");
            //     string thisanswer = Console.ReadLine();
            //     if(Search(thisanswer) != null)
            //     {

            //     } else {
            //         System.Console.WriteLine(answer + " was not found, please try again.");
            //         goto start;
            //     }
            //     founduser = Search(thisanswer);
            //     System.Console.WriteLine("Here's the information from the User you found Name: {0} Username: {1}", founduser.Name, founduser.Username);
            //     do
            //     {
            //         System.Console.WriteLine("Do you want to search for another User? [0]: Yes [1]: No");
            //         string pop = Console.ReadLine();
            //         if (pop == 1)
            //             goto endofsearch;

            //     } while(String.IsNullOrWhiteSpace(pop));
            //     goto start;
            // endofsearch: System.Console.WriteLine("Returning you to the options");
        }
        private List<User> AllUsers()
        {
            return _reviewb1.AllUsers();
        }
        // private User Search(string search) {
        //     List<User> users = AllUsers();
        //     foreach (var user in users){
        //         if (user.Name == user.search || user.Username == user.search)
        //             return user;
        //     }
        //     return null;
        // }

    }
}