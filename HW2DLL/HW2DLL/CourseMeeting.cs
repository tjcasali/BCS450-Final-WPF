//******************************************************
// File: CourseMeeting.cs
//
// Purpose: Object definition for Course Meeting Objects
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
    public class CourseMeeting
    {
        #region Course Meeting Member Variables
        [DataMember(Name = "roomId")]
        private int roomId;

        [DataMember(Name = "courseId")]
        private int courseId;

        [DataMember(Name = "professorId")]
        private int professorId;

        [DataMember(Name = "dayTime")]
        private string dayTime;
        #endregion

        #region Course Meeting Properties
        public int RoomId { get { return roomId; } set { roomId = value; } }
        public int CourseId { get { return courseId; } set { courseId = value; } }
        public int ProfessorId { get { return professorId; } set { professorId = value; } }
        public string DayTime { get { return dayTime; } set { dayTime = value; } }
        #endregion

        #region Course Meeting Methods
        //****************************************************
        // Method: CourseMeeting()
        //
        // Purpose: Default constructor for CourseMeeting
        //****************************************************
        public CourseMeeting()
        {
            roomId = 0;
            courseId = 0;
            professorId = 0;
            dayTime = "";
        }

        //****************************************************
        // Method: ToString()
        //
        // Purpose: Print the values in the Course Meeting Object
        //****************************************************
        public override string ToString()
        {
            return roomId + " " + courseId + " " + professorId + " " + dayTime;
        }
        #endregion
    }
}
