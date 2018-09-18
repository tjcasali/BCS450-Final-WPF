//******************************************************
// File: Course.cs
//
// Purpose: Object definition for Course Objects
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
    public class Course
    {
        #region Course Member Variables
        [DataMember(Name="id")]
        private int id;

        [DataMember(Name = "designator")]
        private string designator;

        [DataMember(Name = "number")]
        private string number;
        
        [DataMember(Name = "title")]
        private string title;
        
        [DataMember(Name = "description")]
        private string description;
        
        [DataMember(Name = "credits")]
        private int credits;
        #endregion

        #region Course Properties
        public int Id { get { return id; } set { id = value; } }
        public string Designator { get { return designator; } set { designator = value; } }
        public string Number { get { return number; } set { number = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int Credits{ get { return credits; } set { credits = value; } }
        #endregion

        #region Course Methods
        //****************************************************
        // Method: Course()
        //
        // Purpose: Default constructor for Course
        //****************************************************
        public Course()
        {
            id = 0;
            designator = "";
            number = "";
            title = ""; 
            description = "";
            credits = 0;
        }

        //****************************************************
        // Method: ToString()
        //
        // Purpose: Print the values in the Course Object
        //****************************************************
        public override string ToString()
        {
            return id + " " + designator + " " + number + " " + title + " " + description + " " + credits;
        }
        #endregion
    }   
}

