
//******************************************************
// File:StarWarsUnitTesting.cs
//
// Purpose: Contains the class definition for StarWarsUnitTesting.
//          Will unit test each property of both Planet and Person.
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

namespace StarWars
{

    
    public class StarWarsUnitTesting
    {

        //*****************************************************************
        //Method: UnitTestPerson
        //
        //Purpose: To test all properties from the Person class
        //
        //*****************************************************************
        public void UnitTestPerson()
        {

            #region Test Variables

            string name = "Luke Skywalker";
            string height = "172";
            string mass = "77";
            string hair_color = "Blond";
            string skin_color = "fair";
            string eye_color = "blue";
            string birth_yr = "19BBY";
            string gender = "male";
            string homeworld = "http://swapi.co/api/planets/1/";
            string created = "2014-12-09T13:50:51.64000Z";
            string edited = "2014-12-20T21:17:56.891000Z";
            string url = "http://swapi.co/api/people/1";
            StarWars.Person test = new StarWars.Person();
            #endregion

           
            #region Assigning test

            test.Name = name;
            test.Height = height;
            test.Mass = mass;
            test.Hair_Color = hair_color;
            test.Skin_Color = skin_color;
            test.Eye_Color = eye_color;
            test.Birth_Yr = birth_yr;
            test.Gender = gender;
            test.Home_World = homeworld;
            test.Created = created;
            test.Edited = edited;
            test.URL = url;

            #endregion


            #region Unit Test
            Console.WriteLine("\r\n");
            Console.WriteLine("Person Unit Testing");
            Console.WriteLine("==============================================\r\n");
            //Testing name
            if (test.Name == name)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Name\" \r\n");
            }

            //Testing height
            if (test.Height == height)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Height\" \r\n");
            }

            //Testing mass
            if (test.Mass == mass)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Mass\" \r\n");
            }

            //Testing hair color
            if (test.Hair_Color == hair_color)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Hair Color\" \r\n");
            }

            //Testing skin color
            if (test.Skin_Color == skin_color)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Skin Color\" \r\n");
            }

            if (test.Eye_Color == eye_color)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Eye Color\" \r\n");
            }

            if (test.Birth_Yr == birth_yr)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Birth Year\" \r\n");
            }

            if(test.Gender == gender)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Gender\"\r\n");
            }

            if (test.Home_World == homeworld)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Home World\"\r\n");
            }
            if (test.Created == created)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Created\"\r\n");
            }
            if (test.Edited == edited)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Edited\"\r\n");
            }
            if (test.URL == url)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Url\"\r\n");
            }

            #endregion

            Console.WriteLine("==============================================\r\n");
            Console.WriteLine("\r\n");


        }


        //*****************************************************************
        //Method: UnitTestPlanet
        //
        //Purpose: To test all properties from the Planet class
        //
        //*****************************************************************
        public void UnitTestPlanet()
        {

            #region Test Variables
            string name = "Aleraan";
            string roation_period = "24";
            string orbital_period = "364";
            string diameter = "12500";
            string climate = "temperate";
            string gravity = "1 standard";
            string terrain = "grasslands, mountains";
            string surface_water = "40";
            string population = "2000000000";
            string created = "2014-12-10T11:35:48.497000Z";
            string edited = "2014-12-20T20:58:18.420000Z";
            string url = "http://swapi.co/api/planets/2";
            StarWars.Planet test = new StarWars.Planet();

            #endregion

            #region Assigning test

            //set all variables for test of type Planet
            test.Name = name;
            test.Rotation = roation_period;
            test.Orbital_Period = orbital_period;
            test.Diameter = diameter;
            test.Climate = climate;
            test.Gravity = gravity;
            test.Terrain = terrain;
            test.Surface_water = surface_water;
            test.Population = population;
            test.Created = created;
            test.Edited = edited;
            test.URL = url;


            #endregion

            #region Unit Test


            Console.WriteLine("Planet Unit Testing");
            Console.WriteLine("==============================================\r\n");
            //test name property
            if (test.Name == name)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Name\" \r\n");
            }

            //test rotation period property
            if (test.Rotation == roation_period)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Roation Period\" \r\n");
            }

            //test orbital period property
            if (test.Orbital_Period == orbital_period)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Orbital Period\" \r\n");
            }

            //test diameter property
            if (test.Diameter == diameter)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Diameter\" \r\n");
            }

            // test climate property
            if (test.Climate == climate)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Climate\" \r\n");
            }
            //test gravity
            if (test.Gravity == gravity)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Gravity\" \r\n");
            }
            // test terrain property
            if (test.Terrain == terrain)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Terrain\" \r\n");
            }
            //test surface water property
            if (test.Surface_water == surface_water)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Surface Water\"\r\n");
            }
            
            //test population property
            if (test.Population == population)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Population\"\r\n");
            }

            //test created property
            if (test.Created == created)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Created\"\r\n");
            }

            //test edited property
            if (test.Edited == edited)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Edited\"\r\n");
            }

            //test url property
            if (test.URL == url)
            {
                Console.WriteLine("Success \r\n");
            }
            else
            {
                Console.WriteLine("Failure: \"Url\"\r\n");
            }
            Console.WriteLine("==============================================\r\n");
            #endregion

        }

    }
}
