//******************************************************
// File: Room.cs
//
// Purpose: Object definition for Room Objects
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
    public class Room
    {
        #region Room Member Variables
        [DataMember(Name = "id")]
        private int id;

        [DataMember(Name = "location")]
        private string location;

        [DataMember(Name = "capacity")]
        private int capacity;
        #endregion

        #region Room Properties
        public int Id { get { return id; } set { id = value; } }
        public string Location { get { return location; } set { location = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        #endregion

        #region Room Methods
        //****************************************************
        // Method: Room()
        //
        // Purpose: Default constructor for Room
        //****************************************************
        public Room()
        {
            id = 0;
            location = "";
            capacity = 0;
        }

        //****************************************************
        // Method: ToString()
        //
        // Purpose: Print the values in the Room Object
        //****************************************************
        public override string ToString()
        {
            return id + " " + location + " " + capacity;
        }
        #endregion
    }

}
