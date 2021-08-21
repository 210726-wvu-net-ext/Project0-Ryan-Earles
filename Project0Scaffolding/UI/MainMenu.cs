using Models;
using BL;
using System;
using System.Collections.Generic;

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
                        Console.WriteLine("Thanks for using my Restaurant Review System!");
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

                    case "5": //search user
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
            userToAdd = new User(name, username, password, false);
            userToAdd = _reviewb1.AddUser(userToAdd);
            System.Console.WriteLine($"{userToAdd.Name} was successfully added!");
            Endofmethod: Console.WriteLine("Please choose another option!");
        }
        private void AddReview()
        {

        }
        private void AddRestaurant()
        {

        }
        
        private void SearchRestaurant()
        {
           List<Restaurant> restaurants = AllRestaurants();
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
            
            bool test = true;
            do 
            {
                System.Console.WriteLine("Do you want to search by [0]: Username or [1]: Name or [2]: Choose a different option? ");
                switch(Console.ReadLine())
                {

                    case "2":
                    test = false;
                    break;

                    case "0":
                    Search("Name");
                    break;

                    case "1":
                    Search("Username");
                    break;

                    default:
                    System.Console.WriteLine("We don't understand what you just typed, please try again.");
                    break;
                }
            }while(test);
            

            System.Console.WriteLine("Returning you to the options");
        }
        private List<User> AllUsers()
        {
            return _reviewb1.AllUsers();
        }
        private void Search(string search) {
            List<User> users = AllUsers();
            foreach (var user in users){
                System.Console.WriteLine(user);
            }

        }

    }
}