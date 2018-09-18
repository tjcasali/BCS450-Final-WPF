//******************************************************
// File: CourseCollection.cs
//
// Purpose: Holds a list of all of the Course Objects
//
// Written By: Tim Casali
//
// Compiler: Visual Studio 2013
//
//******************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HW2DLL
{
    [DataContract]
    public class CourseCollection
    {
        #region Course Collection Member Variables
        [DataMember(Name = "courses")]
        public List<Course> courses = new List<Course>();
        #endregion

        #region Course Collection Properties
        public List<Course> Courses { get; set; }
        #endregion

        #region Course Collection Methods
        //****************************************************
        // Method: CourseCollection()
        //
        // Purpose: Default constructor for CourseCollection
        //****************************************************
        public CourseCollection()
        {
            courses = new List<Course>();
        }

        //****************************************************
        // Method: Course Find(int courseId)
        //
        // Purpose: Find the course with the given CourseId
        //****************************************************
        public Course Find(int courseId)
        {
           Course cFind = new Course();
           foreach(Course c in courses)
           {
               if(c.Id == courseId)
               {
                   cFind = c;
               }
           }
           return cFind;
        }

        //****************************************************
        // Method: Course Find(string designator, string Number)
        //
        // Purpose: Find the course with the given designator and number
        //****************************************************
        public Course Find(string designator, string Number)
        {
            Course cFind = new Course();
            foreach (Course c in courses)
            {
                if (c.Designator == designator && c.Number == Number)
                {
                    cFind = c;
                }
            }
            return cFind;
        }

        //****************************************************
        // Method: ToString()
        //
        // Purpose: Prints all of the Courses in the Course
        // Collection using a foreach loop that adds the
        // strings to a collective string
        //****************************************************
        public override string ToString()
        {
            string collectionString = "";
            foreach (Course c in courses)
            {
                collectionString += c.ToString();
                collectionString += "\n";
            }
            return collectionString;
        }

        //****************************************************
        // Method: AddObject(Course c)
        //
        // Purpose: Adds the course from the textboxes in the GUI
        //          to the course collection
        //****************************************************
        public void AddObject(Course c)
        {
            courses.Add(c);
        }

        #endregion
    }
}


