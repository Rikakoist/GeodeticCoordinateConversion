using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeodeticCoordinateConversion
{
    public partial class Form1 : Form
    {
        private GEOSettings AppSettings = new GEOSettings();
        private FileIO DataFile = new FileIO();
        public BindingList<CoordConvert> CoordData = new BindingList<CoordConvert>();
        public BindingList<ZoneConvert> ZoneData = new BindingList<ZoneConvert>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CoordConvertLayout ccl = new CoordConvertLayout();
            ccl.Dock = DockStyle.Fill;
            this.Controls.Add(ccl);
        }
    }
}
