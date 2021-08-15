using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lib
{
    public class User
    {
        /// <summary>
        /// Initializes the information tied to the user to starter values
        ///User: name, list of reviews, list of restaurants reviewed
        /// </summary>
        public User() { 
            this.name = null; //name of user
            this.reviews = new Dictionary<string, string>(); //name of restaurant and review left   
        }
        /// <summary>
        /// Initializes the bank account at creation with the name of the account holder, account number tied to that account, the starting amount in the account.
        /// It also adds the information of name and account number to the dictionary names as well as the account number and starting amount to the dictionary acccount.
        /// Note: The account number here is the same, hence linking the two dictionaries together
        /// Potential improvement: Dictionary<name, Dictionary<accountnum, startamount>>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="accountnum"></param>
        /// <param name="startamount"></param>
        /// <returns></returns>
        public User(string name, string review) : this() {
            this.name = name;
            reviews.Add(name, review);
        } 
        //initializes the different varibales included in this class to be used elsewhere in the class 
        public string name;
        public Dictionary<string, string> reviews {get; set;}
        /// <summary>
        /// Prints out the details attached to the bank account you send it, has to be invocated as follows bankAccount.GetDetails(); 
        /// so it knows what to put in for name, accountnum, and starting amount
        /// </summary>
        /// <returns>string of the information to be printed out and shown to user</returns>
        // public string GetDetails(){
        // }
    

    }

    
}