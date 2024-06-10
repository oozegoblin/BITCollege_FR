using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utility;
using BITCollege_Felipe_Rincon.Data;
/// SlqClient call it, to execute SQL server StoredProcedure
using System.Data.SqlClient;
using System.Data;

/*
* Name: Felipe Rincon
* Course: COMP-1281 C# Programming 2
* Created: 2023-06-12
* Updated: 2024-03-20
*/
namespace BITCollege_Felipe_Rincon.Models
{
    /// <summary>
    /// Define the Student Model based on the Class Diagram.
    /// To represents Student in the database.
    /// </summary>
    public class Student
    {
        // Annotation to have PKey value, also works [Key], but I follow the programming rules.
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        // GradePointStateId as a FKey alson with 1 annotation.
        /// [ForeignKey("Grade Point State")]
        [ForeignKey("GradePointState")]
        public int? GradePointStateId { get; set; }
        [ForeignKey("AcademicProgram")]
        ///[ForeignKey("Academic\nProgram")]
        public int? AcademicProgramId { get; set; }
        /// Remove data annotations from StudentNumber field.
        // StudentNumber has 3 annotations.
        //[Required]
        [Display(Name = "Student\nNumber")]
        //[Range(10000000, 99999999)]
        public int StudentNumber { get; set; }
        [Required]
        [Display(Name = "First\nName")]
        [StringLength(35, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last\nName")]
        [StringLength(35, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string Address { get; set; }
        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string City { get; set; }
        // Limit the user, only to a Canadian Provinces.
        [Required]
        [RegularExpression("^(AB|BC|MB|NB|NL|NS|NU|ON|PE|QC|SK|YT)$", ErrorMessage = "Invalid Canadian province code.")]
        public string Province { get; set; }
        // It requiresa valid Canadian Postal code value.
        [Required]
        /// [RegularExpression("^[ABCEGHJKLMNPRSTVXY]\\d[0-9]\\d[ABCEGHJKLMNPRSTVWXYZ]\\d[\n]\\d[0-9]\\d[ABCEGHJKLMNPRSTVWXYZ]\\d[0-9]\\d$",
        [RegularExpression("^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][ ][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$",
            ErrorMessage = "Invalid Postal Code.")]
        public string PostalCode { get; set; }
        [Required]
        [Display(Name = "Date\nCreated")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Grade Point\nAverage")]
        [Range(0, 4.5)]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        /// [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double? GradePointAverage { get; set; }
        [Required]
        [Display(Name = "Outstanding\nFees")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        /// [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double OutstandingFees { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
        [Display(Name = "Address")]
        public string FullAddress
        {
            get
            {
                return string.Format("{0} {1} {2} {3}", Address, City, Province, PostalCode);
            }
        }
        /// <summary>
        /// Navigation properties from the diagram.
        /// </summary>
        public virtual AcademicProgram AcademicProgram { get; set; }
        public virtual GradePointState GradePointState { get; set; }
        // as defined on the diagram, represent a many relationship.
        public ICollection<Registration> Registration { get; set; }
        /// Define an instance of the Data Context class for use the ChangeState method.
        private readonly BITCollege_Felipe_RinconContext dbContext;
        public Student()
        {
            dbContext = new BITCollege_Felipe_RinconContext();
        }
        /// <summary>
        /// Implementation for the +ChangeState(): void method.
        /// State Pattern implementation, when updating and viewing Student records.
        /// </summary>
        public void ChangeState()
        {

            /// Using the Data Context instance to obtain a GradePointState object 
            /// based on that Student’s GradePointStateId
            GradePointState state = dbContext.GradePointStates.Find(GradePointStateId);
            /// Call the method passing the current student record
            state.TuitionRateAdjustment(this);
            state.StateChangeCheck(this);
        }
        // As defined on the diagram, represent a many relationship between Student and StudentCard
        public ICollection<StudentCard> StudentCard { get; set; }
        /// Implementation for the SetNextStudentMethod method.
        public void SetNextStudentNumber()
        {
            /// Try to retrieve the nextNumber from StoredProcedure.
            long? nextNumber = StoredProcedure.NextNumber("NextStudent");
            /// If it's available, set the StudentNumber
            if (nextNumber.HasValue)
            {
                /// Give the value with the current discriminator
                NextStudent.GetInstance().NextAvailableNumber = nextNumber.Value;
            }
            /// Instead call GetInstance Method and handle any possible null value
            NextStudent next = NextStudent.GetInstance();
            StudentNumber = (int)next.NextAvailableNumber;
        }
    }
    /// <summary>
    /// Define the AcademicProgram Model based on the Class Diagram.
    /// To represents AcademicProgram in the database.
    /// </summary>
    public class AcademicProgram
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AcademicProgramId { get; set; }
        [Required]
        [Display(Name = "Program")]
        public string ProgramAcronym { get; set; }
        [Required]
        [Display(Name = "Program\nName")]
        public string Description { get; set; }
        /// <summary>
        /// Navigation properties from the diagram.
        /// </summary>
        public ICollection<Student> Student { get; set; }
        /// public Course Course { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
    /// <summary>
    /// Define the GradePointState Model based on the Class Diagram.
    /// To represents GradePointState in the database.
    /// </summary>
    public class GradePointState
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GradePointStateId { get; set; }
        [Required]
        [Display(Name = "Lower\nLimit")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double LowerLimit { get; set; }
        [Required]
        [Display(Name = "Upper\nLimit")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double UpperLimit { get; set; }
        [Required]
        [Display(Name = "Tuition\nRate\nFactor")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double TuitionRateFactor { get; set; }
        /// <summary>
        /// Method implemented in the static class BusinessRules.
        /// </summary>
        [Display(Name = "Grade Point\nState")]
        public string Description => BusinessRules.GetDescription(GetType().Name);
        /// <summary>
        /// Navigation properties from the diagram.
        /// </summary>
        public ICollection<Student> Student { get; set; }
        /// <summary>
        ///  In the GradePointState super class, define a protected static variable, 
        ///  so that the following can be achieved in each of the derived classes. 
        /// </summary>
        protected static BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();
        /// <summary>
        /// Implementation for the singleton and State pattern
        /// Including the +<<virtual>> TuitionRateAdjustment(student: Student) : double
        /// +<<virtual>> StateChangeCheck(student: Student) : void properties
        /// </summary>

        /// TuitionRateAdjustment method implementation
        public virtual double TuitionRateAdjustment(Student student)
        {
            /// calling the method on the sub classes, them should override.
            return 0.0;
        }
        /// <summary>
        /// State pattern implementation on the StateChangeCheck method, A change from one state to another
        /// based on the GradePointAverage as per bussiness rules from the assignment.
        /// </summary>
        public virtual void StateChangeCheck(Student student)
        {
            /// calling the method on the sub classes, Starting the verification of the state.
            SuspendedState.GetInstance().StateChangeCheck(student);
        }
    }
    /// Implementation for the singleton and State pattern for the sub classes
    /// Including the +<<override>> TuitionRateAdjustment(student: Student) : double
    /// +<<override>> StateChangeCheck(student: Student) : void properties

    /// <summary>
    /// Define the RegularState Model based on the Class Diagram
    /// Plus the Implementation for the singleton and State pattern.
    /// </summary>
    public class RegularState : GradePointState
    {
        /// <summary>
        /// Singleton Implementation, with a static variable to instance the class. 
        /// </summary>
        private static RegularState instance;
        /// <summary>
        /// Private Constructor, set the inherited auto-implemented properties, 
        /// and avoid other kind of instantiation.
        /// </summary>
        private RegularState()
        {
            LowerLimit = 2;
            UpperLimit = 3.70;
            TuitionRateFactor = 1;
        }
        /// <summary>
        /// GetInstance method implementation, will return the one and only 
        /// object of the GradePointState sub class 
        /// </summary>
        public static RegularState GetInstance()
        {
            /// Checking the instance if it's exist using the .SingleOrDefault() method 
            if (instance == null)
            {
                RegularState regular = db.RegularStates.SingleOrDefault();
                if (regular != null)
                {
                    instance = regular;
                }
                else
                {
                    /// Perfom the instantiation if it proceed, and populate the static variable 
                    /// with that record, to persist to the dataBase.
                    instance = new RegularState();
                    db.RegularStates.Add(instance);
                    db.SaveChanges();
                }
            }
            return instance;
        }
        /// <summary>
        /// TuitionRateFactor implementation, there will be no adjustments 
        /// made to the cost of tuition for all RegularState students.  
        /// </summary>
        public override double TuitionRateAdjustment(Student student)
        {
            return TuitionRateFactor;
        }
        /// <summary>
        /// StateChangeCheck from one state to another, method implemented for each sub class 
        /// </summary>
        public override void StateChangeCheck(Student student)
        {
            /// if the GPA > 3.70 it will go to HonourState.
            if (student.GradePointAverage > UpperLimit)
            {
                /// Move the student to HonourState.
                HonourState.GetInstance().StateChangeCheck(student);
                db.SaveChanges();
            }
            /// if the GPA < 2.00, it's gonna move to ProbationState.
            else if (student.GradePointAverage < LowerLimit)
            {
                /// Move the student to ProbationState.
                ProbationState.GetInstance().StateChangeCheck(student);
                db.SaveChanges();
            }
            else
            {
                /// Otherwise, student set to remain at Regular
                var state = db.Students.SingleOrDefault(m => m.StudentId == student.StudentId);
                state.GradePointState = instance;
                state.GradePointAverage = student.GradePointAverage;
                db.SaveChanges();
            }
        }
    }
    /// <summary>
    /// Define the HonoursState Model based on the Class Diagram.
    /// Plus the Implementation for the singleton and State pattern.
    /// </summary>
    public class HonourState : GradePointState
    {
        /// <summary>
        /// Singleton Implementation, with a static variable to instance the class. 
        /// </summary>
        private static HonourState instance;
        /// <summary>
        /// Private Constructor, set the inherited auto-implemented properties, 
        /// and avoid other kind of instantiation.
        /// </summary>
        private HonourState()
        {
            LowerLimit = 3.7;
            UpperLimit = 4.5;
            TuitionRateFactor = .9;
        }
        /// <summary>
        /// GetInstance method implementation, will return the one and only object of the GradePointState sub class.
        /// </summary>
        public static HonourState GetInstance()
        {
            if (instance == null)
            {
                /// Checking the instance if it's exist using the .SingleOrDefault() method 
                HonourState honour = db.HonourStates.SingleOrDefault();
                if (honour != null)
                {
                    instance = honour;
                }
                else
                {
                    /// Perfom the instantiation if it proceed, and populate the static variable 
                    /// with that record, to persist to the dataBase.
                    instance = new HonourState();
                    db.HonourStates.Add(instance);
                    db.SaveChanges();
                }
            }
            return instance;
        }
        /// <summary>
        /// TuitionRateAdjustment method implementation for HonourState
        /// </summary>
        /// <param name="student"></param>
        /// <returns>TuitionRateFactor</returns>
        public override double TuitionRateAdjustment(Student student)
        {
            /// All Honours students will pay 10 % less for each newly registered course.
            if (student.GradePointState is HonourState)
            {
                TuitionRateFactor -= 0.10;
                /// the Student has achieved an Honours GradePointState after having completed 5 or more courses
                if (student.Registration != null && student.Registration.Count(r => r.Grade != null) >= 5)
                {
                    /// tuition for each newly registered course is discounted by 15%.    
                    TuitionRateFactor -= 0.15;
                }
                /// If the Student’s GradePointAverage is above 4.25, 
                if (student.GradePointAverage > 4.25)
                {
                    /// the student will receive an additional 2 % discount.
                    TuitionRateFactor -= 0.02;
                }
            }
            return TuitionRateFactor;
        }
        /// <summary>
        /// StateChangeCheck from one state to another, method implemented for each sub class   
        /// </summary>
        public override void StateChangeCheck(Student student)
        {
            /// if the GPA < 3.70, it's gonna move to RegularState
            if (student.GradePointAverage < LowerLimit)
            {
                /// Move the student to RegularState
                RegularState.GetInstance().StateChangeCheck(student);
                db.SaveChanges();
            }
            /// GPA cannot move above an Honours State
            else
            {
                /// Set the student's remained at Honour
                var state = db.Students.SingleOrDefault(m => m.StudentId == student.StudentId);
                state.GradePointState = instance;
                state.GradePointAverage = student.GradePointAverage;
                db.SaveChanges();
            }
        }
    }
    /// <summary>
    /// Define the ProbationState Model based on the Class Diagram.
    /// Plus the Implementation for the singleton and State pattern.
    /// </summary>
    public class ProbationState : GradePointState
    {
        /// <summary>
        /// Singleton Implementation, with a static variable to instance the class. 
        /// </summary>
        private static ProbationState instance;
        /// <summary>
        /// Private Constructor, set the inherited auto-implemented properties, 
        /// and avoid other kind of instantiation.
        /// </summary>
        private ProbationState()
        {
            LowerLimit = 1.00;
            UpperLimit = 2.00;
            TuitionRateFactor = 1.075;
        }
        /// <summary>
        /// GetInstance method implementation, will return the one and only object of the GradePointState sub class.
        /// </summary>
        public static ProbationState GetInstance()
        {
            if (instance == null)
            {
                /// Checking the instance if it's exist using the .SingleOrDefault() method 
                ProbationState probation = db.ProbationStates.SingleOrDefault();
                if (probation != null)
                {
                    instance = probation;
                }
                else
                {
                    /// Perfom the instantiation if it proceed, and populate the static variable 
                    /// with that record, to persist to the dataBase.
                    instance = new ProbationState();
                    db.ProbationStates.Add(instance);
                    db.SaveChanges();
                }
            }
            return instance;
        }
        /// <summary>
        /// TuitionRateAdjustment method implementation for ProbationState
        /// </summary>
        public override double TuitionRateAdjustment(Student student)
        {
            /// all ProbationState students 
            if (student.GradePointState is ProbationState)
            {
                /// //will pay an additional 7.5% for each newly registered course.
                TuitionRateFactor += 0.075;
                ///	If the Student has completed 5 or more courses
                if (student.Registration != null && student.Registration.Count(r => r.Grade != null) >= 5)
                {
                    /// tuition for each newly registered course is increased by only 3.5%.   
                    TuitionRateFactor += 0.035;
                }
            }
            return TuitionRateFactor;
        }
        /// <summary>
        /// StateChangeCheck from one state to another, method implemented for each sub class 
        /// </summary>
        public override void StateChangeCheck(Student student)
        {
            /// if the GPA > 2.00, it's gonna move to RegularState
            if (student.GradePointAverage > UpperLimit)
            {
                /// Move the student to RegularState
                RegularState.GetInstance().StateChangeCheck(student);
                db.SaveChanges();
            }
            /// if the GPA < 1.00, it's going to move to Suspended State.
            else if (student.GradePointAverage < LowerLimit)
            {
                /// Move the student to SupendedState
                SuspendedState.GetInstance().StateChangeCheck(student);
                db.SaveChanges();
            }
            else
            {
                /// Otherwise, student set to remain at Probation
                var state = db.Students.SingleOrDefault(m => m.StudentId == student.StudentId);
                state.GradePointState = instance;
                state.GradePointAverage = student.GradePointAverage;
                db.SaveChanges();
            }
        }
    }
    /// <summary>
    /// Define the SuspendedState Model based on the Class Diagram.
    /// Plus the Implementation for the singleton and State pattern.
    /// </summary>
    public class SuspendedState : GradePointState
    {
        /// <summary>
        /// Singleton Implementation, with a static variable to instance the class. 
        /// </summary>
        private static SuspendedState instance;
        /// <summary>
        /// Private Constructor, set the inherited auto-implemented properties.
        /// </summary>
        private SuspendedState()
        {
            LowerLimit = 0.00;
            UpperLimit = 1.00;
            TuitionRateFactor = 1.1;
        }
        /// <summary>
        /// GetInstance method implementation, will return the one and only object of the GradePointState sub class.
        /// </summary>
        public static SuspendedState GetInstance()
        {
            /// Checking the instance if it's exist using the .SingleOrDefault() method 
            if (instance == null)
            {
                SuspendedState suspended = db.SuspendedStates.SingleOrDefault();
                if (suspended != null)
                {
                    instance = suspended;
                }
                else
                {
                    /// Perfom the instantiation if it proceed, and populate the static variable 
                    /// with that record, to persist to the dataBase.
                    instance = new SuspendedState();
                    db.SuspendedStates.Add(instance);
                    db.SaveChanges();
                }
            }
            return instance;
        }
        /// <summary>
        /// TuitionRateAdjustment method implementation for SuspendedSTate
        /// </summary>
        public override double TuitionRateAdjustment(Student student)
        {
            /// the TuitionRateFactor for each newly registered course has already been defined as 1.1.    
            if (student.GradePointState is SuspendedState)
            {
                /// all SuspendedState students will pay an additional 10% for each newly registered course. 
                TuitionRateFactor += 0.1;
                /// if student has dropped below 0.75, 
                if (student.GradePointAverage < 0.75)
                {
                    /// tuition for each newly registered course is increased by 2% above 
                    TuitionRateFactor += 0.02;
                }
                /// If the Student’s GradePointAverage has dropped below 0.50, tuition for each             
                if (student.GradePointAverage < 0.50)
                {
                    /// newly registered course is increased by 5% above the SuspendedState’s default premium
                    TuitionRateFactor += 0.05;
                }
            }
            return TuitionRateFactor;

        }
        /// <summary>
        /// StateChangeCheck from one state to another, method implemented for each sub class 
        /// </summary>
        public override void StateChangeCheck(Student student)
        {
            /// check if the GPA > 1.00, it's gonna move to ProbationState
            if (student.GradePointAverage >= UpperLimit)
            {
                // Move the student to ProbationState
                ProbationState.GetInstance().StateChangeCheck(student);
                db.SaveChanges();
            }
            /// the GPA cannot drop below a Suspended State.
            else
            {
                /// Set the student's remained at Honour
                var state = db.Students.SingleOrDefault(m => m.StudentId == student.StudentId);
                state.GradePointState = instance;
                state.GradePointAverage = student.GradePointAverage;
                db.SaveChanges();
            }
        }
    }
    /// <summary>
    /// Define the Course Model based on the Class Diagram.
    /// To represents Course in the database.
    /// </summary>
    public class Course
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        ///[ForeignKey("Academic\nProgram")]
        [ForeignKey("AcademicProgram")]
        public int? AcademicProgramId { get; set; }
        /// Remove data annotations from CourseNumber  field.
        //[Required]
        [Display(Name = "Course\nNumber")]
        public string CourseNumber { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Credit\nHours")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        /// [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double CreditHours { get; set; }
        [Required]
        [Display(Name = "Tuition\nAmount")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        /// [DisplayFormat(DataFormatString = "{0:C}")]
        public double TuitionAmount { get; set; }
        /// <summary>
        /// Method implemented in the static class BusinessRules.
        /// </summary>
        [Display(Name = "Course\nType")]
        //public string CourseType => BusinessRules.GetCourseType(CourseType);
        //public string CourseType => BusinessRules.GetCourseType();
        //public string CourseType
        //{
        //    get
        //    {
        //        return Utility.BusinessRules.GetCourseType();
        //    }
        //}
        public string CourseType
        {
            get { return Utility.BusinessRules.RemoveCourse(GetType().Name, "Course"); }
        }
        public string Notes { get; set; }
        /// <summary>
        /// Navigation properties from the diagram.
        /// </summary>
        public virtual AcademicProgram AcademicProgram { get; set; }
        /// public virtual ICollection<AcademicProgram> AcademicPrograms { get; set; }
        public ICollection<Registration> Registration { get; set; }
        /// Implementation for the SetNextCourseNumber method.
        public virtual void SetNextCourseNumber()
        {
            /// Calling itself from the subclasses methods.
        }
    }
    /// <summary>
    /// Define the GradedCourse Model based on the Class Diagram.
    /// To represents GradedCourse in the database.
    /// </summary>
    public class GradedCourse : Course
    {
        [Required]
        [Display(Name = "Assignment\nWeight")]
        [DisplayFormat(DataFormatString = "{0:0.00}%", ApplyFormatInEditMode = true)]
        /// [DisplayFormat(DataFormatString = "{0:0.00}%")]
        public double AssignmentWeight { get; set; }
        [Required]
        [Display(Name = "Midterm\nWeight")]
        [DisplayFormat(DataFormatString = "{0:0.00}%", ApplyFormatInEditMode = true)]
        /// [DisplayFormat(DataFormatString = "{0:0.00}%")]
        public double MidtermWeight { get; set; }
        [Required]
        [Display(Name = "Final\nWeight")]
        [DisplayFormat(DataFormatString = "{0:0.00}%", ApplyFormatInEditMode = true)]
        /// [DisplayFormat(DataFormatString = "{0:0.00}%" )]
        public double FinalWeight { get; set; }
        public override void SetNextCourseNumber()
        {
            /// Try to retrieve the nextNumber from StoredProcedure.
            long? nextNumber = StoredProcedure.NextNumber("NextGradedCourse");
            /// If it's available, set the CourseNumber
            if (nextNumber.HasValue)
            {
                /// Give the value with the current discriminator
                NextGradedCourse.GetInstance().NextAvailableNumber = nextNumber.Value;
                CourseNumber = "G-" + nextNumber.Value;
            }
            /// Instead call GetInstance Method and handle any possible null value
            NextGradedCourse next = NextGradedCourse.GetInstance();
            CourseNumber = "G-" + next.NextAvailableNumber.ToString();

        }
    }
    /// <summary>
    /// Define the AuditCourse Model based on the Class Diagram.
    /// </summary>
    public class AuditCourse : Course
    {
        public override void SetNextCourseNumber()
        {
            /// Try to retrieve the nextNumber from StoredProcedure.
            long? nextNumber = StoredProcedure.NextNumber("NextAuditCourse");
            /// If it's available, set the CourseNumber
            if (nextNumber.HasValue)
            {
                /// Give the value with the current discriminator
                NextAuditCourse.GetInstance().NextAvailableNumber = nextNumber.Value;
                CourseNumber = "A-" + nextNumber.Value;
            }
            /// Instead call GetInstance Method and handle any possible null value
            NextAuditCourse next = NextAuditCourse.GetInstance();
            CourseNumber = "A-" + next.NextAvailableNumber.ToString();
        }
    }
    /// <summary>
    /// Define the MasteryCourse Model based on the Class Diagram.
    /// </summary>
    public class MasteryCourse : Course
    {
        [Required]
        [Display(Name = "Maximum\nAttempts")]
        public int MaximumAttempts { get; set; }
        public override void SetNextCourseNumber()
        {
            /// Try to retrieve the next nextNumber from StoredProcedure.
            long? nextNumber = StoredProcedure.NextNumber("NextMasteryCourse");
            /// If it's available, set the CourseNumber
            if (nextNumber.HasValue)
            {
                /// Give the value with the current discriminator
                NextMasteryCourse.GetInstance().NextAvailableNumber = nextNumber.Value;
                CourseNumber = "M-" + nextNumber.Value;
            }
            /// Instead call GetInstance Method and handle any possible null value 
            NextMasteryCourse next = NextMasteryCourse.GetInstance();
            CourseNumber = "M-" + next.NextAvailableNumber.ToString();              
        }
    }
    /// <summary>
    /// Define the Registration Model based on the Class Diagram.
    /// To represents Registration in the database.
    /// </summary>
    public class Registration
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RegistrationId { get; set; }
        [Required]
        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        [Required]
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        /// Remove data annotations from RegistrationNumber field.
        //[Required]
        [Display(Name = "Registration\nNumber")]
        public long RegistrationNumber { get; set; }
        [Required]
        [Display(Name = "Registration\nDate")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RegistrationDate { get; set; }
        [DisplayFormat(NullDisplayText = "Ungraded")]
        [Range(0, 1)]
        public double? Grade { get; set; }
        public string Notes { get; set; }
        /// <summary>
        /// Navigation properties from the diagram.
        /// </summary>
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        /// Implementation for the SetNextRegistrationNumber method.
        public void SetNextRegistrationNumber()
        {
            /// Try to retrieve the nextRegistrationNumber from StoredProcedure.
            long? nextNumber = StoredProcedure.NextNumber("NextRegistration");
            /// If it's available, set the RegistrationNumber
            if (nextNumber.HasValue)
            {
                /// Give the value with the current discriminator
                NextRegistration.GetInstance().NextAvailableNumber = nextNumber.Value;
            }
            /// Instead call GetInstance Method and handle any possible null value
            NextRegistration next = NextRegistration.GetInstance();
            RegistrationNumber = next.NextAvailableNumber;
        }

    }
    /// <summary>
    /// Define the StudentCard Model based on the Class Diagram.
    /// To represents StudentCard in the database.
    /// </summary>
    public class StudentCard
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentCardId { get; set; }
        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [Required]
        public long CardNumber { get; set; }
        // As defined on the diagram, represent a 1 or 0 relation between StudentCard and Student.
        public virtual Student Student { get; set; }
    }
    /// <summary>
    /// Define the NextUniqueNumber Model based on the Class Diagram.
    /// To represents NextUniqueNumber and the sub classes in the database.
    /// </summary>
    public class NextUniqueNumber
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int NextUniqueNumberId { get; set; }
        [Required]
        public long NextAvailableNumber { get; set; }
        ///  define a protected static variable of your data context object (BITCollege_FLContext)
        protected static BITCollege_Felipe_RinconContext uniqueNumber = new BITCollege_Felipe_RinconContext();
    }
    /// Define the NextGradedCourse Model based on the Class Diagram.
    /// Plus the Implementation for the singleton pattern.
    public class NextGradedCourse : NextUniqueNumber
    {
        /// Singleton Implementation, with a static variable to instance the class. 
        private static NextGradedCourse instance;
        /// Private Constructor, set the inherited auto-implemented properties, and avoid other kind of instantiation.
        private NextGradedCourse()
        {
            NextAvailableNumber = 200000;
        }
        /// GetInstance method implementation, will return the one and only object NextAvailableNumber
        public static NextGradedCourse GetInstance()
        {
            if (instance == null)
            {
                /// Checking the instance if it's exist using the .FirstOrDefault() method
                /// otherwise it will be populate with two different values 
                NextGradedCourse nextGraded = uniqueNumber.NextGradedCourses.FirstOrDefault();
                if (nextGraded != null)
                {
                    instance = nextGraded;
                }
                else
                {
                    /// Perfom the instantiation if it proceed, and populate the static variable 
                    /// with that record, to persist to the dataBase.
                    instance = new NextGradedCourse();
                    uniqueNumber.NextGradedCourses.Add(instance);
                    uniqueNumber.SaveChanges();
                }
            }
            return instance;
        }
    }
    /// <summary>
    /// Define the NextStudent Model based on the Class Diagram.
    /// Plus the Implementation for the singleton pattern.
    /// </summary>
    public class NextStudent : NextUniqueNumber
    {
        /// Singleton Implementation, with a static variable to instance the class. 
        private static NextStudent instance;
        /// Private Constructor, set the inherited auto-implemented properties, and avoid other kind of instantiation.
        private NextStudent()
        {
            NextAvailableNumber = 20000000;
        }
        /// GetInstance method implementation, will return the one and only object NextAvailableNumber
        public static NextStudent GetInstance()
        {
            /// Checking the instance if it's exist using the .SingleOrDefault() method 
            if (instance == null)
            {
                NextStudent nextStudent = uniqueNumber.NextStudents.FirstOrDefault();
                if (nextStudent != null)
                {
                    instance = nextStudent;
                }
                else
                {
                    /// Perfom the instantiation if it proceed, and populate the static variable 
                    /// with that record, to persist to the dataBase.
                    instance = new NextStudent();
                    uniqueNumber.NextStudents.Add(instance);
                    uniqueNumber.SaveChanges();
                }
            }
            return instance;
        }
    }
    /// <summary>
    /// Define the NextAuditCourse Model based on the Class Diagram.
    /// Plus the Implementation for the singleton pattern.
    /// </summary>
    public class NextAuditCourse : NextUniqueNumber
    {
        /// Singleton Implementation, with a static variable to instance the class. 
        private static NextAuditCourse instance;
        /// Private Constructor, set the inherited auto-implemented properties, and avoid other kind of instantiation.
        private NextAuditCourse()
        {
            NextAvailableNumber = 2000;
        }
        /// GetInstance method implementation, will return the one and only object NextAvailableNumber
        public static NextAuditCourse GetInstance()
        {
            if (instance == null)
            {
                /// Checking the instance if it's exist using the .FirstOrDefault() method
                /// otherwise it will be populate with two different values 
                NextAuditCourse nextAudit = uniqueNumber.NextAuditCourses.FirstOrDefault();
                if (nextAudit != null)
                {
                    instance = nextAudit;
                }
                else
                {
                    /// Perfom the instantiation if it proceed, and populate the static variable 
                    /// with that record, to persist to the dataBase.
                    instance = new NextAuditCourse();
                    uniqueNumber.NextAuditCourses.Add(instance);
                    uniqueNumber.SaveChanges();
                }
            }
            return instance;
        }
    }
    /// <summary>
    /// Define the NextAuditCourse Model based on the Class Diagram.
    /// Plus the Implementation for the singleton pattern.
    /// </summary>
    public class NextRegistration : NextUniqueNumber
    {
        /// Singleton Implementation, with a static variable to instance the class. 
        private static NextRegistration instance;
        /// Private Constructor, set the inherited auto-implemented properties, and avoid other kind of instantiation.
        private NextRegistration()
        {
            NextAvailableNumber = 700;
        }
        /// GetInstance method implementation, will return the one and only object NextAvailableNumber
        public static NextRegistration GetInstance()
        {
            if (instance == null)
            {
                /// Checking the instance if it's exist using the .FirstOrDefault() method
                /// otherwise it will be populate with two different values 
                NextRegistration nextRegistration = uniqueNumber.NextRegistrations.FirstOrDefault();
                if (nextRegistration != null)
                {
                    instance = nextRegistration;
                }
                else
                {
                    /// Perfom the instantiation if it proceed, and populate the static variable 
                    /// with that record, to persist to the dataBase.
                    instance = new NextRegistration();
                    uniqueNumber.NextRegistrations.Add(instance);
                    uniqueNumber.SaveChanges();
                }
            }
            return instance;
        }
    }
    /// Define the NextMasteryCourse Model based on the Class Diagram.
    /// Plus the Implementation for the singleton pattern.
    public class NextMasteryCourse : NextUniqueNumber
    {
        /// Singleton Implementation, with a static variable to instance the class. 
        private static NextMasteryCourse instance;
        /// Private Constructor, set the inherited auto-implemented properties, and avoid other kind of instantiation.
        private NextMasteryCourse()
        {
            NextAvailableNumber = 20000;
        }
        /// GetInstance method implementation, will return the one and only object NextAvailableNumber
        public static NextMasteryCourse GetInstance()
        {
            if (instance == null)
            {
                /// Checking the instance if it's exist using the .FirstOrDefault() method
                /// otherwise it will be populate with two different values 
                NextMasteryCourse nextMastery = uniqueNumber.NextMasteryCourses.FirstOrDefault();
                if (nextMastery != null)
                {
                    instance = nextMastery;
                }
                else
                {
                    /// Perfom the instantiation if it proceed, and populate the static variable 
                    /// with that record, to persist to the dataBase.
                    instance = new NextMasteryCourse();
                    uniqueNumber.NextMasteryCourses.Add(instance);
                    uniqueNumber.SaveChanges();
                }
            }
            return instance;
        }
    }
    /// Define the StoredProcedure Model based on the Class Diagram.
    /// Plus the method to executing stored process.
    public class StoredProcedure
    {
        /// Retrieves the next number from the database on the discriminator
        public static long? NextNumber(string discriminator)
        {
            /// Get the connection to the database
            SqlConnection connection = new SqlConnection("Data Source=localhost; " +
                "Initial Catalog=BITCollege_Felipe_RinconContext; Integrated Security=True");
            long? returnValue = 0;
            {
                try
                {
                    /// Creating the SqlCommand for StoredProcedure
                    SqlCommand storedProcedure = new SqlCommand("next_number", connection);
                    storedProcedure.CommandType = CommandType.StoredProcedure;
                    storedProcedure.Parameters.AddWithValue("@Discriminator", discriminator);
                    /// Define the output expected from next_number
                    SqlParameter outputParameter = new SqlParameter("@NewVal", SqlDbType.BigInt)
                    {
                        Direction = ParameterDirection.Output
                    };
                    storedProcedure.Parameters.Add(outputParameter);
                    connection.Open();
                    /// With the connection open, execute StoredProcedure.
                    storedProcedure.ExecuteNonQuery();
                    connection.Close();
                    /// Retrieve the parameter value as next_number
                    returnValue = (long?)outputParameter.Value;
                }
                /// Handling the exception if it's occur, setting the
                catch (Exception ex)
                {
                    /// returned value should be null
                    /// Console.WriteLine("An exception happened: " + ex.Message);
                    returnValue = null;
                }
                return returnValue;
            }

        }

    }

}