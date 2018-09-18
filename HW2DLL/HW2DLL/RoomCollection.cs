//******************************************************
// File: RoomCollection.cs
//
// Purpose: Holds a list of all of the Room Objects
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
    public class RoomCollection
    {
        #region Room Collection Member Variables
        [DataMember(Name = "rooms")]
        public List<Room> rooms = new List<Room>();
        #endregion

        #region Room Collection Properties
        public List<Room> Rooms { get { return Rooms; } set { Rooms = value; } }
        #endregion

        #region Room Collection Methods
        //****************************************************
        // Method: RoomCollection()
        //
        // Purpose: Default constructor for RoomCollection
        //****************************************************
        public RoomCollection()
        {
            rooms = new List<Room>();
        }

        //****************************************************
        // Method: Room Find(int roomId)
        //
        // Purpose: Find the Room with the given RoomId
        //****************************************************
        public Room Find(int roomID)
        {
            Room rFind = new Room();
            foreach (Room r in Rooms)
            {
                if (r.Id == roomID)
                {
                    rFind = r;
                }
            }
            return rFind;
        }

        //****************************************************
        // Method: Room Find(string Location)
        //
        // Purpose: Find the Room with the given Location
        //****************************************************
        public Room Find(string Location)
        {
            Room rFind = new Room();
            foreach (Room r in Rooms)
            {
                if (r.Location == Location)
                {
                    rFind = r;
                }
            }
            return rFind;
        }

        //****************************************************
        // Method: ToString()
        //
        // Purpose: Print the values in the Room Objects
        //****************************************************
        public override string ToString()
        {
            return rooms.ToString();
        }
        #endregion
    }
}
