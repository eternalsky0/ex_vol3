using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex_vol3
{
    public partial class Product_str : Form

    {
        private int productId;
        private string productName;
        private Image productImage;
        private string txtInfo;
        public Product_str(int productId, string productName, string txtInfo, Image productImage)

        {

            InitializeComponent();
            this.productId = productId;
            this.productName = productName;
            this.productImage = productImage;
            this.txtInfo = txtInfo;

            pictureBox_product3.Image = productImage;
            productNameLabel.Text = productName;
            text_richTextBox.Text = txtInfo;
            label_id2.Text = productId.ToString();
        }




    }

    
}