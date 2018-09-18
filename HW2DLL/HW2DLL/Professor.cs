//******************************************************
// File: Professor.cs
//
// Purpose: Object definition for Professor Objects
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
    public class Professor
    {
        #region Professor Member Variables
        [DataMember(Name = "id")]
        private int id;

        [DataMember(Name = "name")]
        private string name;

        [DataMember(Name = "phone")]
        private string phone;
        #endregion

        #region Professor Properties
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        #endregion

        #region Prefessor Methods
        //****************************************************
        // Method: Professor()
        //
        // Purpose: Default constructor for Professor
        //****************************************************
        public Professor()
        {
            id = 0;
            name = "";
            phone = "";
        }

        //****************************************************
        // Method: ToString()
        //
        // Purpose: Print the values in the Professor Object
        //****************************************************
        public override string ToString()
        {
            return id + " " + name + " " + phone;
        }
        #endregion
    }

}
