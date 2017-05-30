//**************************************************************************
//File: Program.cs
//
//Purpose: Contains the class of Program that has  Main.
// This Main create an instance StarWarsUniting and will run the PersonUnitTest and PlanetUnitTest functions.
// Declares an instance of Planet and Person and set its variables.
// Serializes and Deseralizes the data to and from JSON format.
//
//Written By: Ryan Claude Fox
//
//Compiler: Visual Studio 2015
//
//***************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using StarWars;
using System.Runtime.Serialization.Json;
using System.IO;
namespace Main_Project
{
    class Program
    {

        //*****************************************************************
        //Method: Main(string[] args)
        //
        //Purpose: Main, Displays a menu that allows a user to select
        //          from a number of options. Will allow you to preform
        //          as many task as you want. Will run atleast once.
        //*****************************************************************
        static void Main(string[] args)
        {
      
            #region Local Variables
            int choice = 0, index;
            string filename;
            StarWars.StarWarsUnitTesting Test = new StarWars.StarWarsUnitTesting();
            FileStream fs;
            DataContractJsonSerializer Json_ser;
            DataContractSerializer xml_ser;
            MemoryStream ms;
            #endregion

            #region JSON Serialization format

            DataContractJsonSerializerSettings Settings = new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true };
            #endregion

            #region Setting person_collection_1

        
            StarWars.PersonCollection person_collection_1 = new StarWars.PersonCollection();
          
            #endregion
      
            #region Setting planet_collection_1
            StarWars.PlanetCollection planet_collection_1 = new StarWars.PlanetCollection();
            planet_collection_1.Count = 61;
            planet_collection_1.Next = "http://swapi.co/api/planets/?page=2?";
            planet_collection_1.Previous = "null";
            planet_collection_1[0].Name = "Alderaan";
            planet_collection_1[0].Rotation = "24";
            planet_collection_1[0].Orbital_Period = "364";
            planet_collection_1[0].Diameter = "12500";
            planet_collection_1[0].Climate = "temperate";
            planet_collection_1[0].Gravity = "1 standard";
            planet_collection_1[0].Terrain = "grasslands,mountains";
            planet_collection_1[0].Surface_water = "40";
            planet_collection_1[0].Population = "2000000000";
            planet_collection_1[0].Residents[0] = "http://heheh.com/api";
            planet_collection_1[0].Residents[1] = "http://heheh.com/api";
            planet_collection_1[0].Residents[2] = "http://heheh.com/api";
            planet_collection_1[0].Films[0] = "http://films.com";
            planet_collection_1[0].Films[1] = "http://films.com";
            planet_collection_1[0].Films[2] = "http://films.com";
            planet_collection_1[0].Created = "2014-12-10T11:35:48.497000Z";
            planet_collection_1[0].Edited = "2014-12-20T20:58:18.420000Z";
            planet_collection_1[0].URL = "http://swapi.co/api/planets/2";
            #endregion

            #region Menu

