using PRG_Project_Final.Data_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG_Project_Final.Presentation
{
    public partial class Modules : Form
    {
        public Modules()
        {
            InitializeComponent();
        }

        DataHandler handler = new DataHandler();

        private void Modules_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = handler.GetModules();
        }
    }
}
