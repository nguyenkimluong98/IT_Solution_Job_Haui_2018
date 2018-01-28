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
    public partial class LoginMain : System.Windows.Forms.Form
    {
        session_1_dbDataContext db = new session_1_dbDataContext();
        int rowIndex;
        EditRole editRole = new EditRole();
        AddUser addUser = new AddUser();

        public LoginMain()
        {
            InitializeComponent();
            editRole.FormClosing += EditRole_FormClosing;
            addUser.FormClosing += AddUser_FormClosing;
        }

        private void AddUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadData();
        }

        private void EditRole_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadData();
        }

        private void LoginMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("Do you really want to quit?", "Quit System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (result == DialogResult.Cancel)
            //{
            //    e.Cancel = true;
            //}
        }

        public void LoginMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbAllOffices_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = cbAllOffices.SelectedIndex;
            if (id == 0)
            {
                QueryAll();
            }
            else
            {
                if (id == 1)
                {

                }
                else id += 1;
                var userSource = from u in db.Users
                                     //from v in db.Offices
                                 where (u.OfficeID == (id))
                                 select new
                                 {
                                     ID = u.ID,
                                     firstName = u.FirstName,
                                     lastName = u.LastName,
                                     date = u.Birthdate,
                                     userRole = u.RoleID,
                                     email = u.Email,
                                     offID = u.OfficeID,
                                     active = u.Active
                                 };
                dtgvUser.DataSource = userSource.ToList();
                int i = 0;
                foreach (var item in userSource)
                {
                    dtgvUser["Age", i].Value = DateTime.Now.Year - item.date.Value.Year;
                    if (item.userRole == 1)
                    {
                        dtgvUser["UserRole", i].Value = "adminitrator";
                        dtgvUser.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                    else
                        dtgvUser["UserRole", i].Value = "office user";

                    if (item.active == false)
                    {
                        dtgvUser.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }

                    dtgvUser["Office", i].Value = (from u in db.Offices where (u.ID == item.offID) select u.Title).First();
                    i++;
                }
            }
        }

        public void QueryAll()
        {
            var userSource = from u in db.Users
                             select new
                             {
                                 id = u.ID,
                                 firstName = u.FirstName,
                                 lastName = u.LastName,
                                 date = u.Birthdate,
                                 userRole = u.RoleID,
                                 email = u.Email,
                                 offID = u.OfficeID,
                                 active = u.Active
                             };
            dtgvUser.DataSource = userSource.ToList();
            foreach (var item in userSource)
            {
                dtgvUser["Age", item.id - 1].Value = DateTime.Now.Year - item.date.Value.Year;

                if (item.userRole == 1)
                {
                    dtgvUser["UserRole", item.id - 1].Value = "adminitrator";
                    dtgvUser.Rows[item.id - 1].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
                else
                    dtgvUser["UserRole", item.id - 1].Value = "office user";

                if (item.active == false)
                {
                    dtgvUser.Rows[item.id - 1].DefaultCellStyle.BackColor = Color.Red;
                }

                dtgvUser["Office", item.id - 1].Value = (from u in db.Offices where (u.ID == item.offID) select u.Title).First();
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addUser.StartPosition = FormStartPosition.CenterParent;
            addUser.ShowDialog(this);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEDLogin_Click(object sender, EventArgs e)
        {
            if (rowIndex != -1)
            {
                var getUN = (from ord in db.Users
                            where ord.Email == dtgvUser["EmailAddress", rowIndex].Value.ToString()
                            select ord).First();
                if (getUN.Email != Constain.userName)
                {
                    var val = dtgvUser["active", rowIndex].Value;
                    if (val.ToString() == "True")
                    {
                        dtgvUser["active", rowIndex].Value = false;
                        var query =
                                    from ord in db.Users
                                    where ord.Email == dtgvUser["EmailAddress", rowIndex].Value.ToString()
                                    select ord;

                        // Execute the query, and change the column values
                        // you want to change.
                        //if (query.First().Email == Constain.userName)
                        foreach (var ord in query)
                        {
                            ord.Active = false;
                            // Insert any additional changes to column values.
                        }



                        // Submit the changes to the database.
                        try
                        {
                            db.SubmitChanges();
                            cbAllOffices_SelectedIndexChanged(sender, e);
                            dtgvUser.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                            dtgvUser["active", rowIndex].Value = "False";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can't disable this account!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            // Provide for exceptions.
                        }
                    }
                    else
                    {

                        var query =
                                    from ord in db.Users
                                    where ord.Email == dtgvUser["EmailAddress", rowIndex].Value.ToString()
                                    select ord;

                        // Execute the query, and change the column values
                        // you want to change.
                        foreach (var ord in query)
                        {
                            ord.Active = true;
                            // Insert any additional changes to column values.
                        }



                        // Submit the changes to the database.
                        try
                        {
                            db.SubmitChanges();
                            cbAllOffices_SelectedIndexChanged(sender, e);

                            if (dtgvUser["UserRole", rowIndex].Value.ToString() == "office user")
                                dtgvUser.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                            else dtgvUser.Rows[rowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;

                            dtgvUser["active", rowIndex].Value = "True";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can't enable this account!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            // Provide for exceptions.
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You can't change role yourself!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }


        }

        public void LoadData()
        {
            var officeQuery = from n in db.Offices select new { officeName = n.Title, officeID = n.ID };

            cbAllOffices.Items.Add("All Offices");
            //cbAllOffices.DataSource = officeQuery.ToList();
            //cbAllOffices.ValueMember = "officeID";
            //cbAllOffices.DisplayMember = "officeName";
            foreach (var item in officeQuery)
            {
                cbAllOffices.Items.Add(item.officeName);
            }

            cbAllOffices.SelectedIndex = 0;

            QueryAll();
        }

        private void dtgvUser_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndex = dtgvUser.HitTest(e.X, e.Y).RowIndex;
            //dtgvUser.Rows[rowIndex].Selected = true;
            //dtgvUser.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Blue;
        }

        public static int seletedIndex;

        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            if (rowIndex != - 1)
            {
                seletedIndex = (from ord in db.Users
                                where ord.Email == dtgvUser["EmailAddress", rowIndex].Value.ToString()
                                select ord.ID).First();
                editRole.StartPosition = FormStartPosition.CenterParent;
                editRole.ShowDialog(this);
            }
        }

    }
}