            //Displays menu, do while till a certain condition is met.
            do
            {
                Console.WriteLine("\r\nStar Wars Menu \r\n");
                Console.WriteLine("===============\r\n");
                Console.WriteLine("1 - Read PersonCollection from JSON file\r\n");
                Console.WriteLine("2 - Read PersonCollection from XML file\r\n");
                Console.WriteLine("3 - Write PersonCollection to JSON file\r\n");
                Console.WriteLine("4 - Write PersonCollection to XML file \r\n");
                Console.WriteLine("5 - Display PersonCollection data on screen\r\n");
                Console.WriteLine("6 - Read PlanetCollection from JSON file\r\n");
                Console.WriteLine("7 - Read PlanetCollection from XML file \r\n");
                Console.WriteLine("8 - Write PlanetCollection to JSON file\r\n");
                Console.WriteLine("9 - Write PlanetCollection to XML file\r\n");
                Console.WriteLine("10 - Display PlanetCollection data to screen\r\n");
                Console.WriteLine("11 - Run regression test on Person\r\n");
                Console.WriteLine("12 - Run regression test on Planet\r\n");
                Console.WriteLine("13 - Display Person at given index of PersonCollection\r\n");
                Console.WriteLine("14 - Display Planet at given index of PlanetCollection\r\n");
                Console.WriteLine("15 - Exit\r\n");
                Console.WriteLine("Enter Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());


                #endregion

            #region Menu Cases
                switch (choice)
                {

                    case 1:
                        try
                        {
                            Console.WriteLine("Please Enter the name of the PersonCollection JSON file.\r\n");
                            filename = Console.ReadLine();
                            fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                            fs.Position = 0;
                            Json_ser = new DataContractJsonSerializer(typeof(PersonCollection),Settings);
                            person_collection_1 = (StarWars.PersonCollection)Json_ser.ReadObject(fs);
                            fs.Flush();
                            fs.Close();
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("File Does not exist! Please enter in a valid file!");
                        }
                         break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Please Enter the name of the PersonCollection XML file.\r\n");
                            filename = Console.ReadLine();
                            fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                            fs.Position = 0;
                        
                            xml_ser = new DataContractSerializer(typeof(PersonCollection));
                            person_collection_1 = (StarWars.PersonCollection)xml_ser.ReadObject(fs);
                          
                            fs.Flush();

                         
                            fs.Close();
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("File Does not exist! Please enter in a valid file!");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Please enter the JSON file name you would like to have PersonCollection written to.");
                        filename = Console.ReadLine();
                        fs = new FileStream(filename, FileMode.Create, FileAccess.Write);

                    
                        Json_ser = new DataContractJsonSerializer(typeof(PersonCollection), Settings);
                       
                        Json_ser.WriteObject(fs,person_collection_1);
                        fs.Flush();
                        fs.Close();

                        break;
                    case 4:
                        Console.WriteLine("Please enter the XML file name you would like to have PersonCollection written to.");
                        filename = Console.ReadLine();
                        fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                        xml_ser = new DataContractSerializer(typeof(PersonCollection));
                       
                        xml_ser.WriteObject(fs, person_collection_1);
                        fs.Flush();
                        fs.Close();

                        break;

                    case 5:
                        MemoryStream person_collection_mem = new MemoryStream();
                        Json_ser = new DataContractJsonSerializer(typeof(PersonCollection), Settings);
                        var person_collection_writer = JsonReaderWriterFactory.CreateJsonWriter(person_collection_mem, Encoding.UTF8, true, true);
                        Json_ser.WriteObject(person_collection_writer, person_collection_1);
                        person_collection_mem.Position = 0;
                        StreamReader person_col_sr = new StreamReader(person_collection_mem);
                        
                        
                        //Print out stream to screen
                        Console.WriteLine(person_col_sr.ReadToEnd());
                        
                        //close file
                        person_col_sr.Close();

                        try
                        {
                            Console.WriteLine("\r\n Person Collection ToString\r\n");
                            Console.WriteLine("====================================\r\n");
                            Console.WriteLine(person_collection_1.ToString());
                            Console.WriteLine("====================================\r\n");
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Null");
                        }                  
                        break;
                    case 6:
                        //get name of file
                        Console.WriteLine("Please Enter the name of the PlanetCollection JSON file.\r\n");
                        filename = Console.ReadLine();

                        try
                        {
                            fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                            DataContractJsonSerializer plan_col_ser_Json = new DataContractJsonSerializer(typeof(PlanetCollection), Settings);
                            planet_collection_1 = (StarWars.PlanetCollection)plan_col_ser_Json.ReadObject(fs);
                            fs.Close();
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("File Does not exist! Please enter in a valid file!");
                        }

                        break;

                    case 7:
                        try
                        {
                            Console.WriteLine("Please Enter the name of the PlanetCollection XML file.\r\n");
                            filename = Console.ReadLine();
                            fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                            xml_ser = new DataContractSerializer(typeof(PlanetCollection));
                            planet_collection_1 = (StarWars.PlanetCollection)xml_ser.ReadObject(fs);
                            fs.Flush();
                            fs.Close();
                        }
                        catch(FileNotFoundException)
                        {
                            Console.WriteLine("File Does not exist! Please enter in a valid file!");
                        }
                        break;

                    case 8:
                        Console.WriteLine("Please enter the JSON file name you would like to have PlanetCollection written to.");
                        filename = Console.ReadLine();
                        fs = new FileStream(filename, FileMode.Create, FileAccess.Write);


                        Json_ser = new DataContractJsonSerializer(typeof(PlanetCollection), Settings);

                        Json_ser.WriteObject(fs, planet_collection_1);
                        fs.Flush();
                        fs.Close();
                        break;
                    case 9:

                        //Prints PlanetCollection in XML format to the desired file.
                        Console.WriteLine("Please enter the XML file name you would like to have PlanetCollection written to.");
                        filename = Console.ReadLine();
                        fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                        xml_ser = new DataContractSerializer(typeof(PlanetCollection));

                        xml_ser.WriteObject(fs, planet_collection_1);
                        fs.Flush();
                        fs.Close();

                        break;

                    case 10:
                        MemoryStream planet_collection_mem = new MemoryStream();
                        Json_ser = new DataContractJsonSerializer(typeof(PlanetCollection), Settings);
                        var planet_collection_writer = JsonReaderWriterFactory.CreateJsonWriter(planet_collection_mem, Encoding.UTF8, true, true);
                        Json_ser.WriteObject(planet_collection_writer, planet_collection_1);
                        planet_collection_mem.Position = 0;
                        StreamReader planet_col_sr = new StreamReader(planet_collection_mem);

                        Console.WriteLine(planet_col_sr.ReadToEnd());
                        planet_col_sr.Close();

                        Console.WriteLine("\r\n Planet Collection ToString\r\n");
                        Console.WriteLine("====================================\r\n");
                        Console.WriteLine(planet_collection_1.ToString());
                        Console.WriteLine("====================================\r\n");
                        break;

                    case 11:
                        //Test Person
                        Test.UnitTestPerson();
                        break;
                    case 12:
                        //Test Planet
                        Test.UnitTestPlanet();
                        break;
                    case 13:
                        Console.WriteLine("Please enter an index for Person");
                        index = Convert.ToInt32(Console.ReadLine());

                        //takes index and checks if its in bounds if not will write an error, Doesn't cause program to crash.
                        try
                        {
                            Console.WriteLine(person_collection_1[index].ToString());
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            Console.WriteLine("You've entered in an index that is out of bounds! (Person doesnt exist)");
                        }
                        break;
                    case 14:
                        Console.WriteLine("Please enter an index for Planet");
                        index = Convert.ToInt32(Console.ReadLine());
                        //takes index and checks if its in bounds if not will write an error, Doesn't cause program to crash.
                        try
                        {
                            Console.WriteLine(planet_collection_1[index].ToString());
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            Console.WriteLine("You've entered in an index that is out of bounds! (Planet doesnt exist)");
                        }
                        break;
                    case 15:
                        
                        break;

                    default:

                        Console.WriteLine("Invalid Option!\r\n");
                        break;
                }

            } while (choice != 15); //end of do while
            #endregion



         }//end of Main
    } // end of class program
} //end of Main_Project namespace
