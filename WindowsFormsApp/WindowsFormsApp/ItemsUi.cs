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

namespace WindowsFormsApp
{
    public partial class ItemsUi : Form
    {
        public ItemsUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddData();
        }

        private void showBhutton_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchData();
        }
       
        private void AddData()
        {
            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Items WHERE Name Like'" + itemsNameTextBox.Text + "%'", sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int num = sqlDataAdapter.Fill(dataTable);
            if (num > 0)
            {
                MessageBox.Show("enter Another name");

            }

            else
            {
                string commandString = @"INSERT INTO Items  Values ('" + itemsNameTextBox.Text + "'," + itemsPriceTextBox.Text + " )";
                SqlCommand sqlCommand1 = new SqlCommand(commandString, sqlConnection);

            try
                {
                    int isExecuted = sqlCommand1.ExecuteNonQuery();
                    if (isExecuted > 0)
                    {
                        MessageBox.Show("Saved");
                    }  
                    else
                    {
                        MessageBox.Show("Not Saved");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            sqlConnection.Close();

        }

        private void ShowData()
        {
            
            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

             
            string commandString = @"SELECT * FROM Items";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            
            sqlConnection.Open();

           
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                showDataGridView.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
          
            sqlConnection.Close();
        }
        private void DeleteData()
        {


            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);


            string commandString = @"DELETE FROM Items WHERE  ItemsId = " + itemsIdTextBox.Text + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataReader myReader;

            sqlConnection.Open();

            try
            {
                myReader = sqlCommand.ExecuteReader();

                MessageBox.Show("data deleted");
                if (myReader.Read())
                {

                }

                sqlConnection.Close();
            }


            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void UpdateData()
        {

            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);


            string commandString = @"UPDATE  Items SET   Name = ' " + itemsNameTextBox.Text + "', Price =  " + itemsPriceTextBox.Text + "  WHERE ItemsId = " + itemsIdTextBox.Text + " ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataReader myReader;
           
            sqlConnection.Open();

            try
            {
                myReader = sqlCommand.ExecuteReader();

                MessageBox.Show("Update ");
                if (myReader.Read())
                {

                }

                sqlConnection.Close();
            }


            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
        private void SearchData()
        {
            string connectionString = @"Server=FATEMA-PC\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Items WHERE Name Like'" + itemsNameTextBox.Text + "%'", sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            showDataGridView.DataSource = dataTable;
            sqlConnection.Close();
        }

       
    }

}
