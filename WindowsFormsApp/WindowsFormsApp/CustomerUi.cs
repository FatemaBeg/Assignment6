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
    public partial class CustomerUi : Form

    {
        

        public CustomerUi()
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

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Customers WHERE Name Like'" + customerNameTextBox.Text + "%'", sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int num = sqlDataAdapter.Fill(dataTable);
            if (num > 0)
            {
                MessageBox.Show("enter Another name");

            }

            else
            {
                string commandString = @"INSERT INTO Customers  Values ('" + customerNameTextBox.Text + "','" + customerAddressTextBox.Text + "', '" + customerContactTextBox.Text + "')";
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

               
                string commandString = @"SELECT * FROM Customers";
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

               
                string commandString = @"DELETE FROM Customers WHERE  CustomerId = " + customerIdTextBox.Text + "";
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

             
                string commandString = @"UPDATE  Customers SET   Name = ' " + customerNameTextBox.Text +  "', Address = ' "+ customerAddressTextBox.Text +" ', Contact =  '"+ customerContactTextBox.Text + "' WHERE CustomerId = "+ customerIdTextBox.Text +" ";
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

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Customers WHERE Name Like'" + customerNameTextBox.Text + "%'", sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            showDataGridView.DataSource = dataTable;
            sqlConnection.Close();
        }
       
    }
}
    














