using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CaptchaSharp;


namespace ex_vol3
{

    public partial class log_in : Form
    {
        //sql connect db
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EAONQ68; Initial Catalog=users; Integrated Security=True");

        private string generatedCaptchaText;
        public log_in()
        {
            InitializeComponent();
            GenerateCaptcha();
            log_textBox.MaxLength = 16;
            pas_textBox1.MaxLength = 16;
        }

        private void log_textBox_TextChanged(object sender, EventArgs e)
        {

        }
        //log in 
        private void log_in_button_Click(object sender, EventArgs e)
        {
            string login = log_textBox.Text;
            string password = pas_textBox1.Text;
            string capchaText = capcha_textBox.Text;
            
            

            if(capchaText.Equals(generatedCaptchaText, StringComparison.OrdinalIgnoreCase)) //на тот случай, если непонтяно, верхний или нижний регситр
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE login = @login AND password = @password", con);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Вход выполнен успешно!");
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                    pas_textBox1.Clear();
                    capcha_textBox.Clear();
                    GenerateCaptcha();
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Неверно введена капча!");
                capcha_textBox.Clear();
                GenerateCaptcha();
            }
        }
        //show password
        private void show_pas_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (show_pas_checkBox.Checked)
            {
                pas_textBox1.PasswordChar = '\0';
                pas_textBox1.Font = new Font(pas_textBox1.Font.FontFamily, 14);
            }
            else
            {
                pas_textBox1.PasswordChar = '*';
                pas_textBox1.Font = new Font(pas_textBox1.Font.FontFamily, 22);
            }
        }
        //login max 16 chars
        private void log_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (log_textBox.Text.Length >= 16)
            {
                e.Handled = true;
            }
        }
        //password max 16 chars
        private void pas_textBox_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if(pas_textBox1.MaxLength >= 16)
            {
                e.Handled= true;
            }
        }
        //captcha
        private void GenerateCaptcha()
        {
            Random random = new Random();
            generatedCaptchaText = GenerateRandomString(6); // Используем глобальную переменную

            Bitmap bmp = new Bitmap(170, 64);

            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.Clear(Color.White);

                for (int i = 0; i < 1000; i++)
                {
                    int x = random.Next(bmp.Width);
                    int y = random.Next(bmp.Height);
                    bmp.SetPixel(x, y, Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
                }
                string[] fonts = { "Arial", "Times New Roman", "Verdana", "Georgia" };
                int[] sizes = { 16, 18, 20, 22, 24 };

                string[] colors = { "Red", "Blue", "Green", "Orange", "Purple" };
                Font font = new Font("Arial", 20);

                for (int i = 0; i < generatedCaptchaText.Length; i++)
                {
                    SolidBrush brush = new SolidBrush(Color.FromName(colors[random.Next(colors.Length)]));
                    graphics.DrawString(generatedCaptchaText[i].ToString(), font, brush, 20 * i, 20);
                }

                capcha_pictureBox.Image = bmp;
            }
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder result = new StringBuilder();

            for(int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
 
        }
        //generate new captcha
        private void capcha_reload_button_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void registration_button_Click(object sender, EventArgs e)
        {
            registration registration_form = new registration();
            registration_form.Show();
            this.Hide();
        }
    }
}
