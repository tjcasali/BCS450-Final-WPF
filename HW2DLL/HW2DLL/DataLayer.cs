 //****************************************************
// File: DataLayer.cs
//
// Purpose: Used by the CourseScheduleWPF. Holds all of the 
//          CourseCollection information that is to be used
//          by the buttons in the GUI.
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
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace HW2DLL
{
    [DataContract]
    public class DataLayer
    {
        #region DataLayer Member Variables
        [DataMember(Name = "cc")]
        private CourseCollection cc = new CourseCollection();

        [DataMember(Name = "pc")]
        private ProfessorCollection pc = new ProfessorCollection();
        #endregion

        #region DataLayer Properties
        public CourseCollection Courses { get; set; }
        public ProfessorCollection Professors { get; set; }
        #endregion

        #region DataLayer Methods
        //****************************************************
        // Method: DataLayer()
        //
        // Purpose: Default constructor for DataLayer
        //****************************************************
        public DataLayer()
        {
            cc = new CourseCollection();
        }

        //****************************************************
        // Method: courseInitialize()
        //
        // Purpose: This is the method called when the 'Open Course Collection'
        //          button is clicked. Contains serialization code that
        //          destructs the courses.json file that is selected in the OFD
        //
        //****************************************************
        public void courseInitialize(string filename)
        {
            DataContractJsonSerializer inputSerializer;
            FileStream reader;

            reader = new FileStream(filename, FileMode.Open, FileAccess.Read); 
            inputSerializer = new DataContractJsonSerializer(typeof(HW2DLL.CourseCollection));
            cc = (CourseCollection)inputSerializer.ReadObject(reader);
            reader.Close();
        }

        //****************************************************
        // Method: professorInitialize(string filename)
        //
        // Purpose: This is the method called when the 'Open Professor Collection'
        //          button is clicked. Contains deserialization code that
        //          destructs the professors.json file that is selected in the OFD.
        //          This is different from the courseInitialize function because we
        //          are returning the professor collection we deserialize and returning
        //          it to the WPF when called. This will allow us to add it to the List
        //          View
        //
        //****************************************************
        public ProfessorCollection professorInitialize(string filename)
        {
            DataContractJsonSerializer inputSerializer;
            FileStream reader;

            reader = new FileStream(filename, FileMode.Open, FileAccess.Read); 
            inputSerializer = new DataContractJsonSerializer(typeof(HW2DLL.ProfessorCollection));
            pc = (ProfessorCollection)inputSerializer.ReadObject(reader);
            reader.Close();
            return pc;
        }

        //****************************************************
        // Method: ToString()
        //
        // Purpose: Calls the ToString in CourseCollection.cs
        //          to print out each individual class
        //****************************************************
        public override string ToString()
        {
            return cc.ToString();
        }

        //****************************************************
        // Method: Find(int courseId)
        //
        // Purpose: Calls the Find function within the CourseCollection.cs file.
        //          This is called when the Find By Course ID button is clicked.
        //****************************************************
        public Course Find(int courseId)
        {
            return cc.Find(courseId);
        }

        //****************************************************
        // Method: Find(string designator, string number)
        //
        // Purpose: Calls the Find function within the CourseCollection.cs file.
        //          This is called when the Find By Course Designator and Number
        //          button is clicked.
        //****************************************************
        public Course Find(string designator, string number)
        {
            return cc.Find(designator, number);
        }
        #endregion

        #region Homework 3 Methods
        //****************************************************
        // Class: CourseAddedEventArgs
        //
        // Purpose: Custom event args for the Course Added function
        //****************************************************
        public class CourseAddedEventArgs : EventArgs
        {
            public Course CourseAdded { get; set; }

            public CourseAddedEventArgs(Course cae)
            {
                CourseAdded = cae;
            }
        }

        //****************************************************
        // Method: FireCourseAddedEvent(Course c)
        //
        // Purpose: Checks to see if anyone is subscribed to this event,
        //          then creates an instance of the event args and puts
        //          the course inside of it, then fires the event
        //****************************************************
        public void FireCourseAddedEvent(Course c)
        {
            //Is anyone subscribed to the event?
            if (CourseAddedEvent == null)
                return;
            //Create an instance of the event args
            DataLayer.CourseAddedEventArgs evtArgs = new DataLayer.CourseAddedEventArgs(c);
            //Fire the Course Added event
            CourseAddedEvent(this, evtArgs);
        }

        //Declare the Course Added Event
        public event EventHandler<CourseAddedEventArgs> CourseAddedEvent;

        //****************************************************
        // Method: AddCourse(Course c)
        //
        // Purpose: This is what's called originally when clicking
        //          the Add Course button. Inside it adds the
        //          course in the text boxes to the collection
        //          and fires the CourseAdded Event
        //****************************************************
        public bool AddCourse(Course c)
        {
            cc.AddObject(c);
            FireCourseAddedEvent(c);
            return true;
        }
        #endregion

    }
}
