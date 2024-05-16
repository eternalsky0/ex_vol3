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

        private DataTable CreateDataTable()
        {
            DataTable productsTable = new DataTable();
            productsTable.Columns.Add("ProductID",  typeof(int));
            productsTable.Columns.Add("Name", typeof(string));
            productsTable.Columns.Add("Factory", typeof(string));
            productsTable.Columns.Add("Country", typeof(string));
            productsTable.Columns.Add("Quantity", typeof(int));


            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EAONQ68; Initial Catalog=military; Integrated Security=True"))
            {
                con.Open();
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

        private void save_change_buton_Click(object sender, EventArgs e)
        {
            con.Open();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Quantity"].Value != null)
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
            MessageBox.Show("Changes saved successfully!");
        }
    }
}