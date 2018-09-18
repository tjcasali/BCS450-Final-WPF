//******************************************************
// File: CourseMeetingCollection.cs
//
// Purpose: Holds a list of all of the Course Meeting Objects
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
    public class CourseMeetingCollection
    {
        #region CourseMeetingCollection Member Variables
        [DataMember(Name = "courseMeetings")]
        public List<CourseMeeting> courseMeetings = new List<CourseMeeting>();
        #endregion
        
        #region CourseMeetingCollection Properties
        public List<CourseMeeting> CourseMeetings { get { return CourseMeetings; } set { CourseMeetings = value; } }
        #endregion

        #region CourseMeetingCollection Methods
        //****************************************************
        // Method: CourseMeetingCollection()
        //
        // Purpose: Default constructor for CourseMeetingCollection
        //****************************************************
        public CourseMeetingCollection()
        {
            courseMeetings = new List<CourseMeeting>();
        }

        public CourseMeeting FindByCourse(int courseID)
        {
            CourseMeeting cmFind = new CourseMeeting();
            foreach (CourseMeeting cm in courseMeetings)
            {
                if (cm.CourseId == courseID)
                {
                    cmFind = cm;
                }
            }
            return cmFind;
        }

        public CourseMeeting FindByProfessor(int professorID)
        {
            CourseMeeting cmFind = new CourseMeeting();
            foreach (CourseMeeting cm in courseMeetings)
            {
                if (cm.ProfessorId == professorID)
                {
                    cmFind = cm;
                }
            }
            return cmFind;
        }

        public CourseMeeting FindByRoom(int roomID)
        {
            CourseMeeting cmFind = new CourseMeeting();
            foreach (CourseMeeting cm in courseMeetings)
            {
                if (cm.RoomId == roomID)
                {
                    cmFind = cm;
                }
            }
            return cmFind;
        }

        //****************************************************
        // Method: ToString()
        //
        // Purpose: Print the values in the Course Meeting Objects
        //****************************************************
        public override string ToString()
        {
            return courseMeetings.ToString();
        }
        #endregion
    }
}
