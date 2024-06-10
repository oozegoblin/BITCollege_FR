using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using BITCollege_Felipe_Rincon.Data;
using System.Globalization;
using BITCollege_Felipe_Rincon.Models;
using Utility;
/*
* Name: Felipe Rincon
* Course: COMP-1283 C# Programming 4
* Created: 2024-05-22
* Updated: 2024-06-06
*/
namespace BITCollegeWindows
{
    /// <summary>
    /// BatchProcess implementation, following the assignment diagram specifications.
    /// </summary>
    class BatchProcess
    {
        // Define an instance of your BITCollege_FLContext class for use in this form.
        BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();
        // property will represent the name of the file being processed. 
        private string inputFileName;
        // will represent the name of the log file that corresponds with the file being processed. 
        private string logFileName;
        // will represent all data to be written to the log file that corresponds with the file being processed. 
        private string logData;
        /// <summary>
        /// This method will initiate the batch process by determining the appropriate 
        /// filename and then proceeding with the header and detail processing
        /// </summary>
        /// <param name="programAcronym"></param>
        /// <param name="key"></param>
        public void ProcessTransmission(string programAcronym) //string key) - It will be used in a later assignment. That argument can be ignored for now.
        {
            // Formulate the inputFileName that is to be processed based on the filename format. 
            inputFileName = string.Format("{0}-{1:D3}-{2}.xml", DateTime.Now.Year, DateTime.Now.DayOfYear, programAcronym);
            // Formulate logFileName that is to represent the name of the log file.
            logFileName = string.Format("LOG {0}-{1:D3}-{2}.txt", DateTime.Now.Year, DateTime.Now.DayOfYear, programAcronym);
            // the File class to determine whether a file exists matching the inputFileName 
            // If the file does not exist: 
            if (!File.Exists(inputFileName))
            {
                logData += "\nThe file " + inputFileName + " does not exist.\n";
                return;
            }
            // If the file does exist: 
            try
            {
                // Call the ProcessHeader method 
                ProcessHeader();
                // Call the ProcessDetails method 
                ProcessDetails();
            }
            // If an exception occurs, append a relevant message to logData indicating the reason for the exception
            catch (Exception e)
            {
                logData += "An exception occurs for: " + inputFileName + e.Message;
            }
        }
        /// <summary>
        /// This method is used to verify the attributes of the xml file’s root element.  
        /// If any of the attributes produce an error, the file is NOT to be processed.   
        /// </summary>
        private void ProcessHeader()
        {
            // Define an XDocument object and populate this object with the contents of the current file (inputFileName). 
            XDocument xDocument = XDocument.Load(inputFileName);
            // Define an XElement object and populate this object with the data found within the root element (student_update) of the xml file. 
            XElement rootData = xDocument.Element("student_update");
            //IEnumerable<XAttribute> xAttributesList = rootData.Attributes();
            // The XElement object must have 3 attributes. 
            if (rootData.Attributes().Count() != 3)
            {
                throw new Exception("\nIncorrect structure for " + inputFileName + " file.\n");
            }
            string date = rootData.Attribute("date").Value;
            string program = rootData.Attribute("program").Value;
            int checkSum = int.Parse(rootData.Attribute("checksum").Value);
            if (!DateTime.Parse(rootData.Attribute("date").Value).Equals(DateTime.Today))
            {
                throw new Exception("\nIncorrect date for " + inputFileName + " file.\n");
            }
            // The program attribute must match one of the academic program acronym values within the AcademicPrograms on the DB. 
            IEnumerable<string> academicProgramsAcronyms = db.AcademicPrograms
                .Select(x => x.ProgramAcronym).ToList();
            if (!academicProgramsAcronyms.Contains(program))
            {
                throw new Exception("\nThe ProgramsAcronym does not match with " + inputFileName + " file.\n");
            }
            // You may assume that all student_no element values in the file are numeric. 
            IEnumerable<XElement> studentNumber = rootData.Descendants("student_no");
            // The checksum attribute must match the sum of all student_no elements in the file.
            int sumMatch = 0;
            foreach (XElement studentNum in studentNumber)
            {
                sumMatch += int.Parse(studentNum.Value);
            }
            if (sumMatch != checkSum)
            {
                throw new Exception("\nThe Student Number does not match with " + inputFileName + " file.\n");
            }
        }
        /// <summary>
        /// This method is used to verify the contents of the detail records in the input file.  
        /// If any of the records produce an error, that record will be skipped, but the file processing will continue.   
        /// </summary>
        private void ProcessDetails()
        {
            // Define an XDocument object and populate this object with the contents of the current file(inputFileName). 
            XDocument xDocument = XDocument.Load(inputFileName);
            //Define an IEnumerable<XElement> LINQ-to-XML query against the XDocument object: 
            IEnumerable<XElement> transactions = xDocument.Descendants().Elements("transaction");
            // Each transaction element in the xml file must have 7 child elements.  
            IEnumerable<XElement> sevenChilds = transactions.Where(s => s.Elements().Count() == 7);
            // Use the ProcessErrors method (defined below) to write all erroneous records to the logData property
            ProcessErrors(transactions, sevenChilds, "\nChild elements are not seven\n");
            // The program element must match the program attribute of the root element.
            IEnumerable<XElement> programMatch = sevenChilds.Where(p => p.Element("program")
            .Value == xDocument.Root.Attribute("program").Value);
            // When calling ProcessErrors, include error message based on the round of validation that has taken place. 
            ProcessErrors(sevenChilds, programMatch, "\nprogram is not match\n");
            // The type element within each transaction element must be numeric.  
            IEnumerable<XElement> typeNumeric = programMatch.Where(t => Utility.Numeric
            .IsNumeric(t.Element("type").Value, NumberStyles.Number));
            // When calling ProcessErrors, include the result set of the previous query and the result set of the current query as arguments. 
            ProcessErrors(programMatch, typeNumeric, "\nInvalid type\n");
            // The grade element within each transaction element must be numeric or have the value of ‘*’
            IEnumerable<XElement> gradeNumeric = typeNumeric.Where(g => Utility.Numeric
            .IsNumeric(g.Element("grade").Value, NumberStyles.Number) || g.Element("grade")
            .Value == "*");
            ProcessErrors(typeNumeric, gradeNumeric, "\nInvalid grade\n");
            // The type element within each transaction element must have a value of 1 or 2.  
            IEnumerable<XElement> typeOneOrTwo = gradeNumeric.Where(g => g.Element("type")
            .Value=="1" || g.Element("type").Value=="2");
            ProcessErrors(gradeNumeric, typeOneOrTwo, "\nType is not 1 or 2\n");
            // The grade element for course registrations (type element = 1) within each transaction element must have a value of “*”.  
            IEnumerable<XElement> correctedGrade = typeOneOrTwo.Where(c => (c.Element
            ("type").Value == "1" && c.Element("grade").Value == "*") || (c.Element("type")
            .Value == "2" && double.TryParse(c.Element("grade").Value, out double gradeValue)
            && gradeValue >= 0 && gradeValue <= 100));
            ProcessErrors(typeOneOrTwo, correctedGrade, "\nInvalid Grade element or out of parameters\n");
            // Define an IEnumerable<long> LINQ-to-SQL Server query against the Students table retrieving a list of all Student Numbers.  
            IEnumerable<int> studentNumber = db.Students.Select(s => s.StudentNumber).ToList();
            // The result set should only include transaction elements whose student_no containing a list of all Student Numbers in the database.  
            IEnumerable < XElement > validStudentNumber = correctedGrade.Where(v => studentNumber.Contains(int.Parse
                  (v.Element("student_no").Value)));
            ProcessErrors(correctedGrade, validStudentNumber, "\nThe student Number does not exist.\n");
            // The course_no element within each transaction element must be a “*” for grading (type 2) or it must exist in the database.   
            IEnumerable<string> courseNumber = db.Courses.Select(c => c.CourseNumber).ToList();
            IEnumerable<XElement> validCourseNumber = validStudentNumber.Where(v =>
                (v.Element("type").Value == "2" && v.Element("course_no").Value == "*") ||
                (v.Element("type").Value == "1" && courseNumber.Contains(v.Element("course_no").Value)));
            ProcessErrors(validStudentNumber, validCourseNumber, "\nThe course number is not correct.\n");
            // The registration_no element within each transaction element must be a “*” for course registration (type 1) or it must exist in the database. 
            IEnumerable<long> allRegistrationNumbers = db.Registrations.Select(r => r.RegistrationNumber).ToList();
            // Define an IEnumerable<long> LINQ-to-SQL Server query against the Registrations table retrieving a list of all Registration Numbers.  
            IEnumerable<XElement> correctRegistrationNo = validCourseNumber.Where(c =>
                (c.Element("type").Value == "1" && c.Element("registration_no").Value == "*") ||
                /*(c.Element("type").Value == "2" &&*/ allRegistrationNumbers.Contains(long.Parse(c.Element("registration_no").Value)));
            ProcessErrors(validCourseNumber, correctRegistrationNo, "\nInvalid Registration number\n");
            // Call ProcessTransactions, sending in the error free result set.
            ProcessTransactions(correctRegistrationNo);
        }
        /// <summary>
        /// This method is used to process all valid transaction records.  
        /// Iterate through the result set passed to this method. 
        /// </summary>
        /// <param name="transactionRecords"></param>
        private void ProcessTransactions(IEnumerable<XElement> transactionRecords)
        {
            // Retrieve the BitCollege service instance
            BitCollegeService.CollegeRegistrationClient service = new BitCollegeService.CollegeRegistrationClient();
            // Extract values from the XElement objects in the result set as necessary in order to proceed. 
            foreach (var transaction in transactionRecords)
            {
                if (transaction.Element("type").Value == "1")
                {
                    // bring and parse student number
                    int studentNumber = (int)long.Parse(transaction.Element("student_no").Value);
                    // Use LINQ-to-SQL Server as necessary to obtain additional values from the database in order to proceed. 
                    // Get StudentNumber. 
                    Student student = (from Results in db.Students
                                       where Results.StudentNumber == studentNumber
                                       select Results).SingleOrDefault();
                    // Retrieve studentNumber to include in the successful message
                    int studentId = student.StudentId;
                    // Retrieve the courseNumber
                    string courseNumber = transaction.Element("course_no").Value;
                    // And get the courseId
                    Course course = (from Results in db.Courses
                                     where Results.CourseNumber == courseNumber
                                     select Results).SingleOrDefault();
                    int courseId = course.CourseId;
                    string notes = transaction.Element("notes").Value;
                    int registerReturnCode = service.RegisterCourse(studentId, courseId, notes);
                    if (registerReturnCode == 0)
                    {
                        logData += String.Format("\nSuccessful Registration Student {0} course {1}\n",
                            student.StudentNumber, course.CourseNumber);
                    }
                    else
                    {
                        logData += "ERROR: " + Utility.BusinessRules.RegisterError(registerReturnCode) + "\n";
                    }
                }
                // Evaluate the type element: grading
                if (int.Parse(transaction.Element("type").Value) == 2)
                {
                    // Valid grades within the input file are between the values of 0 and 100.  
                    double grade = Math.Round(double.Parse(transaction.Element("grade").Value) / 100, 2);
                    // Get the registration
                    long RegistrationNumber = long.Parse(transaction.Element("registration_no").Value);
                    Registration registration = (from Results in db.Registrations
                                                 where Results.RegistrationNumber == RegistrationNumber
                                                 select Results).SingleOrDefault();
                    // Retrieve registration number to include in the successful message
                    int registrationId = registration.RegistrationId;
                    // Retrieve studentNumber to include in the successful message
                    string studentNo = transaction.Element("student_no").Value;
                    // When calling the WCF Service method, use the Notes from the input file for the Notes argument. 
                    string notes = transaction.Element("notes").Value;
                    // If the transaction was successful:  
                    try
                    {
                        // Use the WCF Service to update the student’s grade. 
                        service.UpdateGrade(grade, registrationId, notes);
                        double normalGrade = grade * 100;
                        logData += String.Format("\ngrade {0} applied to the student {2} for registration {1}\n",
                            normalGrade, RegistrationNumber, studentNo);
                    }
                    // If the transaction was unsuccessful: 
                    catch (Exception ex)
                    {
                        // Append a relevant message to logData indicating that the transaction was unsuccessful.  
                        logData += string.Format("ERROR: " + ex.Message + "\n");
                    }
                }
            }
        }
        /// <summary>
        /// This method will process all detail errors found within the current file being processed. 
        /// </summary>
        /// <param name="beforeQuery"></param>
        /// <param name="afterQuery"></param>
        /// <param name="message"></param>
        private void ProcessErrors(IEnumerable<XElement> beforeQuery, IEnumerable<XElement> afterQuery, string message)
        {
            // Compare the records from the beforeQuery with those from the afterQuery.  
            IEnumerable<XElement> errors = beforeQuery.Except(afterQuery);
            // Process each of the records that failed validation by appending relevant information to the logData instance variable. 
            foreach (XElement transaction in errors)
            {
                // When writing to logData, ensure the error stands out and data is readable.  
                logData += "\r\n-------ERROR-------";
                logData += "\r\nFile: " + inputFileName;
                logData += "\r\nProgram: " + transaction.Element("program");
                logData += "\r\nStudent Number: " + transaction.Element("student_no");
                logData += "\r\nCourse Number: " + transaction.Element("course_no");
                logData += "\r\nRegistration Number: " + transaction.Element("registration_no");
                logData += "\r\nType: " + transaction.Element("type");
                logData += "\r\nGrade: " + transaction.Element("grade");
                logData += "\r\nNotes: " + transaction.Element("notes");
                logData += "\r\nNodes: " + transaction.Nodes().Count();
                logData += "\r\n" + message;
                logData += "\r\n-------------------";
            }
        }
        /// <summary>
        /// This method will be called upon completion of a file being processed. 
        /// </summary>
        public string WriteLogData()
        {
            // When a file has been processed, it will be renamed to include the word “COMPLETE” in the filename.
            string completeInput = "COMPLETE" + inputFileName;

            // Determine whether the “COMPLETE” file already exists
            if (File.Exists(completeInput))
            {
                // If so, use the File.Delete method to delete
                File.Delete(completeInput);
            }
            // Determine whether the original input file exists 
            if (File.Exists(inputFileName))
            {
                // if so: Use the File.Move method 
                File.Move(inputFileName, completeInput);
            }
            // Using a StreamWriter, open the logFileName 
            StreamWriter newLogData = new StreamWriter(logFileName, true);
            // write the accumulated logging data (logData) to the log file. 
            newLogData.Write(logData);
            // When all data has been written, close the StreamWriter. 
            newLogData.Close();
            // Capture the contents of the module level logging variable (logData) to return from this method 
            string loggingData = logData;
            // Empty the contents of logData 
            logData = string.Empty;
            // Empty the contents of logFileName
            logFileName = string.Empty;
            // Return the captured logging data to the calling routine. 
            return loggingData;
        }
    }
}
