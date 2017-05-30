//******************************************************
// File:PersonCollection.cs
//
// Purpose: Contains a class called PersonCollection.
//          Contains memeber variables count(int), 
//          next(string),previous(string), 
//          results(array of Person class)
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
    public class PersonCollection
    {

        #region PersonCollection Private Member Variables
        private int count;
        private string next;
        private string previous;
        private Person[] results;

        #endregion

        #region PersonCollection Properties

        //property for count
        [DataMember (Name = "count")]
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
        public Person[] Results
        {

            get { return results; }
            set { results = value; }
        }
        #endregion

        #region PersonCollection Methods

        //*****************************************************************
        //Method: PersonCollection
        //
        //Purpose: Default Constructor, Sets variables to a default value
        //          Allocates new for Person array.
        //*****************************************************************
        public PersonCollection()
        {
            count = 0;
            next = "default next";
            previous = "default prev";
            results = new Person[4];

            //allocate memory for results
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = new Person();
            } 

        }

        //*****************************************************************
        //Method: ToString
        //
        //Purpose: Overide ToString, show descriptive text and data for
        //all member variables for PersonCollection.cs
        //
        //*****************************************************************
        public override string ToString()
        {
            return "Count: " + count + "\r\nNext: " + next + "\r\nPrevious: " + previous + "\r\nResults: " + show_person();
        }

        //*****************************************************************
        //Method: Person this[]
        //
        //Purpose: Indexer. Overides the [] 
        //
        //
        //*****************************************************************
        public Person this[int i]
        {
            get { return results[i]; }
            set { results[i] = value; }
        }

        //*****************************************************************
        //Method: show_person
        //
        //Purpose: Shows all person in results array
        //
        //
        //*****************************************************************
        public string show_person()
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
