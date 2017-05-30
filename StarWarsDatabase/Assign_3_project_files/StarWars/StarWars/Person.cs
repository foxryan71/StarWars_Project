
//******************************************************
// File:Person.cs
//
// Purpose: Contains the class definition for Person.
//          Will hold all person information 
//          such as name, height, mass, hair_color, skin_color,
//          eye_color, birth_year, gender, home_world,
//          population, created, edited, and url.
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
namespace StarWars
{

    [DataContract]
    public class Person
    {
        #region Person Memeber Variables

        private string name;
        private string height;
        private string mass;
        private string hair_color;
        private string skin_color;
        private string eye_color;
        private string birth_yr;
        private string gender;
        private string home_world;
        private string created;
        private string edited;
        private string url;
        private string[] films;
        private string[] species;
        private string[] vehicles;
        private string[] starships;

        #endregion

        #region Person Properties

        [DataMember(Name = "name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember(Name = "height")]
        public string Height
        {
            get { return height; }
            set { height = value; }
        }

        [DataMember(Name = "mass")]
        public string Mass
        {
            get { return mass; }
            set { mass = value; }
        }

        [DataMember(Name = "hair_color")]
        public string Hair_Color
        {
            get { return hair_color; }
            set { hair_color = value; }
        }

        [DataMember(Name = "skin_color")]
        public string Skin_Color
        {
            get { return skin_color; }
            set { skin_color = value; }
        }

        [DataMember(Name = "eye_color")]
        public string Eye_Color
        {
            get { return eye_color; }
            set { eye_color = value; }
        }

        [DataMember(Name = "birth_year")]
        public string Birth_Yr
        {
            get { return birth_yr; }
            set { birth_yr = value; }
        }

        [DataMember(Name = "gender")]
        public string Gender
        {
            get { return gender; }
            set { gender = value; }

        }

        [DataMember(Name = "homeworld")]
        public string Home_World
        {
            get { return home_world; }
            set { home_world = value; }
        }

        [DataMember(Name = "created")]
        public string Created
        {
            get { return created; }
            set { created = value; }
        }

        [DataMember(Name = "edited")]
        public string Edited
        {
            get { return edited; }
            set { edited = value; }
        }

        [DataMember(Name = "url")]
        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        [DataMember(Name = "films")]
        public string[] Films
        {
            get { return films; }
            set { films = value; }
        }

        [DataMember(Name = "species")]

        public string[] Species
        {

            get { return species; }
            set { species = value; }
        }

        [DataMember(Name = "vehicles")]
        public string[] Vehicles
        {

            get { return vehicles; }
            set { vehicles = value; }
        }


        [DataMember(Name = "starships")]
        public string[] Starships
        {

            get { return starships; }
            set { starships = value; }
        }

        #endregion

        #region Person Methods

        //*****************************************************************
        //Method: Person
        //
        //Purpose: Default Constructor, Sets variables to a default value
        //
        //*****************************************************************
        public Person()
        {
            name = "defualt name";
            height = "default height";
            mass = "default mass";
            hair_color = "default hair_color";
            skin_color = "defailt skin_color";
            eye_color = "default eye_color";
            birth_yr = "default birth_yr";
            gender = "default gender";
            home_world = "default home";
            created = "default created";
            edited = "default edited";
            url = "http://default.co";
            films = new string[10];
            species = new string[10];
            vehicles = new string[10];
            starships = new string[10];

            //set default values for each array element.
            for(int i = 0; i<films.Length; i++)
            {
                films[i] = "default film";
                species[i] = "default species";
                vehicles[i] = "default vehicle";
                starships[i] = "default starship";


            }

        }

        //*****************************************************************
        //Method: ToString
        //
        //Purpose: Overide ToString, show descriptive text and data for
        //all member variables for Person.cs
        //
        //*****************************************************************
        public override string ToString()
        {
            return "Name: " + name + "\r\nHeight: " + height + "\r\nMass: " + mass + "\r\nHair Color: " + hair_color + "\r\nSkin color: "
                + skin_color + "\r\nEye Color: " + eye_color + "\r\nBirth Year: " + birth_yr + "\r\nGender: " + gender + "\r\nHome World: "
                + home_world + "\r\nCreated: " + created + "\r\nEdited: " + edited + "\r\nUrl:" + url + "\r\nFilms: " + show_films() + "\r\nSpecies: " + show_species()
                + "\r\nVehicles: " + show_vehicles() + "\r\nStarships: " + show_starships();

        }

        //*****************************************************************
        //Method: show_species
        //
        //Purpose: Shows all species in the species array
        //
        //
        //*****************************************************************
        public string show_species()
        {
            string myString = "";
            
            foreach(var myvar in species)
            {

                myString += "\r\n" + myvar;
            }

            return myString;
        }

        //*****************************************************************
        //Method: show_films
        //
        //Purpose: Shows all films in the films array
        //
        //
        //*****************************************************************
        public string show_films()
        {
            string myString = "";

            foreach (var myvar in films)
            {

                myString += "\r\n" + myvar;
            }

            return myString;
        }

        //*****************************************************************
        //Method: show_vehicles
        //
        //Purpose: Shows all vehicles in the vehicles array
        //
        //
        //*****************************************************************
        public string show_vehicles()
        {
            string myString = "";

            foreach (var myvar in vehicles)
            {

                myString += "\r\n" + myvar;
            }

            return myString;
        }

        //*****************************************************************
        //Method: show_starships
        //
        //Purpose: Shows all starships in the starships array
        //
        //
        //*****************************************************************
        public string show_starships()
        {
            string myString = "";

            foreach (var myvar in starships)
            {

                myString += "\r\n" + myvar;
            }

            return myString;
        }

        #endregion
    }
}
