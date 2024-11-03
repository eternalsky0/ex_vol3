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
    public partial class not_trusted : Form
    {
        public not_trusted()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void log_in_back_button_Click(object sender, EventArgs e)
        {
            log_in log_in = new log_in();
            log_in.Show();
            this.Hide();
        }
    }
}
