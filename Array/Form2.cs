using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Array
{
    public partial class Form2 : Form
    {
        Spire.Xls.Workbook book = new Spire.Xls.Workbook();
        public Form2()
        {
            InitializeComponent();
        }   

        public void bookLoadFromFile()
        {
            Worksheet sheet = book.Worksheets[0];
            book.LoadFromFile(@"C:\Users\ACT-STUDENT\Desktop\EvedriBURGOS-EXCELL.xlsx");

            Worksheet sheet2 = book.Worksheets[1];

            sheet.Range[9, 2].Value = "";
            sheet.Range[10, 2].Value = "";
            
            
            
            

        }

        public int Id = 0;

        public void InsertData(string name, string gender, string hobbies, string favColor, string saying)
        {
            data.Rows.Add(name, gender, hobbies, favColor, saying);
        }
        public void UpdateData(int id, string name, string gender, string hobbies, string favColor, string saying)
        {
            data.Rows[id].Cells[0].Value = name;
            data.Rows[id].Cells[1].Value = gender;
            data.Rows[id].Cells[2].Value = hobbies;
            data.Rows[id].Cells[3].Value = favColor;
            data.Rows[id].Cells[4].Value = saying;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.btnUpdate.Visible = true;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in data.SelectedRows)
                {
                    DialogResult = MessageBox.Show("Are you sure to delete?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.OK) {
                        data.Rows.Remove(row);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            data.ClearSelection();
            try
            {
                foreach (DataGridViewRow row in data.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(txtSearch.Text))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("User not found");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.chkBasketball.Checked = false;
            form1.chkVolleyball.Checked = false;
            form1.chkSoccer.Checked = false;
            try
            {                
                int r = data.CurrentCell.RowIndex;
                Id = r;         
                form1.btnAdd.Visible = false;
                form1.btnUpdate.Visible = true;
                form1.txtName.Text = data.Rows[r].Cells[0].Value.ToString();
                string gender = data.Rows[r].Cells[1].Value.ToString();
                if (gender == "Male")
                {
                    form1.radMale.Checked = true;
                }
                else if(gender == "Female")
                {
                    form1.radFemale.Checked = true;
                }

                string hobbies = data.Rows[r].Cells[2].Value.ToString().ToUpper(); ;
                string[] hob = hobbies.Split(',');

                foreach (string val in hob)
                {
                    if (val == "BASKETBALL")
                    {
                        form1.chkBasketball.Checked = true;                       
                    }
                    if (val == "VOLLEYBALL")
                    {
                        form1.chkVolleyball.Checked = true;
                    }               
                    if (val == "SOCCER")
                    {
                        form1.chkSoccer.Checked = true;
                    }
                    

                }             
                string favColor = data.Rows[r].Cells[3].Value.ToString();
                form1.cbmFavColor.SelectedItem = favColor;
                string saying = data.Rows[r].Cells[4].Value.ToString();
                form1.txtSaying.Text = saying;           
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Does not contain value");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
         }

        private void data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
