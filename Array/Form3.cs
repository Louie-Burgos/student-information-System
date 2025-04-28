using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Array
{
    public partial class Form3 : Form
    {
        Workbook book = new Workbook();
 
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the file path is correct and the file exists
                string filePath = @"C:\Users\ACT-STUDENT\Desktop\EvedriBURGOS-EXCELL.xlsx"; // Make sure to add the .xlsx extension
                book.LoadFromFile(filePath);
                Worksheet sheet = book.Worksheets[0];
                int rowCount = sheet.LastRow; // Use LastRow to get the actual number of filled rows

                bool loginSuccessful = false; // Flag to indicate successful login

                for (int i = 2; i <= rowCount; i++) // Assuming the first row is for headers
                {
                    string excelUser = sheet.Range[i, 10].Text.Trim(); // Get the username from column 10 (J)
                    string excelPass = sheet.Range[i, 11].Text.Trim(); // Get the password from column 11 (K)

                    // Check both username and password
                    if (excelUser == txtUsername.Text.Trim() && excelPass == txtPassword.Text.Trim())
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 form1 = new Form1(); // This would be the main form after a successful login
                        this.Hide(); // Optionally, hide the current form
                        form1.Show();
                        loginSuccessful = true; // Update flag
                        break; // Exit the loop on successful login
                    }
                }

                if (!loginSuccessful) // If no match was found, show an error message
                {
                    MessageBox.Show("Wrong username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
