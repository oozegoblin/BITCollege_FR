using BITCollege_Felipe_Rincon.Data;
using BITCollege_Felipe_Rincon.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
* Name: Felipe Rincon
* Course: COMP-1283 C# Programming 4
* Created: 2024-05-05
* Updated: 2024-06-08
*/
namespace BITCollegeWindows
{
    public partial class Batch : Form
    {
        // Define an instance of your BITCollege_FLContext class for use in this form. 
        BITCollege_Felipe_RinconContext db = new BITCollege_Felipe_RinconContext();
        public Batch()
        {
            InitializeComponent();
            // ComboBox enable event implementation
            radSelect.CheckedChanged += RadSelect_CheckedChanged;
        }
        /// <summary>
        /// radSelect_CheckedChanged event implementation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadSelect_CheckedChanged(object sender, EventArgs e)
        {
            // Ensure that the AcademicProgram ComboBox is enabled only when the “Select a Transmission” RadioButton is checked.
            descriptionComboBox.Enabled = true;
        }

        /// <summary>
        /// lnkProcess_LinkClicked event implementation
        /// given:  ensures key is entered
        /// further code to be added
        /// </summary>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ////NOTE:  This may be commented out until needed
            //if (txtKey.Text == "")
            //{
            //    MessageBox.Show("A 64-bit Key must be entered", "Error");
            //}
            BatchProcess batch = new BatchProcess();
            // If a single transmission selection has been made: 
            if (radSelect.Checked)
            { 
                //var selectedProgram = ((AcademicProgram)descriptionComboBox.SelectedItem).ProgramAcronym;
                // Call the ProcessTransmission method of the BatchProcess class passing appropriate arguments.
                batch.ProcessTransmission(descriptionComboBox.SelectedValue.ToString());
                //batch.ProcessTransmission(programAcronym);
                // Call the WriteLogData method of the BatchProcess class to write all logging information 
                rtxtLog.Text +=
                    // Capture the return value and append this value to the richText control’s Text property. 
                    batch.WriteLogData();
            }
            // If all transmissions have been selected 
            if (radAll.Checked)
            {
                descriptionComboBox.Enabled = true;
                // Iterate through each item in the ComboBox collection.
                foreach (var item in descriptionComboBox.Items)
                {
                    // For each iteration: 
                    AcademicProgram academicProgram = item as AcademicProgram;
                    string acronym = academicProgram.ProgramAcronym;
                    // Call the ProcessTransmission method of the Batch class passing appropriate arguments. 
                    batch.ProcessTransmission(acronym);
                    // Call the WriteLogData method of the Batch class to write all logging information. 
                    rtxtLog.Text += batch.WriteLogData();
                }
            }           
        }
        /// <summary>
        /// Batch_load event implementation
        /// given:  open in top right of frame
        /// further code required:
        /// </summary>
        private void Batch_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            // Populate the BindingSource object associated with the AcademicProgram ComboBox
            // retrieving all records from the AcademicPrograms table. 
            IQueryable<AcademicProgram> academicProgram = db.AcademicPrograms;
            academicProgramBindingSource.DataSource = academicProgram.ToList();
            // Ensure that the AcademicProgram ComboBox is enabled only is any checkbox is checked.
            descriptionComboBox.Enabled = false;
        }
        /// <summary>
        /// decrypt button click event implementation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decryptbtb_Click(object sender, EventArgs e)
        {
            // Define a string variable to represent the plaintext file name 
            string plaintextFileName;
            // Define a string variable to represent the encrypted file name
            string encryptedFileName;
            // Set the plaintext string variable to the value of the FileName
            plaintextFileName = fileNametxtbox.Text;
            // Set the encrypted string variable to the value of the plaintext string variable + “.encrypted” 
            encryptedFileName = plaintextFileName + ".encrypted";
            // Call the Decrypt method of the Utility project’s Encryption class 
            Utility.Encryption.Decrypt(plaintextFileName, encryptedFileName, txtKey.Text);
            // verify the successful decryption
            StreamReader reader = new StreamReader(plaintextFileName);
            rtxtLog.Text = reader.ReadToEnd();
            reader.Close();
        }
    }
}
