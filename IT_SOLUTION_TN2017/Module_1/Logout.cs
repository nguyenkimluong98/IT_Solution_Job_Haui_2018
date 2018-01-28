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
    public partial class Logout : System.Windows.Forms.Form
    {
        public Logout()
        {
            InitializeComponent();
        }

        private void Logout_Load(object sender, EventArgs e)
        {
            using (session_1_dbDataContext db = new session_1_dbDataContext())
            {
                var query = (from u in db.TimeOnSystems where (u.ID == Login.index) select u).First();
                lblNotify.Text = "No logout detected for your last login on " + query.Date.ToShortDateString() + " at " + query.Login.ToString();
            }
            rbSystem.Checked = true;             
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            using (session_1_dbDataContext db = new session_1_dbDataContext())
            {
                var query = (from u in db.TimeOnSystems where (u.ID == Login.index) select u).First();
                if (rbSystem.Checked == true)
                {
                    query.Reason = "Power outage";
                }
                else query.Reason = "Hanging program";

                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Thanks for your respond!", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                catch
                {
                    MessageBox.Show("Please try again later!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }
    }
}
