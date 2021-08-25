using Models;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace UI
{
    public class MainMenu : IMenu
    {
        //the below code allows us to access the methods from IPetBL below in Start(); due to IMenu menu = new MainMenu(new PetBL(new PetRepo(context)));
        private IReviewBL _reviewb1;
        public MainMenu(IReviewBL bl) //called from Program.cs line 22
        {
            _reviewb1 = bl;
            Log.Logger=new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.Console()
                            .WriteTo.File("../logs/petlogs.txt", rollingInterval:RollingInterval.Day)
                            .CreateLogger();
            Log.Information("UI begining");
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

                    case "7":
                    DisplayReviewsofRestaurants();
                    break;

                    default:
                        Console.WriteLine("We don't understand what you're doing");
                    break;
                }
            } while(repeat);
        }
        /// <summary>
        /// This adds a user to the database 
        /// </summary>
        private void AddUser() 
        {
            //to ask for name, username and password
            string name;
            string username;
            string password;
            bool check = true;
            User userToAdd;
            do
            {
                System.Console.WriteLine("What is your name? ");
                name = Console.ReadLine();

            } while(String.IsNullOrWhiteSpace(name));
            do
            {
                System.Console.WriteLine("What is the username you want for your account? "); //check if its included in the database already
                username = Console.ReadLine();
                //if username already exists, ask for another
                if (SearchUsernameID(username) == false)
                    check = false;
                else
                    System.Console.WriteLine("We are sorry, " + username + " already exists in our system. Choose a Username that doesn't exist in our system.");
            } while(check);
            do
            {
                System.Console.WriteLine("What is your password? "); //potentially check against good passwords
                password = Console.ReadLine();

            } while(String.IsNullOrWhiteSpace(password));
            userToAdd = new User(name, username, password, false);
             try
                {
                    userToAdd = _reviewb1.AddUser(userToAdd);
                    Log.Debug("user has been added! " + userToAdd.Name);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "User has not been added! " + userToAdd.Name);
                }
                finally{
                    Log.CloseAndFlush();
                }
            System.Console.WriteLine($"{userToAdd.Name} was successfully added!");
            System.Console.WriteLine("Returning you to the options");

        }
        /// <summary>
        /// This takes a username, finds all the users in the database and returns true if the user with the certain username exists or false if not
        /// </summary>
        /// <param name="username"></param>
        /// <returns>True if string username exists, False if string username doesn't exist</returns>
        private bool SearchUsernameID(string username)
        {
            List<User> users = AllUsers();
            foreach (User user in users)
            {
                if (user.Username == username)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// This first asks for the default admin password and then adds a user as an admin with changing the default password for them. 
        /// </summary>
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
            try
                {
                    userToAdd = _reviewb1.AddUser(userToAdd);
                    Log.Debug("user has been added! " + userToAdd.Name);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "User has not been added! " + userToAdd.Name);
                }
                finally{
                    Log.CloseAndFlush();
                }
            System.Console.WriteLine($"{userToAdd.Name} was successfully added as an Admin!");
            Endofmethod: Console.WriteLine("Please choose another option!");
        }
        /// <summary>
        /// This adds a review to the database, but first checks if the Restaurant exists in the database
        /// </summary>
        private void AddReview()// I want to take the user information here too. Make the connection in the ReviewJoin table here. 
        {
            string username = "";
            string rast = "";
            string title = "";
            string body = "";
            decimal ratinghere;
            bool check = true;
            bool u = true;
            User user;
            System.Console.WriteLine("Welcome to adding a review!");

            do 
            {
                System.Console.WriteLine("What is your Username? ");
                username = Console.ReadLine();
                user = SearchUserID(username);
                if (user == null)
                    System.Console.WriteLine($"We are sorry, the username {username} is not in our database. Select a different username");
                else
                    u = false;
            }while(u);
            System.Console.WriteLine("Here's a list of Restaurants available to review.");
            List<Restaurant> restaurants = AllRestaurants();
            foreach (Restaurant restaurant in restaurants)
            {
                System.Console.WriteLine(restaurant.Name);
                System.Console.WriteLine(" ");
                
            }
           do 
            {
                System.Console.WriteLine("What's the name of the Restaurant you want to add a review for? or press [0] to exit");
                rast = Console.ReadLine();
                if (rast == "0")
                {
                    check = false;
                }
                
                if (SearchRestaurantName(rast) == true)
                    check = false;
                else
                    Console.WriteLine("We are sorry, the Restaurant you are trying to write a review for does not exist");
            }while(check);
            if (rast == "0")
                goto endofadd;
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
            Restaurant thisrestaurant = SearchRestaurantID(rast);
            int rid = thisrestaurant.Id;
            int uid = user.Id;
            reviewToAdd = new Review(title, body, ratinghere);
            try
                {
                    reviewToAdd = _reviewb1.AddReview(reviewToAdd);
                    Log.Debug("user has been added! " + reviewToAdd.Title);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "User has not been added! " + reviewToAdd.Title);
                }
                finally{
                    Log.CloseAndFlush();
                }
            int reid = reviewToAdd.Id;
            ReviewJoin reviewjoins;
            reviewjoins = new ReviewJoin(rid, uid, reid);
            reviewjoins = _reviewb1.AddReviewJoin(reviewjoins);
            System.Console.WriteLine($"The Review with the title of {reviewToAdd.Title} has successfully been added!");
            endofadd: System.Console.WriteLine("Returning to options");
        }
        private User SearchUserID(string username) 
        {
            List<User> users = AllUsers();
            foreach (User user in users)
            {
                if (user.Username == username)
                    return user;
            }
            return null;
        }
        /// <summary>
        /// This adds a Restaurant into the database
        /// </summary>
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
                if (SearchRestaurantName(rast) == false)
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
            Restaurant AddRestaurant;
            AddRestaurant = new Restaurant(rast, zipcode, 0);
            try
                {
                    AddRestaurant = _reviewb1.AddRestaurant(AddRestaurant);
                    Log.Debug("user has been added! " + AddRestaurant.Name);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "User has not been added! " + AddRestaurant.Name);
                }
                finally{
                    Log.CloseAndFlush();
                }
            System.Console.WriteLine($"{AddRestaurant.Name} was successfully added as a Restaurant in the system!");
        }

        /// <summary>
        /// This returns a Restaurant with the given name and null if it is not found. 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Restaurant at given name</returns>
        private Restaurant SearchRestaurantID(string name)
        {
           List<Restaurant> restaurants = AllRestaurants();
           foreach (var res in restaurants)
           {
               if (res.Name == name)
                    return res;
           }
           return null;

        }
        /// <summary>
        /// This method displays the restaurant that the user requests information for.  
        /// </summary>
        private void DisplayRestaurant() 
        {
            //display details of restaurant to user
            string rast = "";
            bool check = true; 
            do 
            {
                System.Console.WriteLine("What restaurant do you want to look up? ");
                rast = Console.ReadLine();
                if (SearchRestaurantName(rast) == true) //this checks if it exists, the method returns true if it does and false if it doesn't
                    check = false;
                else 
                    Console.WriteLine("We are sorry, the Restaurant you are asking for is not apart of our database. Please try again.");
            }while(check);
            Restaurant sleep = SearchRestaurantID(rast);
            System.Console.WriteLine();
            System.Console.WriteLine($"Name: {sleep.Name} ");
            System.Console.WriteLine($"Body: {sleep.Zipcode} ");
            System.Console.WriteLine($"Rating: {sleep.Rating} ");
            System.Console.WriteLine($"---------------------------");


        }
        /// <summary>
        /// This method takes a name and returns if a Restaurant exists with that name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>True if Restaurant exists or False if it doesn't exist.</returns>
        private bool SearchRestaurantName(string name)
        {
           List<Restaurant> restaurants = AllRestaurants();
           foreach (var res in restaurants)
           {
              if (res.Name == name)
                return true;
           }
           return false;

        }
        /// <summary>
        /// helper method to return restaurants with their name, zipcode and rating 
        /// </summary>
        /// <returns>List of all Restaurants</returns>
        private List<Restaurant> AllRestaurants() 
        {
            return _reviewb1.AllRestaurants();
        }
        /// <summary>
        /// Helper method to return all Reviews with their attached information
        /// </summary>
        /// <returns></returns>
        private List<Review> AllReviews() //helper method to return reviews with title, body, rating, name, restaurant name
        {
            return _reviewb1.AllReviews();
            //this will need to grab the name of the restaurant and name of the user for that restaurant
        }
        /// <summary>
        /// Allows Admin to search Users
        /// </summary>
        private void SearchUser() //to implement
        {
            List<User> users = AllUsers();
            //to start find out if this is an admin user
            string username;
            bool check = true;
            System.Console.WriteLine("This option is meant for Admin users only");
            do
            {
                System.Console.WriteLine("What's your username? or press [0] to exit");
                username = Console.ReadLine();
                if (username == "0")
                    check = false;
                if (SearchUserName(username) == true)
                    check = false;
                else
                    System.Console.WriteLine("We are sorry " + username + " either isn't a username in our database or isn't a username that has Admin permission. Please try again.");
            } while (check);
            if (username == "0")
                goto scream;
            check = true;
            do
            {
                System.Console.WriteLine("Do you want to search Users on [0] Username, [1] Name, [2] isAdmin status, or [3] Exit");
                switch(Console.ReadLine())
                {
                    case "0":
                    SearchByUsername(users);
                    break;

                    case "1":
                    SearchByName(users);
                    break;

                    case "2":
                    SearchByAdmin(users);
                    break;

                    case "3":
                    check = false;
                    break;

                    default:
                    System.Console.WriteLine("We are sorry, we don't know what you just entered");
                    break;
                }
            } while (check);
            
            scream: System.Console.WriteLine("Returning you to the options");
        }
        /// <summary>
        /// Helper method to search by Username
        /// </summary>
        /// <param > List of Users</param>
        private void SearchByUsername(List<User> users) //searches users by username
        {
            startofthismethod:
            bool check = false;
            string annoyed;
            System.Console.WriteLine("What username do you want to search on? ");
            string username = Console.ReadLine();
            foreach (User x in users)
            {
                if(x.Username == username)
                {
                    System.Console.WriteLine("This is the User you requested:");
                    System.Console.WriteLine($"Username: {x.Username}");
                    System.Console.WriteLine($"Name: {x.Name}");
                    System.Console.WriteLine($"isAdmin: {x.isAdmin}");
                    System.Console.WriteLine("-----------------------");
                    check = true;
                }
            }
            bool o = true;
            if(check == false)
            {
                do
                {
                    System.Console.WriteLine("We are sorry, we couldn't find the user " + username + ". Would you want to search again? [0] No [1] Yes");
                    annoyed = Console.ReadLine();
                    if (annoyed == "0" || annoyed == "1")
                        o = false;
                } while (o);
                if (annoyed == "1")
                    goto startofthismethod;
                else
                    goto endofmethod;

            }
            endofmethod: System.Console.WriteLine("Returning you to the search options");
        }
        /// <summary>
        /// Helper method to search by name
        /// </summary>
        /// <param List of Users></param>
        private void SearchByName(List<User> users) //searches users by name
        {
            startofthismethod:
            bool check = false;
            string annoyed;
            System.Console.WriteLine("What name do you want to search on? ");
            string name = Console.ReadLine();
            foreach (User x in users)
            {
                if(x.Name == name)
                {
                    System.Console.WriteLine("This is the User you requested:");
                    System.Console.WriteLine($"Name: {x.Name}");
                    System.Console.WriteLine($"Username: {x.Username}");
                    System.Console.WriteLine($"isAdmin: {x.isAdmin}");
                    System.Console.WriteLine("-----------------------");
                    check = true;
                }
            }
            bool o = true;
            if(check == false) //we didn't find the name
            {
                do
                {
                    System.Console.WriteLine("We are sorry, we couldn't find the name " + name + ". Would you want to search again? [0] No [1] Yes");
                    annoyed = Console.ReadLine();
                    if (annoyed == "0" || annoyed == "1")
                        o = false;
                } while (o);
                if (annoyed == "1")
                    goto startofthismethod; //search again on name
                else
                    goto endofmethod; //go back to search options

            }
            endofmethod: System.Console.WriteLine("Returning you to the search options");

        }
        /// <summary>
        /// Helper method to search by if someone is an admin
        /// </summary>
        /// <param List of Users="users"></param>
        private void SearchByAdmin(List<User> users) //searches users by if they are an Admin
        {
            startofthismethod:
            bool answer = true;
            string admin;
            bool sp = true;
            string annoyed;
            do
            {
                System.Console.WriteLine("Enter True to search for Users who are Admins and False to search for Users who aren't Admin ");
                admin = Console.ReadLine();
                if (admin == "True")
                {
                    sp = false;
                    answer = true;
                }
                else if (admin == "False")
                {
                    sp = false;
                    answer = false;
                }
                else 
                    System.Console.WriteLine($"{admin} is not True or False. Please enter a valid input");
                
            } while (sp);
            foreach (User x in users)
            {
                if(x.isAdmin == answer)
                {
                    System.Console.WriteLine("This is the User you requested:");
                    System.Console.WriteLine($"Name: {x.Name}");
                    System.Console.WriteLine($"Username: {x.Username}");
                    System.Console.WriteLine($"isAdmin: {x.isAdmin}");
                    System.Console.WriteLine("------------------------");
                }
            }
            sp = true;
            do
            {
                System.Console.WriteLine("Do you want to search again? [0] No [1] Yes");
                annoyed = Console.ReadLine();
                if (annoyed == "0")
                    sp = false;
                else if (annoyed == "1")
                    sp = false;
                else 
                    System.Console.WriteLine($"{annoyed} is not a 0 or a 1. Please enter a valid input");    
            } while (sp);
            if (annoyed == "1")
                goto startofthismethod;
            System.Console.WriteLine("Returning you to the search options");

        }
        /// <summary>
        /// Helper method to search by Username
        /// </summary>
        /// <param username="username"></param>
        /// <returns></returns>
        private bool SearchUserName(string username)//takes a username and checks if that username is an admin
        {
           List<User> users = AllUsers();
           foreach (var user in users)
           {
              if (user.Username == username && user.isAdmin == true) //if that username exists and that user is an admin return true, otherwise return false. 
                return true;
           }
           return false;

        }
        private List<User> AllUsers()
        {
            return _reviewb1.AllUsers();
        }
        /// <summary>
        /// Displays all of the reviews for a restaurant
        /// </summary>
        private void DisplayReviewsofRestaurants()
        {
            //be able to display details of reviews for a restaurant to the user
            bool check = true; 
            string rast = "";
            do 
            {
                System.Console.WriteLine("What restaurant do you want to look up? ");
                rast = Console.ReadLine();
                if (SearchRestaurantName(rast) == true) //this checks if it exists, the method returns true if it does and false if it doesn't
                    check = false;
                else 
                    Console.WriteLine("We are sorry, the Restaurant you are trying to add is already in our system");
            }while(check);//to implement
            //get all reviews, go through them and check id where ReviewJoin.Restaurantid matches Restaurant Id
            Restaurant restaurant = SearchRestaurantID(rast);
            List<Review> reviews = AllReviews();
            List<ReviewJoin> reviewjoin = AllReviewJoin();
            List<ReviewJoin> r = new List<ReviewJoin>();
            foreach (ReviewJoin rj in reviewjoin)
            {
                if(rj.RestaurantId == restaurant.Id)
                    r.Add(rj);
            }
            foreach (ReviewJoin j in r)
            {
                
                System.Console.WriteLine("---------------------------");
                System.Console.WriteLine($"Title: {reviews[j.ReviewId-1].Title}");
                System.Console.WriteLine($"Body: {reviews[j.ReviewId-1].Body}");
                System.Console.WriteLine($"Rating: {reviews[j.ReviewId-1].Rating}");
                System.Console.WriteLine("---------------------------");
            }
           
        }
        /// <summary>
        /// Search for a restaurant by Name, Rating and Zipcode
        /// </summary>
        private void SearchRestaurant()
        {
            start:
            List<Restaurant> restaurants = AllRestaurants(); 
            //search by name, zipcode, rating
            string AAAAAAAAA;
            string answer;
            do
            {
                System.Console.WriteLine("Do you want to look up via [0] Zipcode, [1] Name, or [2] Rating? ");
                AAAAAAAAA = Console.ReadLine();
            } while (String.IsNullOrWhiteSpace(AAAAAAAAA));
            if (AAAAAAAAA == "0")
            {
                do
                {
                    System.Console.WriteLine("what is the zipcode you wnat to search on? ");
                    answer = Console.ReadLine();
                } while (String.IsNullOrEmpty(answer));

                System.Console.WriteLine("The restaurants with the requested zipcode are as follows:");
                foreach (Restaurant i in restaurants)
                {
                    if (i.Zipcode.ToString() == answer)
                    {
                        System.Console.WriteLine("---------------------------");
                        System.Console.WriteLine(i.Name);
                        System.Console.WriteLine(i.Zipcode);
                        System.Console.WriteLine(i.Rating);
                        System.Console.WriteLine("---------------------------");
                    }
                }
            } else if (AAAAAAAAA == "1")
            {
                 do
                {
                    System.Console.WriteLine("what is the name you want to search on? ");
                    answer = Console.ReadLine();
                } while (String.IsNullOrEmpty(answer));
                System.Console.WriteLine("The restaurants with the requested name are as follows:");
                foreach (Restaurant i in restaurants)
                {
                    if (i.Name == answer)
                    {
                        System.Console.WriteLine("---------------------------");
                        System.Console.WriteLine(i.Name);
                        System.Console.WriteLine(i.Zipcode);
                        System.Console.WriteLine(i.Rating);
                        System.Console.WriteLine("---------------------------");
                    }
                }
            } else if (AAAAAAAAA == "2")
            {
                 do
                {
                    System.Console.WriteLine("what is the rating you want to search on? ");
                    answer = Console.ReadLine();
                } while (String.IsNullOrEmpty(answer));
                System.Console.WriteLine("The restaurants with the requested rating are as follows:");
                foreach (Restaurant i in restaurants)
                {
                    if (i.Rating.ToString() == answer)
                    {
                        System.Console.WriteLine("---------------------------");
                        System.Console.WriteLine(i.Name);
                        System.Console.WriteLine(i.Zipcode);
                        System.Console.WriteLine(i.Rating);
                        System.Console.WriteLine("---------------------------");
                    }
                }
            }
            bool check = true;
            string hello;
            do
            {
                System.Console.WriteLine("Do you want to search again? [0] No or [1] Yes");
                hello = Console.ReadLine();
                if (hello == "0")
                    check = false;
                else if (hello == "1")
                    check = false;
                else
                    System.Console.WriteLine("Please enter a valid input of either [0] or [1]");
            } while (check);
            if (hello == "1")
                goto start;
            System.Console.WriteLine("Returning you to the options");
        }
        /// <summary>
        /// Prints out the Review Rating for the wanted Restaurant
        /// </summary>
        private void SeeReviewRating()//reimplement
        {
            startof:
            decimal count = 0;
            int i = 0;
            string answer = "";
            //calculate reviews’ average rating for each restaurant
            do
            {
                System.Console.WriteLine("What restaurant do you want to see the Review Rating for? ");
                answer = Console.ReadLine();
            } while (SearchRestaurantName(answer));
            Restaurant restaurant = SearchRestaurantID(answer);
            List<Review> reviews = AllReviews();
            List<ReviewJoin> reviewjoin = AllReviewJoin();
            List<ReviewJoin> r = new List<ReviewJoin>();
            foreach (ReviewJoin rj in reviewjoin)
            {
                if (restaurant.Id == rj.RestaurantId)
                    r.Add(rj);
            }
            //r is a list of all the reviewjoins for restaurant restaurant
            //foreach reviewjoin in r ask it to grab the review from that
            foreach (ReviewJoin j in r)
            {
                Review tempreview = reviews[j.ReviewId];
                count = count + tempreview.Rating;
                i++;
            }
            decimal rating = count/i;
            Restaurant restraurant = SearchRestaurantID(answer);
            restaurant.Rating = rating;
            System.Console.WriteLine($"{rating} is the rating of {answer}");
            bool Revature = true;
            string Tired = "";
            do
            {
                System.Console.WriteLine("Do you want to look for another Restaurant? [0] No [1] Yes");
                Tired = Console.ReadLine();
                if (Tired == "0")
                    Revature = false;
                else if (Tired == "1")
                    Revature = false;
                else 
                    System.Console.WriteLine("We are sorry but, " + Tired + ", is not a 0 or a 1, try again");
            } while (Revature);
            if (Tired == "1")
                goto startof;
            System.Console.WriteLine("Returning to options");
        }
        //potential join method for ReviewJoin? Include id of Review, id of User, id of Restaurant.
       /// <summary>
        /// Helper method to return all ReviewJoin matches
        /// </summary>
        /// <returns></returns>
        private List<ReviewJoin> AllReviewJoin() //helper method to return reviews with title, body, rating, name, restaurant name
        {
            return _reviewb1.AllReviewJoin();
            //this will need to grab the name of the restaurant and name of the user for that restaurant
        }
        private void SearchReview()
        {

        }


    }

}