using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Module_1
{
    public partial class Login : System.Windows.Forms.Form
    {
        session_1_dbDataContext db;

        public Login()
        {
            DatabaseSetup();
            InitializeComponent();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to quit?", "Quit System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string userName = textBoxUsername.Text;
            string password = GenerateMD5(textBoxPassword.Text);

            var query = (from u in db.Users where u.Email.CompareTo(userName) == 0 && u.Password.CompareTo(password) == 0 select u);
            int temp = query.Count();

            if (temp == 1 && query.First().Active == true)
            {
                SuccessedLogin(userName, password);
            }
            else if (temp == 1 && query.First().Active == false)
            {
                MessageBox.Show("This account is disabled! Please contact with adminitrator to have more information!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (Constain.countFailLogin < 2)
                {
                    FailedLogin();
                    Constain.countFailLogin++;
                }
                else
                {
                    PenaltyFailedLogin();
                }
            }
        }

        private void PenaltyFailedLogin()
        {
            timerCountDown.Start();
            MessageBox.Show("You have logined fail THREE times. Please wait...", "Error login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            panelLogin.Enabled = false;
            Constain.countFailLogin = 0;
        }

        private void FailedLogin()
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
            lblDemGio.Text = "Username or password is incorrect! Please try again!";
            textBoxUsername.MouseClick += TextBoxUsername_MouseClick;
        }

        private void TextBoxUsername_MouseClick(object sender, MouseEventArgs e)
        {
            lblDemGio.Text = "";
        }

        private void SuccessedLogin(string userName, string password)
        {
            var accountType = (from u in db.Users where u.Email.CompareTo(userName) == 0 && u.Password.CompareTo(password) == 0
                               select new { roleID = u.RoleID,
                                   name = u.FirstName });
            if (accountType.First().roleID == 1)
            {
                Constain.userName = accountType.First().name.ToString();
                this.Hide();
                LoginMain loginMain = new LoginMain();
                loginMain.ShowDialog();
                this.Show();
            }
            else
            {
                Constain.userName = accountType.First().name.ToString();            
                Setup();              
                this.Hide();
                Crashes();
                MainLoginUser mainLoginUser = new MainLoginUser();
                mainLoginUser.ShowDialog();
                this.Show();
            }
        }

        public static int index;

        void Crashes()
        {
            index = (from u in db.TimeOnSystems select u).Count();
            var query = (from u in db.TimeOnSystems where (u.ID == index) select u).First();
            if (query.Logout == null)
            {
                Logout logout = new Logout();
                logout.ShowDialog();
            }
        }

      
        private void Setup()
        {
            Constain.dateTimeLogin = DateTime.Today;                     
            Constain.loginTime = DateTime.Now;
        }

        private void DatabaseSetup()
        {
            db = new session_1_dbDataContext();
        }

        private string GenerateMD5(string str)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(str)).Select(s => s.ToString("x2")));
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            lblDemGio.Text = "You can login after " + Constain.timeDown.ToString() + " seconds!";
            Constain.timeDown--;
            if (Constain.timeDown < 0)
            {
                timerCountDown.Stop();
                panelLogin.Enabled = true;
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
                lblDemGio.Text = "";
                Constain.timeDown = 10;
            }
        }

        //private void textBoxUsername_TextChanged(object sender, EventArgs e)
        //{
        //    lblDemGio.Text = "";
        //}
    }
}
