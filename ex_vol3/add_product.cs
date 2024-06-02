using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;



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

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //back to reg button
        private void button_back_Click_1(object sender, EventArgs e)
        {
            main test = new main();
            test.Show(); this.Hide();
        }
        //image select
        private void button_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }
        //image convert to byte
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
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
        //upload
        private void button_upload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name_product_TextBox.Text) || string.IsNullOrWhiteSpace(richTextBox_inf.Text) || factory_ComboBox.SelectedItem == null || pictureBox1.Image == null)
            {
                MessageBox.Show("Please fill in all fields and select an image.");
                return;
            }
            var selectedFactory = (Manufacturer)factory_ComboBox.SelectedItem;
            int manufacturerID = selectedFactory.ID;
            string name = name_product_TextBox.Text;
            string info = richTextBox_inf.Text;

            byte[] imageData = ImageToByteArray(pictureBox1.Image);

            using (SqlCommand cmd = new SqlCommand("INSERT INTO product (name_product, txt_info, manufacturerID, image) VALUES (@name, @info, @manufacturerID, @image)", con))

            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@info", info);
                cmd.Parameters.AddWithValue("@manufacturerID", manufacturerID);
                cmd.Parameters.AddWithValue("@image", imageData);
                con.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product added successfully.");
                    name_product_TextBox.Clear();
                    richTextBox_inf.Clear();
                    factory_ComboBox.Items.Clear();
                    country_ComboBox.Items.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to add product.");
                }
            }
        }
        //clear gpt
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox_inf.Clear();
        }

        //api, generate txt
        private async void gpt_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name_product_TextBox.Text))
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            string name = name_product_TextBox.Text;
            string apiUrl = "https://api.deepseek.com/v1/chat/completions";
            string apiKey = "sk-2eabbce5d49a41378fd0be9e6bb84e4b";

            gpt_button.Enabled = false;
            button1.Enabled = false;
            richTextBox_inf.Text = "Generating response... Please wait.";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

                var requestBody = new
                {
                    model = "deepseek-chat",
                    messages = new[]
                    {
                new
                {
                    role = "system",
                    content = "You are an expert in military affairs and aircraft (such as drones and so on). you need to tell information about a given object. if it is not related to drones or military equipment, then write no such thing"
                },
                new
                {
                    role = "user",
                    content = name
                }
            },
                    stream = false
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestBody), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiUrl, content);
                var responseString = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<dynamic>(responseString);

                richTextBox_inf.Text = responseObject.choices[0].message.content;
                gpt_button.Enabled = true;
                button1.Enabled = true;
            }
        }
    }
}
