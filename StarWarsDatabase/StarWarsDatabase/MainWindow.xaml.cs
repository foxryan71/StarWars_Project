//******************************************************
// File: MainWindow.xaml.cs
//
// Purpose: Contains a class called MainWindow.
//          has an instance of PlanetCollection
//          This class can Load Xml and JSON files.
//          into database and displays the database info.
//          Allows users to insert into database as well.
//          If content already exist it will not allow.
//         Everytime a new JSON/XML file is loaded it will
//         delete everything in the database.
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StarWars;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Data.SqlClient;

namespace StarWarsDatabase
{
   
    public partial class MainWindow : Window
    {
        private PlanetCollection ps;
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Menu Option Methods
        //*****************************************************************
        //Method: import_from_xml_file
        //
        //Purpose: imports data from xml file. Will delete database then
        //populates the data base with new content, will fill listbox 
        //with planet names.
        //*****************************************************************
        private void import_from_xml_file(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog xmldlg = new Microsoft.Win32.OpenFileDialog();

            xmldlg.DefaultExt = ".xml";
            xmldlg.Filter = "XML Files(*.xml)|*.xml";
            xmldlg.InitialDirectory = Directory.GetCurrentDirectory();
            Nullable<bool> result = xmldlg.ShowDialog();

            if (result == true)
            {
                string file_ext = xmldlg.FileName;
                FileStream fs = new FileStream(file_ext, FileMode.Open, FileAccess.Read);
                DataContractSerializer xml_ser = new DataContractSerializer(typeof(PlanetCollection));
                ps = (StarWars.PlanetCollection)xml_ser.ReadObject(fs);
                fs.Flush();
                fs.Close();
                
                //clear all databases
                delete_rows_from_films();
                delete_rows_from_residents();
                delete_rows_from_planets();
                //insert into database
                insert_planet_collection(ps);
                planet_name_listbox.Items.Clear();
                populate_planet_name_list_box();
            }
        }
       
        //*****************************************************************
        //Method: import_from_json_file
        //
        //Purpose: imports data from xml file. Will delete database then
        //populates the data base with new content, will fill listbox 
        //with planet names.
        //*****************************************************************
        private void import_from_json_file(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog jsondlg = new Microsoft.Win32.OpenFileDialog();

            jsondlg.DefaultExt = ".json";
            jsondlg.Filter = "JSON Files(*.json)|*.json";
            jsondlg.InitialDirectory = Directory.GetCurrentDirectory();
            Nullable<bool> result = jsondlg.ShowDialog();

            if (result == true)
            {
                string file_ext = jsondlg.FileName;

                FileStream fs = new FileStream(file_ext, FileMode.Open, FileAccess.Read);
                fs.Position = 0;
                DataContractJsonSerializer Json_ser = new DataContractJsonSerializer(typeof(PlanetCollection));
                ps = (StarWars.PlanetCollection)Json_ser.ReadObject(fs);
                fs.Flush();
                fs.Close();
                //clears all database rows
                delete_rows_from_planets();
                delete_rows_from_residents();
                delete_rows_from_films();
                //insert into database
                insert_planet_collection(ps);
                planet_name_listbox.Items.Clear();
                //populates planets list box
                populate_planet_name_list_box();
               
               
            }
        }
       
        //*****************************************************************
        //Method: exit
        //
        //Purpose: Terminates and exits the program.
        //*****************************************************************
        private void exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //*****************************************************************
        //Method: Window_loaded
        //
        //Purpose: Loads content from database and fills listbox, adds 
        // tool tips to buttons in application.
        //*****************************************************************
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            insert_new_planet_btn.ToolTip = "Insert Planet into DB";
            add_film_btn.ToolTip = "Add a film to this planet";
            add_resident_btn.ToolTip = "Add a resident to this planet";
            populate_planet_name_list_box();
        }
        //*****************************************************************
        //Method:about_info
        //
        //Purpose: Displays info about application
        //*****************************************************************
        private void about_info(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Star Wars Planet DB\r\nVersion 1.0\r\nWritten By Ryan Claude Fox","About StarWars Planets Database");
        }

        #endregion

