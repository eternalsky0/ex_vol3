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

namespace ex_vol3
{
    public partial class main2 : Form
    {
        private BindingSource productsBindingSource = new BindingSource();
        private DataTable productsTable;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EAONQ68; Initial Catalog=military; Integrated Security=True");
        public main2()
        {
            InitializeComponent();
            productsTable = CreateDataTable();
            productsBindingSource.DataSource = productsTable;
            dataGridView1.DataSource = productsBindingSource;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //вывод таблицы
        private DataTable CreateDataTable()
        {
            DataTable productsTable = new DataTable();
            productsTable.Columns.Add("ProductID", typeof(int));
            productsTable.Columns["ProductID"].ReadOnly = true;
            productsTable.Columns.Add("Name", typeof(string));
            productsTable.Columns["Name"].ReadOnly = true;
            productsTable.Columns.Add("Factory", typeof(string));
            productsTable.Columns["Factory"].ReadOnly = true;
            productsTable.Columns.Add("Country", typeof(string));
            productsTable.Columns["Country"].ReadOnly = true;
            productsTable.Columns.Add("Quantity", typeof(int));

            {
                using (SqlCommand cmd = new SqlCommand("SELECT product.productID, product.name_product as Name, manufacturer.factory, product.quantity, country.country as Country " +
                                                                        "FROM product " +
                                                                        "JOIN manufacturer ON product.manufacturerID = manufacturer.manufacturerID " +
                                                                        "JOIN country ON manufacturer.countryID = country.countryID", con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(productsTable);
                    }
                }
            }
            return productsTable;
        }
        //сохранение изменений данных
        private void save_change_buton_Click(object sender, EventArgs e)
        {
            bool changesMade = false;

            foreach (DataRow row in productsTable.Rows)
            {
                if (row.RowState == DataRowState.Modified)
                {
                    changesMade = true;
                    break;
                }
            }

            if (!changesMade)
            {
                MessageBox.Show("Вы не внесли никаких изменений. Пожалуйста, внесите изменения и повторите попытку.", "Ошибка", MessageBoxButtons.OK);
                return;
            }

            DialogResult result = MessageBox.Show("Вы действительно хотите сохранить изменения?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                productsTable.RejectChanges();
                dataGridView1.Refresh();
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE product SET quantity = @quantity WHERE productID = @productID", con))
                {
                    con.Open();
                    foreach (DataRow row in productsTable.Rows)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@productID", row["ProductID"]);
                        cmd.Parameters.AddWithValue("@quantity", row["Quantity"]);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
        }

        //открытие информации о продукте
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                int productId = Convert.ToInt32(row.Cells["ProductID"].Value);

                string productName = row.Cells["Name"].Value.ToString();

                string txtInfo = GetTxt(productId);

                // Получаем изображение из базы данных
                byte[] imageData = GetImageDataFromDatabase(productId);

                // Преобразуем бинарные данные в изображение
                Image productImage = byteArrayToImage(imageData);

                // Передаем id, имя и изображение товара в форму Product_str
                Product_view Product_str = new Product_view(productId, productName, txtInfo, productImage);
                Product_str.ShowDialog();
            }
        }
        //получение картинки
        private byte[] GetImageDataFromDatabase(int productId)
        {
            byte[] imageData = null;

            using (SqlCommand cmd = new SqlCommand("SELECT image FROM product WHERE productID = @productID", con))
            {
                cmd.Parameters.AddWithValue("@productID", productId);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        imageData = (byte[])reader["image"];
                    }
                }
                con.Close();
            }
            return imageData;
        }
        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        //картинка получена

        //получение инфомации о продукте. отправка этих данных на форму продукт
        private string GetTxt(int productID)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT txt_info FROM product WHERE productID = @productID;", con))
            {
                cmd.Parameters.AddWithValue("@productID", productID);
                con.Open();
                string txtInfo = (string)cmd.ExecuteScalar();
                con.Close();
                return txtInfo;
            }
        }
    }
}

