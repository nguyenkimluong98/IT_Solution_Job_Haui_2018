using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_2
{
    public partial class ScheduleEdit : Form
    {
        session_2_dbDataContext db = new session_2_dbDataContext();
        int id;
        string from, to, aircraft;
        public ScheduleEdit()
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var query = db.Schedules.Where(q => q.ID == id).Single();
            query.Date = Convert.ToDateTime(txtDate.Text.Trim());
            query.Time = TimeSpan.Parse(txtTime.Text.Trim());
            query.EconomyPrice = Convert.ToInt32(txtPrice.Text.Trim());

            try
            {
                MessageBox.Show("Update successful!");
                db.SubmitChanges();
            }
            catch (Exception)
            {

                MessageBox.Show("Update unsuccessful! Please check again!");
            }
        }

        public ScheduleEdit(int id, string From, string To, string aircraft)
        {
            InitializeComponent();
            this.id = id;
            this.from = From;
            this.to = To;
            this.aircraft = aircraft;
        }

        private void ScheduleEdit_Load(object sender, EventArgs e)
        {
            var query = db.Schedules.Where(q => q.ID == id).Single();
            txtDate.Text = query.Date.ToShortDateString();
            txtPrice.Text = ((int)query.EconomyPrice).ToString();
            txtTime.Text = query.Time.ToString();
            lblFrom.Text = from;
            lblTo.Text = to;
            lblAircraft.Text = aircraft;
        }


    }
}
