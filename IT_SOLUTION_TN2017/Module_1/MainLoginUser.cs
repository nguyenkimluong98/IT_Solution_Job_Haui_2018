using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_1
{
    public partial class MainLoginUser : Form
    {
        public MainLoginUser()
        {
            InitializeComponent();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainLoginUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerSpent.Stop();
            Constain.logoutTime = DateTime.Now;
            SetDataToDB();
            //this.Close();
        }

        private void MainLoginUser_Load(object sender, EventArgs e)
        {
            lblHello.Text = "Hi " + Constain.userName + ", Welcome to AMONIC Airlines.";
            timerSpent.Start();
            int temp = 0;
            using (session_1_dbDataContext db = new session_1_dbDataContext())
            {
                var queru = from u in db.TimeOnSystems
                                 from v in db.Users
                                 where (u.UserID == v.ID && v.Email == Constain.userName)
                                 select new
                                 {
                                     id = u.ID,
                                     date = u.Date,
                                     login = u.Login,
                                     logout = u.Logout,
                                     spentTime = u.SumTime,
                                     reason = u.Reason
                                 };
                dtgvTime.DataSource = queru.ToList();
                
                foreach (var item in queru)
                {
                    if (item.logout == null)
                    {
                        temp++;
                        dtgvTime["Logout", item.id - 1].Value = "**";
                        dtgvTime.Rows[item.id - 1].DefaultCellStyle.BackColor = Color.Red;
                    }

                    if (item.spentTime == null)
                        dtgvTime["SumTime", item.id-1].Value = "**";
                    else dtgvTime["SumTime", item.id - 1].Value = item.spentTime.ToString();                    
                }
            }

            lblCrash.Text = "Number of crashes:   " + temp;

            SetDataOnDFirst();
        }

        void SetDataOnDFirst()
        {
            using (session_1_dbDataContext db = new session_1_dbDataContext())
            {
                TimeOnSystem timeOnSystem = new TimeOnSystem();
                timeOnSystem.Date = Constain.dateTimeLogin;
                Constain.ID = (from u in db.TimeOnSystems select u).Count() + 1;
                timeOnSystem.ID = Constain.ID;
                timeOnSystem.Login = Constain.loginTime.ToShortTimeString();
                timeOnSystem.Logout = null;
                timeOnSystem.SumTime = null;
                timeOnSystem.UserID = (from v in db.Users
                                       where (v.Email == Constain.userName)
                                       select v.ID).First();

                db.TimeOnSystems.InsertOnSubmit(timeOnSystem);

                try
                {
                    db.SubmitChanges();
                }
                catch
                {

                }
            }
        }

        private void timerSpent_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Time spent on system: " + SpentTime();
        }

        int h = 0, m = 0, s = 0;

        private String SpentTime()
        {
            s++;
            if (s == 60)
            {
                m++;
                s = 0;
            }

            if (m == 60)
            {
                h++;
                m = 0;
            }

            string hh, mm, ss;
            hh = h < 10 ? ("0" + h) : (h + "");
            mm = m < 10 ? ("0" + m) : (m + "");
            ss = s < 10 ? ("0" + s) : (s + "");

            return hh + " : " + mm + " : " + ss;
        }

        void SetDataToDB()
        {
            using (session_1_dbDataContext db = new session_1_dbDataContext())
            {
                var query = (from u in db.TimeOnSystems
                             from v in db.Users
                             where (v.Email == Constain.userName && v.ID == u.UserID && u.ID == Constain.ID)
                             select u).First();
                
                query.Logout = Constain.logoutTime.ToShortTimeString();
                query.SumTime = SpentTime();

                try
                {
                    db.SubmitChanges();
                }
                catch
                {

                }
            }
        }
    }
}
