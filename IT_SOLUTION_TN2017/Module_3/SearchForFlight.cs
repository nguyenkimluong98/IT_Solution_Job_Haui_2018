using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module_3
{
    public partial class SearchForFlight : Form
    {
        Session_3_dbDataContext db = new Session_3_dbDataContext();

        public SearchForFlight()
        {
            InitializeComponent();
        }

        void SetUp()
        {
            var list = db.Airports.OrderBy(q => q.IATACode).Select(l => l.IATACode);
            cbFrom.DataSource = list.ToList();
            cbTo.DataSource = list.ToList();

            var cabinType = db.CabinTypes.Select(q => q.Name);
            cbType.DataSource = cabinType.ToList();
            rdOneWay.Checked = true;
        }

        private void SearchForFlight_Load(object sender, EventArgs e)
        {
            SetUp();
        }
    }
}
