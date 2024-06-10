using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/*
* Name: Felipe Rincon
* Course: COMP-1281 C# Programming 3
* Created: 2024-01-13
* Updated: 2024-02-23
*/

/// <summary>
/// Controllers created, using scaffolding method, without views for abstract classes,
/// and migration coding checked, also following the MVC design patterns.
/// </summary>

namespace BITCollege_Felipe_Rincon.Data
{
    public class BITCollege_Felipe_RinconContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BITCollege_Felipe_RinconContext() : base("name=BITCollege_Felipe_RinconContext")
        {
        }
        /// <summary>
        /// Sub classes controllers created for each sub class model of Course and GradePointState,
        /// with queries adjusted.
        /// </summary>
        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.AcademicProgram> AcademicPrograms { get; set; }

        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.GradePointState> GradePointStates { get; set; }

        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.Registration> Registrations { get; set; }

        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.Course> Courses { get; set; }

        /// As next step, after of created the first controller, I proceed to modify 
        /// the Web.Config based on the instructions from design patterns on course notes.

        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.AuditCourse> AuditCourses { get; set; }
        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.MasteryCourse> MasteryCourses { get; set; }
        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.GradedCourse> GradedCourses { get; set; }
        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.SuspendedState> SuspendedStates  { get; set; }
        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.RegularState> RegularStates { get; set; }
        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.HonourState> HonourStates { get; set; }
        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.ProbationState> ProbationStates { get; set; }

        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.StudentCard> StudentCards { get; set; }

        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.NextUniqueNumber> NextUniqueNumbers { get; set; }

        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.NextGradedCourse> NextGradedCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.NextAuditCourse> NextAuditCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.NextMasteryCourse> NextMasteryCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.NextRegistration> NextRegistrations { get; set; }

        public System.Data.Entity.DbSet<BITCollege_Felipe_Rincon.Models.NextStudent> NextStudents { get; set; }

  
    }
}
