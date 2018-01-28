/*
 * Chưa load lại form sau khi tạo user mới 
 *
 **/







using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_1
{
    public partial class AddUser : System.Windows.Forms.Form
    {
        session_1_dbDataContext db = new session_1_dbDataContext();
        public AddUser()
        {
            InitializeComponent();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int a = 0, b = 0, c = 0, d = 0, e1 = 0, f = 0, g = 0, h = 0;
            string email = txtEmail.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string office = cbOffice.SelectedText;

            //string date = txtDate.Text;
            DateTime date;
            DateTime.TryParseExact(txtDate.Text, "dd/MM/yy", null,
                                   System.Globalization.DateTimeStyles.None, out date);
            string pass = txtPassword.Text;

            int temp = (from u in db.Users where (u.Email == email) select u).Count();


            if (email == "")
            {
                txtEmail.Text = "* What's your email adress?";
                txtEmail.ForeColor = Color.Red;
                a = 1;
            }
            
            if (temp == 1)
            {
                txtEmail.Text = "* This email have been used!";
                txtEmail.ForeColor = Color.Red;
                b = 1;
            }
            

            if (firstName == "")
            {
                txtFirstName.Text = "* What's your first name?";
                txtFirstName.ForeColor = Color.Red;
                c = 1;
            }

            if (lastName == "")
            {
                txtLastName.Text = "* What's your last name?";
                txtLastName.ForeColor = Color.Red;
                d = 1;
            }

            if (pass == "")
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = "* Input your password!?";
                txtPassword.ForeColor = Color.Red;
                e1 = 1;
            }

            if (date == null)
            {
                txtPassword.Text = "* Input your password!?";
                txtPassword.ForeColor = Color.Red;
                f = 1;
            }

            if (cbOffice.Text == "Office name" || cbOffice.Text == "")
            {
                cbOffice.ForeColor = Color.Red;
                cbOffice.Text = "* Choose your office name correctly!";
                g = 1;
            }

            if (txtDate.Text == "[ dd/MM/yy ]" || txtDate.Text == "")
            {
                txtDate.Text = "* Input your birthday!";
                txtDate.ForeColor = Color.Red;
                h = 1;
            }

            if (txtEmail.Text == "* What's your email adress?" ||
                txtEmail.Text == "* This email have been used!" ||
                txtFirstName.Text == "* What's your first name?" ||
                txtLastName.Text == "* What's your last name?"||
                 txtPassword.Text == "* Input your password!?" ||
                 cbOffice.Text == "* Choose your office name correctly!" ||
                 txtDate.Text == "* Input your birthday!")
            {
                MessageBox.Show("You must input all information!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (a == 0 && b == 0 && c == 0 && d == 0 && e1 == 0 && f == 0 && g == 0 && h == 0)
            {
                using (session_1_dbDataContext db = new session_1_dbDataContext())
                {
                    User user = new User();
                    user.Email = email;
                    user.Birthdate = date;
                    user.Active = true;
                    user.FirstName = firstName;
                    user.LastName = lastName;
                    int idx = cbOffice.SelectedIndex;
                    if (idx < 1)
                        idx += 1;
                    else idx += 2;
                    user.OfficeID = idx;
                    user.Password = GenerateMD5(pass);
                    user.RoleID = 2;
                    user.ID = (from u in db.Users select (u)).Count() + 1;

                    db.Users.InsertOnSubmit(user);

                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("Added successfuly!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        LoginMain loginMain = new LoginMain();
                        loginMain.LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can't add this account!\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else return;
        }

        private string GenerateMD5(string str)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(str)).Select(s => s.ToString("x2")));
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            var officeQuery = from n in db.Offices select new { officeName = n.Title, officeID = n.ID };
            cbOffice.DataSource = officeQuery.ToList();
            cbOffice.DisplayMember = "officeName";
            cbOffice.ValueMember = "officeID";
            LoadData();
        }

        private void txtDate_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtDate.Text == "[ dd/MM/yy ]" || txtDate.Text == "* Input your birthday!")
            {
                txtDate.Text = "";
                txtDate.ForeColor = Color.Black;
            }
        }

        private void cbOffice_MouseClick(object sender, MouseEventArgs e)
        {            
            if (cbOffice.Text == "Office name" || cbOffice.Text == "* Choose your office name correctly!")
            {
                cbOffice.Text = "";
            }
            cbOffice.ForeColor = Color.Black;
        }

        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtEmail.Text == "* What's your email adress?" || txtEmail.Text == "* This email have been used!")
                txtEmail.Text = "";
            txtEmail.ForeColor = Color.Black;
        }

        private void txtFirstName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtFirstName.Text == "* What's your first name?")
                txtFirstName.Text = "";
            txtFirstName.ForeColor = Color.Black;
        }

        private void txtLastName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtLastName.Text == "* What's your last name?")
                txtLastName.Text = "";
            txtLastName.ForeColor = Color.Black;
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "* Input your password!?")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginMain loginMain = new LoginMain();
            loginMain.Show();
        }

        private void LoadData()
        {
            cbOffice.Text = "Office name";
            txtDate.Text = "[ dd/MM/yy ]";
        }
    }
}
