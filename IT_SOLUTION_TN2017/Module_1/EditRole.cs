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
    public partial class EditRole : System.Windows.Forms.Form
    {
        public EditRole()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.ToString() == "" || txtFirstName.Text.ToString() == "" || txtLastName.Text.ToString() == "")
            {
                MessageBox.Show("You must input all information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                using (session_1_dbDataContext db = new session_1_dbDataContext())
                {
                    var query = (from u in db.Users where (u.ID == LoginMain.seletedIndex) select u).First();
                    query.Email = txtEmail.Text;
                    query.LastName = txtLastName.Text;
                    query.FirstName = txtFirstName.Text;

                    if (rdAdmin.Checked == true)
                        query.RoleID = 1;
                    else query.RoleID = 2;

                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("Changed successful!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Changed unsuccessful! Try again later.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void EditRole_Load(object sender, EventArgs e)
        {
            using (session_1_dbDataContext db = new session_1_dbDataContext())
            {
                var query = (from u in db.Users where (u.ID == LoginMain.seletedIndex) select u).First();
                txtEmail.Text = query.Email.ToString();
                txtFirstName.Text = query.FirstName.ToString();
                txtLastName.Text = query.LastName.ToString();

                if (query.RoleID == 1)
                    rdAdmin.Checked = true;
                else rdUser.Checked = true;

                var officeSource = from u in db.Offices select new { id = u.ID, title = u.Title };
                cbOffice.DataSource = officeSource.ToList();
                cbOffice.ValueMember = "id";
                cbOffice.DisplayMember = "title";
                int oID = (int)query.OfficeID;
                // 1 3 4 5 6
                if (oID == 1)
                    oID = 0;
                else if (oID >= 3)
                    oID -= 2;
                cbOffice.SelectedIndex = oID;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditRole_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
