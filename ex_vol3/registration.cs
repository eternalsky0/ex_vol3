using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex_vol3
{
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }

        private void log_in_back_button_Click(object sender, EventArgs e)
        {
            log_in log_in_form = new log_in();
            log_in_form.Show();
            this.Hide();
        }
    }
}
