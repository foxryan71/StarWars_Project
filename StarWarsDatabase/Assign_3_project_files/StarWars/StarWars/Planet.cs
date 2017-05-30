
//******************************************************
// File:Planet.cs
//
// Purpose: Contains the class definition for Planet.
//          Will hold all planet information 
//          such as name, rotation_period, orbital_period,
//         diameter, climate, gravity, terrain, surface_water,
//          population, created, edited, and url.
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
    public class Planet
    {
        #region Planet Member Variables
        private string name;
        private string rotation_period;
        private string orbital_period;
        private string diameter;
        private string climate;
        private string gravity;
        private string terrain;
        private string surface_water;
        private string population;
        private string created;
        private string edited;
        private string url;
        private string[] films;
        private string[] residents;

        #endregion

        #region Planet Properties

        [DataMember (Name = "name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember(Name = "rotation_period")]
        public string Rotation
        {
            get { return rotation_period; }
            set { rotation_period = value; }
        }

        [DataMember(Name = "orbital_period")]
        public string Orbital_Period
        {
            get { return orbital_period; }
            set { orbital_period = value; }

        }

        [DataMember(Name = "diameter")]
        public string Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }

        [DataMember(Name = "climate")]
        public string Climate
        {
            get { return climate; }
            set { climate = value; }
        }

        [DataMember(Name = "gravity")]
        public string Gravity
        {
            get { return gravity; }
            set { gravity = value; }

        }

        [DataMember(Name = "terrain")]
        public string Terrain
        {
            get { return terrain; }
            set { terrain = value; }

        }

        [DataMember(Name = "surface_water")]
        public string Surface_water
        {
            get { return surface_water; }
            set { surface_water = value; }
        }

        [DataMember(Name = "population")]
        public string Population
        {
            get { return population; }
            set { population = value; }

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

        [DataMember(Name = "residents")]
        public string[] Residents
        {
            get { return residents; }
            set { residents = value; }

        }


        #endregion

        #region Planet Methods

        //*****************************************************************
        //Method: Planet
        //
        //Purpose: Default Constructor, Sets variables to a default value
        //
        //*****************************************************************
        public Planet()
        {
            name = "default name";
            rotation_period = "default rotation";
            orbital_period = "default orbital period";
            diameter = "default diameter";
            climate = "default climate";
            gravity = "default gravity";
            terrain = "default terrain";
            surface_water = "default surface water";
            population = "default population";
            created = "default created";
            edited = "default edited";
            url = "http://default.co";
            films = new string[10];
            residents = new string[10];

            //set default values for each array element.
            for (int i = 0; i < films.Length; i++)
            {
                films[i] = "default film";
                residents[i] = "default residents";

            }

        }


        //*****************************************************************
        //Method: ToString
        //
        //Purpose: Overide ToString, show descriptive text and data for
        //all member variables for Planet.cs.
        //
        //*****************************************************************

        public override string ToString()
        {
           

            return "Name: " + name + "\r\nRotation: " + rotation_period + "\r\nOrbital Period: " + orbital_period + "\r\nDiameter: " + diameter + "\r\nClimate: "
                + climate + "\r\nGravity: " + gravity + "\r\nTerrain: " + terrain + "\r\nSurface Water: " + surface_water + "\r\nPopulation: "
                + population + "\r\nCreated: " + created + "\r\nEdited: " + edited + "\r\nUrl:" + url + "\r\nFilms: " + show_films() + "\r\nResidents: " + show_residents();
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
        //Method: show_residents
        //
        //Purpose: Shows all residents in the residents array
        //
        //
        //*****************************************************************

        public string show_residents()
        {
            string myString = "";

            foreach (var myvar in residents)
            {

                myString += "\r\n" + myvar;
            }

            return myString;
        }

        #endregion

    }
}
