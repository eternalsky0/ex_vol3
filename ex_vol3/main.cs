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
using TheArtOfDevHtmlRenderer.Adapters;

namespace ex_vol3
{
    public partial class main : Form
    {
        private BindingSource productsBindingSource = new BindingSource();
        private DataTable productsTable; 
        private BindingSource usersTableBindingSource = new BindingSource();
        private DataTable usersTable;

        private bool showProduct = false;

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EAONQ68; Initial Catalog=military; Integrated Security=True");
        
        public main()
        {
            InitializeComponent();
            HideButton();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximumSize = this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void HideButton()
        {
            save_change_buton.Visible = false;
            add_new_product_button.Visible = false;
            delete_product_button.Visible = false;
            delete_users_button.Visible = false;
            save_change_button2.Visible = false;
        }
        public void ShowButton()
        {
            save_change_buton.Visible = true;
            add_new_product_button.Visible = true;
            delete_product_button.Visible = true;
        }

        //вывод таблицы users
        private DataTable CreateDataTable_users()
        {
            DataTable usersTable = new DataTable();

            showProduct = false;    

            usersTable.Columns.Add("UserID", typeof(int));
            usersTable.Columns["UserID"].ReadOnly = true;
            usersTable.Columns.Add("Login", typeof(string));
            usersTable.Columns.Add("RealName", typeof(string));
            usersTable.Columns.Add("RoleID", typeof(int));

            using (SqlCommand cmd = new SqlCommand("SELECT userID, login, real_name as RealName, roleID FROM users1", con))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(usersTable);
                }
            }
            return usersTable;
        }
        //вывод таблицы product
        public DataTable CreateDataTable_product()
        {
            DataTable productsTable = new DataTable();
            showProduct = true;

            productsTable.Columns.Add("ProductID", typeof(int));
            productsTable.Columns["ProductID"].ReadOnly = true;
            productsTable.Columns.Add("Name", typeof(string));
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
        //удаление данных из бд продукт
        private void delete_product_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить продукт?", "Повтерждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    con.Open();
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int productID = Convert.ToInt32(row.Cells["ProductID"].Value);

                        SqlCommand deleteCommand = new SqlCommand("DELETE FROM product WHERE productID = @productID", con);
                        deleteCommand.Parameters.AddWithValue("@productID", productID);
                        deleteCommand.ExecuteNonQuery();

                        productsTable.PrimaryKey = new DataColumn[] { productsTable.Columns["productID"] };

                        DataRow rowToDelete = productsTable.Rows.Find(productID);
                        if (rowToDelete != null)
                        {
                            productsTable.Rows.Remove(rowToDelete);
                        }
                    }
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали продукт для удаления. Для удаления выберите всю строку.", "Ошибка", MessageBoxButtons.OK);
            }
        }
        //сохранение изменений данных продукт
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
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM product", con);

                SqlCommand updateCommand = new SqlCommand("UPDATE product SET name_product = @name_product, quantity = @quantity WHERE productID = @productID", con);
                updateCommand.Parameters.Add("@productID", SqlDbType.Int, 0, "ProductID");
                updateCommand.Parameters.Add("@name_product", SqlDbType.VarChar, 50, "Name");
                updateCommand.Parameters.Add("@quantity", SqlDbType.Int, 0, "Quantity");
                adapter.UpdateCommand = updateCommand;

                SqlCommand deleteCommand = new SqlCommand("DELETE FROM product WHERE productID = @productID", con);

                deleteCommand.Parameters.Add("@productID", SqlDbType.Int, 0, "ProductID");
                adapter.DeleteCommand = deleteCommand;

                adapter.Update(productsTable);
            }
        }

        //открытие информации о продукте
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (showProduct && e.RowIndex >= 0)
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
            else
            {
                MessageBox.Show("Ошибка.");
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
        //переход на форму добавлении продукта
        private void add_new_product_button_Click(object sender, EventArgs e)
        {
            add_product add_product = new add_product();
            add_product.Show();
            this.Hide();
        }
        //переход на продукт
        private void product_button_Click(object sender, EventArgs e)
        {
            GoProduct();
        }
        public void GoProduct()
        {
            productsTable = CreateDataTable_product();
            productsBindingSource.DataSource = productsTable;
            dataGridView1.DataSource = productsBindingSource;

            ShowButton();
            delete_users_button.Visible = false;
        }

        //переход на юзерс
        private void users_db_button_Click(object sender, EventArgs e)
        {
            usersTable = CreateDataTable_users();
            usersTableBindingSource.DataSource = usersTable;
            dataGridView1.DataSource = usersTableBindingSource;

            HideButton();
            save_change_button2.Visible = true;
            delete_users_button.Visible = true;
        }

        private void save_change_button2_Click(object sender, EventArgs e)
        {
            bool changesMade = false;

            foreach (DataRow row in usersTable.Rows)
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
                errorUserDB();
            }
            else
            {
                try
                {
                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM users1", con);

                    SqlCommand updateCommand = new SqlCommand("UPDATE users1 SET login = @login, real_name = @real_name, roleID = @roleID WHERE userID = @userID", con);

                    updateCommand.Parameters.Add("@roleID", SqlDbType.Int, 0, "RoleID");
                    updateCommand.Parameters.Add("@login", SqlDbType.VarChar, 50, "Login");
                    updateCommand.Parameters.Add("@real_name", SqlDbType.VarChar, 50, "RealName");
                    updateCommand.Parameters.Add("@userID", SqlDbType.Int, 0, "UserID");

                    adapter.UpdateCommand = updateCommand;

                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM users1 WHERE userID = @userID", con);
                    deleteCommand.Parameters.Add("@userID", SqlDbType.Int, 0, "UserID");
                    adapter.DeleteCommand = deleteCommand;
                    adapter.Update(usersTable);

                    con.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при обновлении данных: " + ex.Message);
                    errorUserDB();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                    errorUserDB();
                }
            }
        }
        private void errorUserDB()
        {
            usersTable.RejectChanges();
            dataGridView1.Refresh();
        }

        private void delete_users_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить пользователя?", "Подтверждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    con.Open();
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int userID = Convert.ToInt32(row.Cells["userID"].Value);

                        SqlCommand deleteCommand = new SqlCommand("DELETE FROM users1 WHERE userID = @userID", con);
                        deleteCommand.Parameters.AddWithValue("@userID", userID);
                        deleteCommand.ExecuteNonQuery();

                        usersTable.PrimaryKey = new DataColumn[] { usersTable.Columns["userID"] };

                        DataRow rowToDelete = usersTable.Rows.Find(userID);

                        if (rowToDelete != null)
                        {
                            usersTable.Rows.Remove(rowToDelete);
                        }
                    }
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали объект удаления. Для удаления выберите всю строку.", "Ошибка", MessageBoxButtons.OK);
            }
        }
    }
}

