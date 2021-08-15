using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Lib
{
    public class Restaurant
    {
        /// <summary>
        /// Initializes the information tied to the restaurants to the starter value
        ///Restaruants: name, rating, zipcode, list of reviews for that restaurant
        /// </summary>
        public Restaurant() { 
            this.name = null; ///name of the restaurant
            this.zipcode = 0; ///zipcode of where the restaurant is
            this.rating = 0; //rating of this restaurant
            this.reviews = new Dictionary<string, string>(); //this is the list of reviews for this restaurant
            this.searchreviews = new Dictionary<string, Dictionary<int, decimal>>();
        }
        /// <summary>
        /// This sets the values to their values
        /// </summary>
        /// <param name="name of restaurant"></param>
        /// <param zipcode="zipcode of restaurant"></param>
        /// <param rating="rating of restaurant out of 5"></param>
        /// <param reviews="list of reviews that the restaurant has gottten"></param>
        /// <returns></returns>
        public Restaurant(string name, int zipcode, decimal rating, Dictionary<string, string> reviews) : this() {
            this.name = name;
            this.zipcode = zipcode;
            this.rating = rating;
            this.reviews = reviews;
            searchreviews.Add(name, AddtoDictionary(name, zipcode, rating, searchreviews));
        } 
        //initializes the different varibales included in this class to be used elsewhere in the class 
        public string name;
        public int zipcode;
        public decimal rating;
        public Dictionary<string, string> reviews;
        public Dictionary<string, Dictionary<int, decimal>> searchreviews {get; set;}
       
        /// <summary>
        ///prints out values potentially
        /// </summary>
        /// <returns>string of the information to be printed out and shown to user</returns>
        // public string GetDetails(){
           
        // }
        public static Dictionary<int, decimal> AddtoDictionary(string name, int zipcode, decimal rating, Dictionary<string, Dictionary<int, decimal>> searchreviews)
        {
            Dictionary<int, decimal> tempdict = new Dictionary<int, decimal>();
            tempdict.Add(zipcode,rating);
            searchreviews[name] = tempdict;
            return tempdict;

        }
        // public static Dictionary<int, double> GetValuesDictionary(string name) {
        //     Dictionary<int, double> tempdict = new Dictionary<int, double>();
        //     tempdict = this.searchreviews[name];
        //     return tempdict;
        // }
    

    }

    
}