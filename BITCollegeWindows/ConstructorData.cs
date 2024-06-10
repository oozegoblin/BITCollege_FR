using BITCollege_Felipe_Rincon.Data;
using BITCollege_Felipe_Rincon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
* Name: Felipe Rincon
* Course: COMP-1283 C# Programming 4
* Created: 2024-05-05
* Updated: 2024-05-10
*/
namespace BITCollegeWindows
{
    /// <summary>
    /// given:TO BE MODIFIED
    /// this class is used to capture data to be passed
    /// among the windows forms
    /// 
    /// These Auto-Implemented properties will be used to pass Student-specific and 
    /// Registration-specific data among the forms in the BITCollegeWindows Project
    /// </summary>
    public class ConstructorData
    {
        // Within the ConstructorData class create two Auto-Implemented properties
        // based on the student and registration Models
        public Student Student { get; set; }
        public Registration Registration { get; set; }

    }
}
