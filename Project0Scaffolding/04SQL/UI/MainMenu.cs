using Models;
using BL;
using System;
using System.Collections.Generic;

namespace UI
{
    public class MainMenu : IMenu
    {
        //the below code allows us to access the methods from IPetBL below in Start(); due to IMenu menu = new MainMenu(new PetBL(new PetRepo(context)));
        private IPetBL _petbl;
        public MainMenu(IPetBL bl) //called from Program.cs line 22
        {
            _petbl = bl;
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

                switch(Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("Thanks for using my Restaurant Review System!");
                        repeat = false;
                    break;

                    case "1": //adding a new review
                    AddReview();
                    break;

                    case "2": //searching reviews
                    SearchReview();
                    break;

                    case "3": //searching restaurants
                    SearchRestuarant();
                    break;

                    case "4": //searching users?
                    SearchUser();
                    break;

                    default:
                        Console.WriteLine("We don't understand what you're doing");
                    break;
                }
            } while(repeat);
        }

        private void AddACat() //add a user
        {
            string input;
            Cat catToAdd;

            Console.WriteLine("Enter details for the cat to add");
            
            do
            {
                Console.WriteLine("Name: ");
                input = Console.ReadLine();

            } while(String.IsNullOrWhiteSpace(input));


            catToAdd = new Cat(input);
            catToAdd = _petbl.AddACat(catToAdd);

            Console.WriteLine($"{catToAdd.Name} was successfully added!");
        }
        private void AddUser() 
        {

        }
        private void AddAdmin()
        {

        }
        private void AddReview()
        {

        }
        private void AddRestaurant()
        {
            
        }
        
        private void SearchRestaurant()
        {
            AllRestaurants();
        }
        private List<Restaurant> AllRestaurants() //helper method to return restaurants with their name, zipcode and rating
        {

        }
        private void SearchReview()
        {
            AllReviews();
        }
        private List<Review> AllReviews() //helper method to return reviews with title, body, rating, name, restaurant name
        {
            //this will need to grab the name of the restaurant and name of the user for that restaurant
        }
        private void SearchUser()
        {
            AllUsers();
        }
        private List<User> AllUsers()
        {

        }

    }
}