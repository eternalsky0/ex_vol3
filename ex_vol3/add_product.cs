using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex_vol3
{
    public partial class add_product : Form
    {
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EAONQ68; Initial Catalog=military; Integrated Security=True");
        public add_product()
        {
            InitializeComponent();
            LoadContry();
            LoadFactory();
            
        }

        //back to reg button
        private void button_back_Click_1(object sender, EventArgs e)
        {
            test test = new test();
            test.Show(); this.Hide();
        }
        //загрузка фото
        private void button_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }
        //combobox country
        private void LoadContry()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT countryID, country FROM country", con))
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    country_ComboBox.Items.Add(rdr["country"].ToString());
                }
                con.Close();
            }
        }
        //combobox factory
        private void LoadFactory()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT manufacturerID, factory FROM manufacturer", con))
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    factory_ComboBox.Items.Add(rdr["factory"].ToString());
                }
                con.Close();
            }

        }
    }
}
