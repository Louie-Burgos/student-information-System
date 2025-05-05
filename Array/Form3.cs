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
        private Workbook book = new Workbook();

        public Form3()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = @"C:\Users\ACT-STUDENT\Desktop\EvedriBURGOS-EXCELL.xlsx";
                book.LoadFromFile(filePath);
                Worksheet sheet = book.Worksheets[0];
                int rowCount = sheet.LastRow;

                bool loginSuccessful = false;

                for (int i = 2; i <= rowCount; i++)
                {
                    string excelUser = sheet.Range[i, 10].Text.Trim(); // Column J
                    string excelPass = sheet.Range[i, 11].Text.Trim(); // Column K

                    if (excelUser == txtUsername.Text.Trim() && excelPass == txtPassword.Text.Trim())
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form4 form4 = new Form4();
                        this.Hide();
                        form4.Show();
                        loginSuccessful = true;
                        break;
                    }
                }

                if (!loginSuccessful)
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

