using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Module_2
{
    public partial class Apply_Schedule_Changes : Form
    {
        session_2_dbDataContext db = new session_2_dbDataContext();
        public Apply_Schedule_Changes()
        {
            InitializeComponent();
        }

        public void ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtImport.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        // tạo đối tượng mở tệp tin
        OpenFileDialog fileDialog = new OpenFileDialog();

        private void txtImport_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // chỉ ra đuôi file
            lblDuplicate.Text = "[ xxxx ]";
            lblMissing.Text = "[ xxxx ]";
            lblSuccess.Text = "[ xxxx ]";
            fileDialog.Filter = "(All files)|*.*|(All excel files)|*.xlsx";
            fileDialog.ShowDialog();

            //xử lí
            if (fileDialog.FileName != "")
            {
                txtImport.Text = fileDialog.FileName;
            }
            else
            {
                MessageBox.Show("You did not choose any files!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void txtImport_MouseDown(object sender, MouseEventArgs e)
        {
            txtImport.Text = "";
        }

        string date, departure, aviral, price, aircraft, flightNum;
        TimeSpan time;
        string activities;
        string confirm;
        Excel.Application app;
        Excel.Workbook wb;
        private void btnImport_Click(object sender, EventArgs e)
        {
            //tạo đối tượng excel
            if (fileDialog.FileName != "")
            {
                app = new Excel.Application();

                // mở tệp excel
                wb = app.Workbooks.Open(fileDialog.FileName);
                Excel._Worksheet sheet = wb.Sheets[1];
                Excel.Range range = sheet.UsedRange;

                // đọc dữ liệu
                int rows = range.Rows.Count;
                int cols = range.Columns.Count;
                int j = 0;
                for (int i = 1; i <= rows; i++)
                {
                    try
                    {
                        date = range.Cells[i, 2].Value.ToString();
                        string time1 = range.Cells[i, 3].Value.ToString();
                        DateTime time2 = DateTime.FromOADate(Convert.ToDouble(time1));
                        TimeSpan time3 = time2.TimeOfDay;
                        activities = range[i, 1].Value.ToString();
                        flightNum = range.Cells[i, 4].Value.ToString();
                        departure = range.Cells[i, 5].Value.ToString();
                        aviral = range.Cells[i, 6].Value.ToString();
                        aircraft = range.Cells[i, 7].Value.ToString();
                        price = range.Cells[i, 8].Value.ToString();
                        confirm = range.Cells[i, 9].Value.ToString();
                        j = i;
                        AddDataToDB();
                        if (i == rows)
                        {
                            MessageBox.Show("Complete!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            success = 0; duplicate = 0; error = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message + "\n" + j, caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                        error++;
                    }

                }
                this.FormClosed += Apply_Schedule_Changes_FormClosed;
            }
            else
            {
                MessageBox.Show("You did not choose any files!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void Apply_Schedule_Changes_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (app != null)
            {
                app.Workbooks.Close();
                app.Quit();
            }
        }

        int success = 0, duplicate = 0, error = 0;

        void AddDataToDB()
        {
            if (activities.Trim() == "" || date.Trim() == "" || time == null ||
                flightNum.Trim() == "" || departure.Trim() == "" || aviral.Trim() == "" ||
                aircraft.Trim() == "" || price.Trim() == "" || confirm.Trim() == "")
            {
                error++;
            }
            else
            {
                try
                {
                    TimeSpan tTime = time;
                    Decimal tPrice = Convert.ToDecimal(price);
                    DateTime tDate;

                    if (DateTime.TryParse(date, out tDate))
                    {
                        String.Format("{0:yyyy/MM/dd}", tDate);
                    }
                    else
                    {
                        //MessageBox.Show("hi");
                        error++;
                        return;
                    }

                    bool tConfirm = confirm == "OK" ? true : false;
                    int tAircraft = Convert.ToInt32(aircraft);

                    int qFrom = (from f in db.Airports where (f.IATACode == departure) select (f.ID)).Single();

                    int qTo = (from f in db.Airports where (f.IATACode == aviral) select (f.ID)).Single();

                    int RouteID = (from r in db.Routes where (r.ArrivalAirportID == qTo && r.DepartureAirportID == qFrom) select (r.ID)).Single();

                    if (activities == "ADD")
                    {
                        int query = (from q in db.Schedules
                                     where (q.Date == tDate && q.Time == tTime && q.RouteID == RouteID && q.FlightNumber == flightNum &&
                                            q.EconomyPrice == tPrice && q.AircraftID == tAircraft && q.Confirmed == tConfirm)
                                     select q).Count();

                        if (query == 1)
                        {
                            duplicate++;
                        }
                        else
                        {
                            Schedule schedule = new Schedule();
                            schedule.Date = tDate;
                            schedule.Time = tTime;
                            schedule.AircraftID = tAircraft;
                            schedule.RouteID = RouteID;
                            schedule.EconomyPrice = tPrice;
                            schedule.Confirmed = tConfirm;
                            schedule.FlightNumber = flightNum;

                            db.Schedules.InsertOnSubmit(schedule);
                            db.SubmitChanges();
                            success++;
                        }
                    }
                    else if (activities == "EDIT")
                    {
                        var query = (from q in db.Schedules where (q.RouteID == RouteID && q.AircraftID == tAircraft && q.Date == tDate) select (q)).First();

                        query.EconomyPrice = tPrice;
                        query.Confirmed = tConfirm;
                        query.Time = tTime;
                        query.FlightNumber = flightNum;

                        db.SubmitChanges();
                        success++;
                    }
                }
                catch (Exception)
                {
                    error++;
                    //MessageBox.Show("vl");
                }
            }

            lblDuplicate.Text = "[ " + duplicate + " ]";
            lblSuccess.Text = "[ " + success + " ]";
            lblMissing.Text = "[ " + error + " ]";
        }

    }
}
