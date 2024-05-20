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
    public partial class test : Form
    {
        private BindingSource productsBindingSource = new BindingSource();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EAONQ68; Initial Catalog=military; Integrated Security=True");
        
        public test()
        {
            InitializeComponent();
            productsBindingSource.DataSource = CreateDataTable();
            dataGridView1.DataSource = productsBindingSource;
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
                using (SqlCommand cmd = new SqlCommand("SELECT product.productID, product.name_product as Name, manufacturer.factory, availability1.quantity, country.country as Country " +

                                                                        "FROM product " +

                                                                        "JOIN manufacturer ON product.manufacturerID = manufacturer.manufacturerID " +

                                                                        "JOIN availability1 ON availability1.productID = product.productID " +

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
            try
            {
                con.Open();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var quantityValue = row.Cells["Quantity"].Value;

                    if (quantityValue != null && (int)quantityValue >= 0)
                    {
                        int newQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        int productID = Convert.ToInt32(row.Cells["ProductID"].Value);

                        string updateQuery = "UPDATE availability1 SET quantity = @quantity WHERE productID = @productID";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@quantity", newQuantity);
                            cmd.Parameters.AddWithValue("@productID", productID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                con.Close();
                MessageBox.Show("Сохранения внесены успешно!");
            }
            catch
            {
                MessageBox.Show("error");
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

                Product_str Product_str = new Product_str(productId, productName, txtInfo, productImage);
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

        private void add_new_product_button_Click(object sender, EventArgs e)
        {
            add_product add_product = new add_product();
            add_product.Show();
            this.Hide();
        }
    }
}