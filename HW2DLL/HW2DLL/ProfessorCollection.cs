//******************************************************
// File: ProfessorCollection.cs
//
// Purpose: Holds a list of all of the Professor Objects
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
    public class ProfessorCollection
    {
        #region Professor Collection Member Variables
        [DataMember(Name = "professors")]
        public List<Professor> professors = new List<Professor>();
        #endregion

        #region Professor Collection Properties
        public List<Professor> Professors { get { return Professors; } set { Professors = value; } }
        #endregion

        #region Professor Collection Methods
        //****************************************************
        // Method: ProfessorCollection()
        //
        // Purpose: Default constructor for Professor Collection
        //****************************************************
        public ProfessorCollection()
        {
            professors = new List<Professor>();
        }

        //****************************************************
        // Method: Professor Find(int professorID)
        //
        // Purpose: Find the Professor with the given ID
        //****************************************************
        public Professor Find(int professorID)
        {
            Professor pFind = new Professor();
            foreach (Professor p in professors)
            {
                if (p.Id == professorID)
                {
                    pFind = p;
                }
            }
            return pFind;
        }

        //****************************************************
        // Method: Professor Find(string Name)
        //
        // Purpose: Find the Professor with the Name
        //****************************************************
        public Professor Find(string Name)
        {
            Professor pFind = new Professor();
            foreach (Professor p in professors)
            {
                if (p.Name == Name)
                {
                    pFind = p;
                }
            }
            return pFind;
        }

        //****************************************************
        // Method: ToString()
        //
        // Purpose: Print the values in the Professor Objects
        //****************************************************
        public override string ToString()
        {
            return professors.ToString();
        }
        #endregion

    }
}
