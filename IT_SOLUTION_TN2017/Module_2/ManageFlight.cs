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
    public partial class ManageFlight : Form
    {
        private session_2_dbDataContext db = new session_2_dbDataContext();
        public static int r = 0;
        ScheduleEdit scheduleEdit;

        public ManageFlight()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string from = dtgvManage["From", r].Value.ToString();
            string to = dtgvManage["To", r].Value.ToString();
            string airCraft = dtgvManage["AirCraft", r].Value.ToString();
            int id = ScheduleID;
            scheduleEdit = new ScheduleEdit(id, from, to, airCraft);
            scheduleEdit.FormClosing += ScheduleEdit_FormClosing;
            this.Hide();
            scheduleEdit.ShowDialog(this);
            this.Show();
        }

        private void ScheduleEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadSchedule();
        }

        private void ManageFlight_Load(object sender, EventArgs e)
        {
            CBFromToInit();
            SortByInit();
            LoadSchedule();
            ScheduleID = (int)dtgvManage["ID", 0].Value;
            //set up cancel button
            r = dtgvManage.CurrentCell.RowIndex;
            if ((bool)dtgvManage.Rows[r].Cells["Confirmed"].Value != true)
            {
                btnCancel.Text = "Confirm Flight";
            }
            else
            {
                btnCancel.Text = "Cancel Flight";
            }
        }

        private void CBFromToInit()
        {
            // hiển thị combobox from - to
            var list = db.Airports.OrderBy(l => l.Name).Select(a => a.Name);
            cbTo.Items.Add("All Airports");
            cbFrom.Items.Add("All Airports");
            foreach (var item in list)
            {
                cbFrom.Items.Add(item);
                cbTo.Items.Add(item);
            }
            cbFrom.SelectedIndex = 0;
            cbTo.SelectedIndex = 0;
        }

        private void SortByInit()
        {
            cbSort.Items.Add("Date-time");
            cbSort.Items.Add("Price");
            cbSort.SelectedIndex = 0;
        }

        private void LoadSchedule()
        {
            string SortBy = cbSort.Text;
            string From = cbFrom.Text;
            string To = cbTo.Text;
            string FlightNumber = txtFlightNumber.Text.Trim();
            DateTime Date1 = dtpkOutbound.Value;

            var qFrom = from a in db.Airports
                        from r in db.Routes
                        where (r.DepartureAirportID == a.ID)
                        select new
                        {
                            RouteID = r.ID,
                            From = a.IATACode
                        };

            var qTo = from a in db.Airports
                      from r in db.Routes
                      where (r.ArrivalAirportID == a.ID)
                      select new
                      {
                          RouteID = r.ID,
                          To = a.IATACode
                      };

            var qAirport = from f in qFrom
                           from t in qTo
                           where (f.RouteID == t.RouteID)
                           select new
                           {
                               t.RouteID,
                               f.From,
                               t.To
                           };

            var query = from s in db.Schedules
                        from qa in qAirport
                        from a in db.Aircrafts
                        where s.RouteID == qa.RouteID && s.AircraftID == a.ID
                        select new
                        {
                            Date = s.Date.ToString(),
                            Time = s.Time.ToString().Remove(0, 11),
                            qa.From,
                            qa.To,
                            s.FlightNumber,
                            AirCraft = a.Name,
                            EconomyPrice = "$" + ((int)s.EconomyPrice).ToString(),
                            BusinessPrice = "$" + ((int)(s.EconomyPrice * 135 / 100)).ToString(),
                            FirstClassPrice = "$" + ((int)(s.EconomyPrice * 135 / 100 * 130 / 100)).ToString(),
                            Price = s.EconomyPrice,
                            s.Confirmed,
                            s.ID
                        };

            // Filter
            string date = Date1.ToString("yyyy-MM-dd");

            if (SortBy == "Price")
            {
                query = query.OrderBy(q => q.Price);
            }


            if (From != "All Airports")
            {
                string AirportIATACode = db.Airports.Where(a => a.Name == From).Select(a => a.IATACode).Single();
                query = query.Where(q => q.From == AirportIATACode);
            }


            if (To != "All Airports")
            {
                string AirportIATACode = db.Airports.Where(a => a.Name == To).Select(a => a.IATACode).Single();
                query = query.Where(q => q.To == AirportIATACode);
            }



            if (FlightNumber != "")
            {
                query = query.Where(q => q.FlightNumber == FlightNumber);
            }

            dtgvManage.DataSource = query.ToList();

            foreach (DataGridViewRow row in dtgvManage.Rows)
            {
                if (!(bool)row.Cells["Confirmed"].Value)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }

            // Hide column
            dtgvManage.Columns["Confirmed"].Visible = false;
            dtgvManage.Columns["Price"].Visible = false;
            dtgvManage.Columns["ID"].Visible = false;            
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        public static int ScheduleID;

        private void btnCancel_Click(object sender, EventArgs e)
        {

            r = dtgvManage.CurrentCell.RowIndex;
            ScheduleID = (int)dtgvManage.Rows[r].Cells["ID"].Value;

            var query = from q in db.Schedules where (q.ID == ScheduleID) select (q);
            query.Single().Confirmed = !query.Single().Confirmed;
            db.SubmitChanges();
            LoadSchedule();
            if ((bool)dtgvManage.Rows[r].Cells["Confirmed"].Value != true)
            {
                btnCancel.ImageList = imageList1;
                btnCancel.ImageKey = "active.png";
                btnCancel.Text = "Confirm Flight";
            }
            else
            {
                btnCancel.ImageKey = "close.png";
                btnCancel.Text = "Cancel Flight";
            }
        }

        private void dtgvManage_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            r = dtgvManage.CurrentCell.RowIndex;
            ScheduleID = (int)dtgvManage.Rows[r].Cells["ID"].Value;

            if ((bool)dtgvManage.Rows[r].Cells["Confirmed"].Value != true)
            {
                btnCancel.ImageList = imageList1;
                btnCancel.ImageKey = "active.png";
                btnCancel.Text = "Confirm Flight";
            }
            else
            {
                btnCancel.ImageKey = "close.png";
                btnCancel.Text = "Cancel Flight";
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.Hide();
            Apply_Schedule_Changes apply_Schedule_Changes = new Apply_Schedule_Changes();
            apply_Schedule_Changes.ShowDialog(this);
            this.Show();
        }
    }
}
