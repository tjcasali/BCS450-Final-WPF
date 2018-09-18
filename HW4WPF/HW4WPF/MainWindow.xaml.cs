//****************************************************
// File: MainWindow.xaml.cs
//
// Purpose: Event Handlers for the buttons in the GUI
//
// Written By: Tim Casali
//
// Compiler: Visual Studio 2013
//****************************************************
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
using HW2DLL;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
namespace HW4WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region XAML Member Variables
        private DataLayer dl = new DataLayer();
        private CourseCollection cc = new CourseCollection();
        ProfessorCollection pc = new ProfessorCollection();
        #endregion

        #region XAML Methods
        //****************************************************
        // Method: MainWindow()
        //
        // Purpose: Initializes the window
        //****************************************************
        public MainWindow()
        {
            InitializeComponent();
        }

        //****************************************************
        // Method: OpenCourseCollButton_Click(object sender, RoutedEventArgs e)
        //
        // Purpose: When this button is clicked, an open file dialog is created and prompts
        //          the user to select the courses.json file. When selected, it deserializes the
        //          JSON and loads the data into the data layer
        //****************************************************
        private void OpenCourseCollButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\Users\\timca\\OneDrive\\Documents\\Visual Studio 2013\\Projects\\HW4WPF\\HW4WPF\\bin\\Debug";
            ofd.Filter = "Json files|*.json";
            ofd.Title = "Open Course Collection from JSON";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dl.courseInitialize(ofd.FileName);

                //Clear all text boxes
                IdTextBox.Text = "";
                DesignatorTextBox.Text = "";
                NumberTextBox.Text = "";
                TitleTextBox.Text = "";
                DescriptionTextBox.Text = "";
                CreditsTextBox.Text = "";
                FindCourseIdTextbox.Text = "";
                FindCourseDesignatorTextbox.Text = "";
                FindCourseNumberTextbox.Text = "";

                //Put the path of the selected file into the text box
                string filePath = ofd.FileName;
                CourseFilenameTextbox.Text = filePath;
            }
        }

        //****************************************************
        // Method: OpenProfessorCollButton_Click(object sender, RoutedEventArgs e)
        //
        // Purpose: When this button is clicked, an open file dialog is created and prompts
        //          the user to select the professors.json file. When selected, it deserializes the
        //          JSON and loads the data into the data layer. Then, the data is looped through and
        //          added to the Professor List View at the bottom of the GUI.
        //****************************************************
        private void OpenProfessorCollButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\Users\\timca\\OneDrive\\Documents\\Visual Studio 2013\\Projects\\HW4WPF\\HW4WPF\\bin\\Debug";
            ofd.Filter = "Json files|*.json";
            ofd.Title = "Open Professor Collection from JSON";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Set the local Professor Collection equal to the deserialized file
                pc = dl.professorInitialize(ofd.FileName);

                //int size = ofd.FileName.Length;   //Return 101 instead of 12
                
                StreamReader sr = new StreamReader(ofd.FileName);

                

                while (!sr.EndOfStream)
                {
                    ProfessorListView.Items.Add(sr.ReadLine());
                }
                //for (int i = 1; i < 12; i++)                     //Wanted to use size as the boundry for the for loop but it
                //{                                                //wasn't returning the right value so I hardcoded 12 in.
                //    ProfessorListView.Items.Add(pc.Find(i));
                //}

                //Put the path of the selected file into the text box
                string filePath = ofd.FileName;
                ProfessorFilenameTextbox.Text = filePath;
            }

        }
        //****************************************************
        // Method: FindByCourseButton_Click(object sender, RoutedEventArgs e)
        //
        // Purpose: When this button is clicked, the Find function in the data layer is called
        //          to find the Course with the corresponding ID number that was in the text box.
        //          If found, the course information is placed into the text boxes.
        //****************************************************
        private void FindByCourseButton_Click(object sender, RoutedEventArgs e)
        {
            int IdInTextBox = int.Parse(FindCourseIdTextbox.Text);
            Course cFind = new Course();

            cFind = dl.Find(IdInTextBox);

            //Fill the text boxes with the found file
            IdTextBox.Text = Convert.ToString(cFind.Id);
            DesignatorTextBox.Text = cFind.Designator;
            NumberTextBox.Text = cFind.Number;
            TitleTextBox.Text = cFind.Title;
            CreditsTextBox.Text = Convert.ToString(cFind.Credits);
            DescriptionTextBox.Text = cFind.Description;

            FindCourseNumberTextbox.Text = "";
            FindCourseDesignatorTextbox.Text = "";

        }

        //****************************************************
        // Method: FindByDesignatorButton_Click(object sender, RoutedEventArgs e)
        //
        // Purpose: When this button is clicked, the Find function in the data layer is called
        //          to find the Course with the corresponding designator and number that was in the text box.
        //          If found, the course information is placed into the text boxes.
        //****************************************************
        private void FindByDesignatorButton_Click(object sender, RoutedEventArgs e)
        {

            string DesignatorInTextBox = FindCourseDesignatorTextbox.Text;
            string NumberInTextBox = FindCourseNumberTextbox.Text;
            Course cFind = new Course();

            cFind = dl.Find(DesignatorInTextBox, NumberInTextBox);

            //Fill the text boxes with the found file
            IdTextBox.Text = Convert.ToString(cFind.Id);
            DesignatorTextBox.Text = cFind.Designator;
            NumberTextBox.Text = cFind.Number;
            TitleTextBox.Text = cFind.Title;
            CreditsTextBox.Text = Convert.ToString(cFind.Credits);
            DescriptionTextBox.Text = cFind.Description;

            FindCourseIdTextbox.Text = "";
        }
        #endregion
    }
}