using BITCollege_Felipe_Rincon.Data;
using BITCollege_Felipe_Rincon.Models;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;
/*
* Name: Felipe Rincon
* Course: COMP-1282 C# Programming 3
* Created: 2024-03-08
* Updated: 2024-05-10
*/

/// <summary>
/// Implement the operation contracts in CollegeRegistration.cs 
/// </summary>
namespace BITCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CollegeRegistration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CollegeRegistration.svc or CollegeRegistration.svc.cs at the Solution Explorer and start debugging.
    public class CollegeRegistration : ICollegeRegistration
    {
        //BITCollege_Felipe_Rincon.Models.Registration dbContext = new BITCollege_Felipe_Rincon.Models.Registration();
        /// <summary>
        /// Instantiate an object of the BITCollege_FLContext object 
        /// </summary>
        private readonly BITCollege_Felipe_RinconContext db;
        //BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();
        /// <summary>
        /// Define additional instance variable
        /// </summary>
        public CollegeRegistration()
        {
            db = new BITCollege_Felipe_RinconContext();
        }
        //public void DoWork()
        //{
        //}
        /// <summary>
        /// DropCourse method Implementation 
        /// </summary>
        /// <param name="registrationId">represents the registration record</param>
        /// <returns>The record wich corresponds to the method argument</returns>
        public bool DropCourse(int registrationId)
        {
            try
            {
                /// Using LINQ to retireve the Registration record from the database
                //Course course = db.Courses
                //.Where(r => r.CourseId == registrationId).FirstOrDefault();
                Registration registration = db.Registrations
                    .Where(r => r.RegistrationId == registrationId).FirstOrDefault();
                //if (course != null)
                if (registration != null)
                {
                    /// Remove de record from the database
                    db.Registrations.Remove(registration);
                    /// db.Courses.Remove(course);
                    /// Persist the updated grade to the database. 
                    db.SaveChanges();
                    return true;
                }
                /// Return false if the registration record doesn't exist
                return false;
            }
            /// Return false if an excepcion occurs
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Register Course Implementation
        /// </summary>
        /// <param name="studentId">represents the Student record</param>
        /// <param name="courseId">represents the Course record</param>
        /// <param name="notes">represents the registration record</param>
        /// <returns>The new Register for a course</returns>
        public int RegisterCourse(int studentId, int courseId, string notes)
        {
            try
            {
                /// retrieving all records from the Registrations table involving the Student and Course.
                IQueryable<Registration> pastRegistrations = db.Registrations
                    .Where(r => r.StudentId == studentId && r.CourseId == courseId);
                /// Define a query to retrieve the Course record represented by the corresponding method parameter value
                IQueryable<Course> courses = db.Courses
                    .Where(c => c.CourseId == courseId);
                /// Define a query to retrieve the Student record
                Student students = db.Students
                    .Where(s => s.StudentId == studentId).FirstOrDefault();
                /// if any excepcion occurs return -300
                if (courses == null)
                {
                    return -300;
                }
                /// When the student already has an incomplete registration for the same course
                /// determine if any of the Registration records involving the Student and Course represented 
                if (pastRegistrations.Any(r => r.Grade == null))
                {
                    /// the student is not permitted to register for 
                    /// this course because they already have an ungraded registration
                    return -100;

                }
                /// determine whether the course is a Mastery course 
                if (courses is MasteryCourse)
                {
                    MasteryCourse masteryCourse = (MasteryCourse)courses.Single();
                    /// Obtain the MaximumAttempts value.
                    int maxAttemps = masteryCourse.MaximumAttempts;
                    int registrationCount = pastRegistrations.Count();
                    
                    /// determine the number of registrations that have already taken place between the Student and Course
                    if (registrationCount >= maxAttemps)
                    {
                        /// When a student is registering for a Mastery course and this registration would exceed the maximum attempts
                        return -200;
                    }
                }
                /// Create a new registration
                var newRegistration = new Registration
                {
                    StudentId = studentId,
                    CourseId = courseId,
                    Notes = notes,
                    RegistrationDate = DateTime.Today,
                    //RegistrationNumber = NextRegistration.GetInstance().NextAvailableNumber
                };
                // Remanufacturing the code, to ensure a new registration number is produced.
                newRegistration.SetNextRegistrationNumber();
                /// Add New Registration to de database
                db.Registrations.Add(newRegistration);
                /// Persist this new record to the database
                db.SaveChanges();
                /// determine the TuitionAmount of the Course
                Course course = courses.Single();
                /// Update the Student record by adding the Adjusted TuitionAmount to the OutstandingFees property
                double adjustedTuitionAmount = students.GradePointState.TuitionRateAdjustment(students);
                students.OutstandingFees += adjustedTuitionAmount;
                /// Persist the fees update
                db.SaveChanges();
                /// If the registration is successful, return a value of 0
                return 0;
            }
            catch(Exception ex)
            {
                return -300;
            }           
        }
        /// <summary>
        /// UpdateGrade Implementation
        /// </summary>
        /// <param name="grade">represents the Grade record</param>
        /// <param name="registrationId">represents the registration record</param>
        /// <param name="notes">represents the notes record</param>
        /// <returns>the result of the CalculateGradePointAverage method updated</returns>
        public double? UpdateGrade(double grade, int registrationId, string notes)
        {
            /// Using LINQ to retireve the Registration record from the database
            Registration registration = db.Registrations
                .Where(r => r.RegistrationId == registrationId).FirstOrDefault();
            /// return null if registration is not found
            if (registration != null)
            {
                /// Modify the Notes property with the value of the method argument. 
                registration.Grade = grade;
                registration.Notes = notes;
                /// Persist the updated grade to the database. 
                db.SaveChanges();
                /// Call the CalculateGradePointAverage method and
                /// Capture the result into a local variable
                double calculateGradePointAverage = (double)CalculateGradePointAverage((int)registration.StudentId);
                /// Return the result of the CalculateGradePointAverage method
                return calculateGradePointAverage;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// CalculateGradePointAverage implementation
        /// </summary>
        /// <param name="studentId">represents the Student record</param>
        /// <returns>•	Return the calculated Grade Point Average. </returns>
        private double? CalculateGradePointAverage(int studentId)
        {
            /// Use LINQ to define a result set containing all Registration records with a Grade value.
            IQueryable<Registration> registrations = db.Registrations
            .Where(r => r.StudentId == studentId && r.Grade != null);
            /// This variable will store the accumulated grade point value for ALL registrations. 
            double totalGradePointValue = 0;
            /// This variable will store the accumulated credit hours value of ALL registrations
            double totalCreditHours = 0;
            /// Obtain the grade for registration
            foreach (Registration registration in registrations.ToList())
            {
                /// This will store the grade of an individual registration
                ///double grade = (double)registration.Grade;
                double grade = (double)registration.Grade;
                /// Determine the course type for the registration
                /// This variable will store the type of course that the individual registration 
                /// CourseType courseType = BusinessRules.CourseTypeLookup();
                CourseType courseType = CourseType.MASTERY;
                /// Exclude audit courses from GPA calculation
                if (courseType != CourseType.AUDIT)
                {
                    /// Use Utility to determine grade point value
                    /// This variable will store the grade point value for an individual registration. 
                    double gradePoint = BusinessRules.GradeLookup(grade, courseType);
                    /// Multiply each registratio GPV by the course credits
                    /// This variable will store the calculated grade point value 
                    /// for an individual registration based on the course credit hours. 
                    double gradePointValue = registration.Course.CreditHours;
                    /// Determine Total Grade Point Value by accumulating the above value for all registrations. 
                    totalCreditHours += gradePointValue;
                    /// Grade Point Average formula and Determine the Total Credit Hours 
                    totalGradePointValue += gradePoint * gradePointValue;
                }
            }
            /// This variable will store the calculated grade point average and will be returned from the method. 
            double? calculatedGradePointAverage = null;
            /// Set the Grade Point Average variable 
            if (totalCreditHours != 0)
                {
                    calculatedGradePointAverage = totalGradePointValue / totalCreditHours;
                }
            /// If the Total Credit Hours value is 0, Set the GradePoint Average to NULL 
            else
            {
                return null;
            }
            /// Define a LINQ query to obtain the Student record to which the newly calculated GPA applies.
            Student student = db.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student != null)
            {
                /// Set the GPA property of the student record to the newly calculated GPA.
                student.GradePointAverage = calculatedGradePointAverage;
                /// Ensure that any changes to the Student’s GPA cause the student to be placed in the appropriate GradePointState. 
                student.ChangeState();
                /// Persist the change
                db.SaveChanges();
                /// student.ChangeState();
            }
            /// Return the calculated Grade Point Average. 
            return calculatedGradePointAverage;

        }
    }
}
