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
            FillFactoryComboBox();
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

            if (ofd.ShowDialog() == DialogResult.OK)
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
        public class Manufacturer
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
        private void FillFactoryComboBox()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT manufacturerID, factory FROM manufacturer", con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    factory_ComboBox.Items.Add(new Manufacturer { ID = id, Name = name });
                }
                con.Close();
            }
        }
        private void button_upload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name_product_TextBox.Text) || string.IsNullOrWhiteSpace(richTextBox_inf.Text) || factory_ComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            var selectedFactory = (Manufacturer)factory_ComboBox.SelectedItem;
            int manufacturerID = selectedFactory.ID;
            string name = name_product_TextBox.Text;
            string info = richTextBox_inf.Text;

            using (SqlCommand cmd = new SqlCommand("INSERT INTO product (name_product, txt_info, manufacturerID) VALUES (@name, @info, @manufacturerID)", con))

            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@info", info);
                cmd.Parameters.AddWithValue("@manufacturerID", manufacturerID);

                con.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product added successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to add product.");
                }
            }
        }
    }
}