        #region Insert Methods
        //*****************************************************************
        //Method: insert_into_planet_collection
        //
        //Purpose: Inserts all data into Planet,Films, and Resident tables.
        //Uses the PlanetCollection class to read to insert into database.
        //
        //*****************************************************************
        private void insert_planet_collection(PlanetCollection ps)
        {

            string connString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = StarWars; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();

            //inserts into Planets Table
            for (int i = 0; i < ps.Results.Length; i++)
            {
                string sql = $"INSERT INTO Planets(Name,RotationPeriod,OrbitalPeriod,Diameter,Climate,Gravity,Terrain,SurfaceWater,Population,Created,Edited,Url) Values('{ps.Results[i].Name}', '{ps.Results[i].Rotation}','{ps.Results[i].Orbital_Period}','{ps.Results[i].Diameter}','{ps.Results[i].Climate}','{ps.Results[i].Gravity}','{ps.Results[i].Terrain}', '{ps.Results[i].Surface_water}', '{ps.Results[i].Population}','{ps.Results[i].Created}','{ps.Results[i].Edited}','{ps.Results[i].URL}')";
                SqlCommand command = new SqlCommand(sql, sqlConn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }

            //insert into Residents Table
            for(int i = 0; i < ps.Results.Length; i++)
                
            {
                for (int j = 0; j < ps.Results[i].Residents.Length; j++)
                {
                    string sql = $"INSERT INTO Residents(Name,ResidentLink) VALUES('{ps.Results[i].Name}','{ps.Results[i].Residents[j]}')";
                    SqlCommand command = new SqlCommand(sql, sqlConn);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
            }

            //insert into Films Table
            for (int i = 0; i < ps.Results.Length; i++)
            {
                for (int j = 0; j < ps.Results[i].Films.Length; j++)
                {
                    string sql = $"INSERT INTO Films(Name,FilmLink) VALUES('{ps.Results[i].Name}','{ps.Results[i].Films[j]}')";
                    SqlCommand command = new SqlCommand(sql, sqlConn);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
            }


            sqlConn.Close();

        }

        //*****************************************************************
        //Method: insert_new_planet
        //
        //Purpose: Inserts all data into Planet,Films, and Resident tables.
        //Uses the textboxes and listbox's contents to insert into database.
        //
        //*****************************************************************
        private void insert_new_planet(object sender, RoutedEventArgs e)
        {

            Planet planet = new Planet();
            #region Setting Textbox.text to planet variables
            planet.Name = new_planet_name_txtbox.Text;
            planet.Rotation = new_planet_rotat_txtbox.Text;
            planet.Orbital_Period = new_planet_orb_txtbox.Text;
            planet.Diameter = new_planet_diameter_txtbox.Text;
            planet.Climate = new_planet_climate_txtbox.Text;
            planet.Gravity = new_planet_gravity_txtbox.Text;
            planet.Terrain = new_planet_terrain_txtbox.Text;
            planet.Surface_water = new_planet_terrain_txtbox.Text;
            planet.Population = new_planet_population_txtbox.Text;
            planet.Edited = new_planet_created_txtbox.Text;
            planet.URL = new_planet_url_txtbox.Text;
            #endregion

            #region Insert into Planets Table
            if (check_planet(planet.Name) == false)
            {
                string connString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = StarWars; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                SqlConnection sqlConn;
                sqlConn = new SqlConnection(connString);
                sqlConn.Open();


                string sql = $"INSERT INTO Planets(Name,RotationPeriod,OrbitalPeriod,Diameter,Climate,Gravity,Terrain,SurfaceWater,Population,Created,Edited,Url) Values('{planet.Name}', '{planet.Rotation}','{planet.Orbital_Period}','{planet.Diameter}','{planet.Climate}','{planet.Gravity}','{planet.Terrain}', '{planet.Surface_water}', '{planet.Population}','{planet.Created}','{planet.Edited}','{planet.URL}')";
                SqlCommand command = new SqlCommand(sql, sqlConn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                #endregion

                #region Insert into Films Table
                //read into films array
                //will take all the films inside the list box and insert into the database with the name entered in the name textbox.
                for (int i = 0; i < new_planet_films.Items.Count; i++)
                {
                    string film_query = $"INSERT INTO Films (Name,FilmLink) VALUES ('{new_planet_name_txtbox.Text}','{new_planet_films.Items[i].ToString()}')";
                    // films_array[i] = new_planet_films.Items[i].ToString();
                    SqlCommand film_command = new SqlCommand(film_query, sqlConn);
                    SqlDataReader film_reader = film_command.ExecuteReader();
                    film_reader.Close();
                }
                #endregion

                #region Insert into Residents Table
                //insert into residents table
                for (int i = 0; i < new_planet_residents.Items.Count; i++)
                {
                    string resident_query = $"INSERT INTO Residents (Name, ResidentLink) VALUES('{new_planet_name_txtbox.Text}', '{new_planet_residents.Items[i].ToString()}')";
                    SqlCommand resident_command = new SqlCommand(resident_query, sqlConn);
                    SqlDataReader resident_reader = resident_command.ExecuteReader();
                    resident_reader.Close();
                }
                #endregion

                #region Clearing Text/List boxes and reloading planet_name listbox
                sqlConn.Close();
                MessageBox.Show("INSERT SUCCESSFUL!");
                clear_txt_boxes();
                new_planet_residents.Items.Clear();
                new_planet_films.Items.Clear();
                planet_name_listbox.Items.Clear();
                populate_planet_name_list_box();
                #endregion
            }
            else
            {
                MessageBox.Show("Planet Already Exist!");
                new_planet_name_txtbox.BorderBrush = System.Windows.Media.Brushes.Red;
            }

          

        }
        #endregion

        #region Deleting Table Content Methods
        //*****************************************************************
        //Method: delete_rows_from_planets
        //
        //Purpose: Deletes all content inside the planet table.
        //*****************************************************************
        private void delete_rows_from_planets()
        {
            string connString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = StarWars; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();

            //deletes all rows in planets
            string sql = "Delete From Planets";
            SqlCommand command = new SqlCommand(sql, sqlConn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            sqlConn.Close();


        }
        //*****************************************************************
        //Method: delete_rows_from_residents
        //
        //Purpose: Deletes all content inside the Residents table
        //*****************************************************************
        private void delete_rows_from_residents()
        {
            string connString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = StarWars; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();

            //deletes all rows in planets
            string sql = "Delete From Residents";
            SqlCommand command = new SqlCommand(sql, sqlConn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            sqlConn.Close();

        }
        //*****************************************************************
        //Method: delete_rows_from_films
        //
        //Purpose: Deletes all content inside the Films table
        //*****************************************************************
        private void delete_rows_from_films()
        {
            string connString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = StarWars; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();

            //deletes all rows in planets
            string sql = "Delete From Films";
            SqlCommand command = new SqlCommand(sql, sqlConn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            sqlConn.Close();
        }
        #endregion

        #region TextBox Methods

        //*****************************************************************
        //Method: set_textbox_datacontext
        //
        //Purpose: sets all textbox fields datacontext properties to reader
        //Function must be sent a SqlDataReader
        //*****************************************************************
        private void set_textbox_datacontext(SqlDataReader reader)
        {
            //Data Binding for textbox

            name_txtbox.DataContext = reader;
            rotat_txtbox.DataContext = reader;
            orb_txtbox.DataContext = reader;
            dia_txtbox.DataContext = reader;
            climate_txtbox.DataContext = reader;
            gravity_txtbox.DataContext = reader;
            terrian_txtbox.DataContext = reader;
            surwater_txtbox.DataContext = reader;
            population_txtbox.DataContext = reader;
            created_txtbox.DataContext = reader;
            edited_txtbox.DataContext = reader;
            url_txtbox.DataContext = reader;

        }
        //*****************************************************************
        //Method: clear_txt_boxes
        //
        //Purpose: Clears all text boxes in the insert new planet tab
        //*****************************************************************
        private void clear_txt_boxes()
        {
                new_planet_name_txtbox.Clear();
                new_planet_rotat_txtbox.Clear();
                new_planet_orb_txtbox.Clear();
                new_planet_diameter_txtbox.Clear();
                new_planet_climate_txtbox.Clear();
                new_planet_gravity_txtbox.Clear();
                new_planet_terrain_txtbox.Clear();
                new_planet_surfwater_txtbox.Clear();
                new_planet_population_txtbox.Clear();
                new_planet_created_txtbox.Clear();
                new_planet_url_txtbox.Clear();
                new_planet_edited_txtbox.Clear();

        }

        #endregion

        #region Populate Listbox's Methods
        //*****************************************************************
        //Method: populate_film_list_box
        //
        //Purpose: Takes a SelectionChangedEvent, populates film_list_box
        //with content from Film table. Will display content associated
        // with that planets name.
        //*****************************************************************
        private void populate_films_list_box(SelectionChangedEventArgs e)
        {
            string connString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = StarWars; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();
            string sql = $"SELECT FilmLink FROM Films f JOIN Planets p ON f.Name = p.Name WHERE p.Name = '{e.AddedItems[0].ToString()}'";
            SqlCommand command = new SqlCommand(sql, sqlConn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                film_list_box.Items.Add((string)reader["FilmLink"]);
            }

        }

        //*****************************************************************
        //Method: populate_resident_list_box
        //
        //Purpose: Takes a SelectionChangedEvent, populates resident_list_box
        //with content from Residents table. Will display content associated
        // with that planets name.
        //*****************************************************************
        private void populate_residents_list_box(SelectionChangedEventArgs e)
        {
            string connString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = StarWars; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();
            string sql = $"SELECT ResidentLink FROM Residents r JOIN Planets p ON r.Name = p.Name WHERE p.Name = '{e.AddedItems[0].ToString()}'";
            SqlCommand command = new SqlCommand(sql, sqlConn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                resident_list_box.Items.Add((string)reader["ResidentLink"]);
            }

        }

        //*****************************************************************
        //Method: planet_name_listbox_SelectionChanged
        //
        //Purpose: To get and display the planets content from the database 
        // that is associated with that selected planets name in the 
        // planet_name_listbox.
        //*****************************************************************
        private void planet_name_listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (planet_name_listbox.Items.Count != 0)
            {
                string connString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = StarWars; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                SqlConnection sqlConn;
                sqlConn = new SqlConnection(connString);
                sqlConn.Open();
                string sql = $"SELECT * FROM Planets WHERE Name = '{e.AddedItems[0].ToString()}'";
                SqlCommand command = new SqlCommand(sql, sqlConn);
                SqlDataReader reader = command.ExecuteReader();
                set_textbox_datacontext(reader);

                //clear list boxes 
                resident_list_box.Items.Clear();
                film_list_box.Items.Clear();

                //now populate list boxes
                populate_residents_list_box(e);
                populate_films_list_box(e);

                //close connection
                sqlConn.Close();
            }
        }
        //*****************************************************************
        //Method: populate_planet_name_list_box
        //
        //Purpose: Populates the planet_name_listbox with content from database
        //*****************************************************************
        private void populate_planet_name_list_box()
        {
            string connString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = StarWars; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();
            string sql = "SELECT Name FROM Planets";
            SqlCommand command = new SqlCommand(sql, sqlConn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                planet_name_listbox.Items.Add((string)reader["Name"]);
            }
            planet_name_listbox.SelectedIndex = 0;
            sqlConn.Close();

        }
        #endregion

        #region Add Button Methods
        //*****************************************************************
        //Method:add_film
        //
        //Purpose: Adds film to new_planet_films listbox on the insert
        // new planet tab from the new_film_txtbox. If Film already exist
        // it will display an MessageBox notifaction
        //*****************************************************************
        private void add_film(object sender, RoutedEventArgs e)
        {
            //Will not add to film list box if it has already been added.
            if (new_planet_films.Items.Contains(new_film_txtbox.Text))
            {
                MessageBox.Show("Film already exist for this planet name");
            }
            else
            {
                if (new_film_txtbox.Text.Trim().Length > 0)
                {
                    new_planet_films.Items.Add(new_film_txtbox.Text.Trim());
                    new_film_txtbox.Clear();
                }
                else
                {
                    MessageBox.Show("Cannot enter in a empty value!");
                }
            }

        }

        //*****************************************************************
        //Method:add_resident
        //
        //Purpose: Adds resident to new_planet_residents listbox on the insert
        // new planet tab from the new_resident_txtbox. If resident already exist
        // it will display an MessageBox notifaction
        //*****************************************************************
        private void add_resident(object sender, RoutedEventArgs e)
        {
            //Will not add to resident list box if it has already been added.
            if (new_planet_residents.Items.Contains(new_resident_txtbox.Text))
            {
                MessageBox.Show("Resident already exist for this planet name!");
            }
            else
            {
                if (new_resident_txtbox.Text.Trim().Length > 0)
                {
                    
                    new_planet_residents.Items.Add(new_resident_txtbox.Text.Trim());
                    new_resident_txtbox.Clear();
                }
                else
                {
                    MessageBox.Show("Cannot enter in a empty vaule");
                }
            }
        }
        #endregion

        #region Check Planet Methods
        //*****************************************************************
        //Method:check_planet
        //
        //Purpose: Takes a string thats the planets name. Checks if that
        // planets name exist already in the database. If it does return
        // true if not return false.
        //*****************************************************************
        private bool check_planet(string planet_name)
        {
            
            string connString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = StarWars; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();
            string sql = $"SELECT * FROM Planets where name = '{planet_name}'";
            SqlCommand command = new SqlCommand(sql, sqlConn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion
    }//end of main window class
}