using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
/*
* Name: Felipe Rincon
* Course: COMP-1282 C# Programming 3
* Created: 2024-03-08
* Updated: 2024-03-20
*/

/// <summary>
/// Implement the operation contracts in ICollegeRegistration.cs 
/// </summary>
namespace BITCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICollegeRegistration" in both code and config file together.
    [ServiceContract]
    public interface ICollegeRegistration
    {
        //[OperationContract]
        //void DoWork();

        /// <summary>
        /// Implementation of the OperationContract DropCourse method
        /// </summary>
        /// <param name="registrationId">represents the registration record</param>
        /// <returns>The record wich corresponds to the method argument</returns>
        [OperationContract]
        bool DropCourse(int registrationId);
        /// <summary>
        /// RegisterCourse OperationContract method implementation
        /// </summary>
        /// <param name="studentId">represents the Student record</param>
        /// <param name="courseId">represents the Course record</param>
        /// <param name="notes">represents the registration record</param>
        /// <returns>The new Register course</returns>
        [OperationContract]
        int RegisterCourse(int studentId, int courseId, string notes);
        /// <summary>
        /// UpdateGrade OperationContract method implementation
        /// </summary>
        /// <param name="grade">represents the Grade record</param>
        /// <param name="registrationId">represents the registration record</param>
        /// <param name="notes">represents the notes record</param>
        /// <returns>the result of the CalculateGradePointAverage method</returns>
        [OperationContract]
        double? UpdateGrade(double grade, int registrationId, string notes);
    }
}
