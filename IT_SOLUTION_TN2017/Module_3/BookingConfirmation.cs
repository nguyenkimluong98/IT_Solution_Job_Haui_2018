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
    public partial class BookingConfirmation : Form
    {
        Session_3_dbDataContext db = new Session_3_dbDataContext();

        public BookingConfirmation()
        {
            InitializeComponent();
        }
    }
}
