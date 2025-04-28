using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Array
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }   
        Form2 f2 = new Form2();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //string data = "";
                string name = txtName.Text;
                string gender = "";
                string hobbies = "";
                string favColor = cbmFavColor.Text;
                string saying = txtSaying.Text;

                if (radMale.Checked == true)
                {
                    gender = radMale.Text;
                }
                else if (radFemale.Checked == true)
                {
                    gender = radFemale.Text;
                }
                if (chkBasketball.Checked == true)
                {
                    hobbies += chkBasketball.Text + ",";
                }
                if (chkVolleyball.Checked == true)
                {
                    hobbies += chkVolleyball.Text + ",";
                }
                if (chkSoccer.Checked == true)
                {
                    hobbies += chkSoccer.Text + ",";
                }

                //data = name + gender + hobbies + favColor + saying;
                //info[i] = data;
                //i++;
                f2.InsertData(name, gender, hobbies, favColor, saying);
                clearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {        
            Form1 f1 = new Form1();
            f1.btnAdd.Visible = false;
            
            f2.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string gender = "";
                string hobbies = "";
                string favColor = cbmFavColor.Text;
                string saying = txtSaying.Text;

                if (radMale.Checked == true)
                {
                    gender = radMale.Text;
                }
                else if (radFemale.Checked == true)
                {
                    gender = radFemale.Text;
                }
                if (chkBasketball.Checked == true)
                {
                    hobbies += chkBasketball.Text + ",";
                }
                if (chkVolleyball.Checked == true)
                {
                    hobbies += chkVolleyball.Text + ",";
                }
                if (chkSoccer.Checked == true)
                {
                    hobbies += chkSoccer.Text + ",";
                }
                f2.UpdateData(f2.Id, name, gender, hobbies, favColor, saying);
                clearInput();
            }
            catch (Exception err)

            {
                MessageBox.Show(err.Message);
            }
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
        
        }
        public void clearInput()
        {
            txtName.Text = null;
            radFemale.Checked = false;
            radMale.Checked = false;
            chkBasketball.Checked = false;
            chkVolleyball.Checked = false;
            chkSoccer.Checked = false;
            cbmFavColor.SelectedItem = null;
            txtSaying.Text = null;
        }

        private void dtpBirthDay_ValueChanged(object sender, EventArgs e)
        {
            int Age = DateTime.Today.Year - dtpBirthDay.Value.Year;
            txtAge.Text = Age.ToString();
        
        }

        

    }
}
