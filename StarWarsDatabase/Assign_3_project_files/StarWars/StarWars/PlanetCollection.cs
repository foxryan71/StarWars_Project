//******************************************************
// File:PlanetCollection.cs
//
// Purpose: Contains a class called PlanetCollection.
//          Contains memeber variables count(int), 
//          next(string),previous(string), 
//          results(array of Planet class)
//         
//        
//         
//         
//         
// Written By: Ryan Claude Fox
//
// Compiler: Visual Studio 2015
//*******************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
namespace StarWars
{
    [DataContract]
     public class PlanetCollection
    {
        #region PlanetCollection Private Variables
        private int count;
        private string next;
        private string previous;
        private Planet[] results;
        #endregion

        #region PlanetCollection Properties
        
        //property for count
        [DataMember (Name ="count")]
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        
        //property for next
        [DataMember (Name = "next")]
        public string Next
        {
            get { return next; }
            set { next = value; }

        }

        //property for previous
        [DataMember (Name = "previous")]
        public string Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        //property for results
        [DataMember (Name = "results")]
        public Planet[] Results
        {
            get { return results; }
            set { results = value; }
        }
        #endregion

        #region PlanetCollection Methods

        //*****************************************************************
        //Method: PlanetCollection
        //
        //Purpose: Default Constructor, Sets variables to a default value
        //          Allocates new for Planet array.
        //*****************************************************************
        public PlanetCollection()
        {
            count = 0;
            next = "default next";
            previous = "default prev";
            results = new Planet[100];
            


            //allocate memory for results
            for(int i =0; i < results.Length; i++)
            {
                results[i] = new Planet();

            }
            
        }

        //*****************************************************************
        //Method: ToString
        //
        //Purpose: Overide ToString, show descriptive text and data for
        //all member variables for PlanetCollection.cs
        //
        //*****************************************************************
        public override string ToString()
        {
            return "Count: " + count +"\r\nNext: " + next + "\r\nPrevious: " + previous + "\r\nResults: " + show_planet();
                 
        }

        //*****************************************************************
        //Method: Planet this[]
        //
        //Purpose: Indexer. Overides the [] 
        //
        //
        //*****************************************************************
        public Planet this[int i]
        {
            get { return results[i]; }
            set { results[i] = value; }
        }
        //*****************************************************************
        //Method: show_planet
        //
        //Purpose: Shows all planets in results array
        //
        //
        //*****************************************************************
        public string show_planet()
        {

            string myString = "";
            foreach (var myvar in results)
            {

                myString += myvar;
            }

            return myString;
        }
        

        #endregion
    }
}
