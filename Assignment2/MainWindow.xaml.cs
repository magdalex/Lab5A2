using A2RESTAPI.Models;
using Assignment2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con;
        HttpClient client = new HttpClient();
        public MainWindow()
        {
            client.BaseAddress = new Uri("https://localhost:7295/api/"); //this is the base path for me that got auto-generated-- the port number may be different for you
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        //this establishes connection to your database
        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-5DGA5O7\\SQLEXPRESS;Initial Catalog=DesptopAppDevAssignment1;Integrated Security=True"; //change this to your connection string!
                con = new SqlConnection(connectionString);
                con.Open();
                MessageBox.Show("Connection established successfully.");
                con.Close();

                refreshDataButton_Click(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //SELECT
        //this can be used to refresh the datagrid in case it doesn't automatically do that
        private void refreshDataButton_Click(object sender, RoutedEventArgs e) //this method seems to work
        {
            try
            {
                this.RefreshProducts(); //calls the refresh method
            }
            catch
            {
                MessageBox.Show("Could not refresh inventory.");
            }
        }

        private async void RefreshProducts() //this method works
        {

            var response = await client.GetStringAsync("Product/GetAllProd/"); //this is the path that gets called
            var products = JsonConvert.DeserializeObject<Response>(response).listProduct; //maps fields of json to response class
           
            dataGrid.ItemsSource = products; //puts it straight into the datagrid
            
        }

        //INSERT
        //this allows new items to be added to the database table
        private async void insertButton_Click(object sender, RoutedEventArgs e) //this method seems to work
        {
            //add code to check to see if the product exists first or to make sure that we don't insert an empty object
            try
            {
                var product = new Product()
                {
                    productID = int.Parse(productID.Text),
                    productName = productName.Text,
                    price = float.Parse(price.Text),
                    kgInventory = int.Parse(amountKG.Text)
                };

                var response = await client.PostAsJsonAsync("Product/InsertProd/", product);
                
                MessageBox.Show("Inserted product successfully into the database.");


                refreshDataButton_Click(sender, e); //this auto clicks the refresh button at the end of the operation so the user doesnt have to manually press it
            }
            catch
            {
                MessageBox.Show("Insert operation failed.");
            }

        }

        //UPDATE
        //this allows existing items to be updated in the database table
        private async void updateButton_Click(object sender, RoutedEventArgs e) //this method does NOT work-- it will show message saying it updated successfully, but upon refresh it does not update the item
        {
            //add code to check to see if the product exists first-- if you write anything, whether it is accurate to existing items or not, it will say it was updated successfully.
            try
            {
                Product product = new Product();
                product.productID = int.Parse(productID.Text);
                product.productName = productName.Text;
                product.price = float.Parse(price.Text);
                product.kgInventory = int.Parse(amountKG.Text);

                HttpResponseMessage response = await client.PutAsJsonAsync<Product> ("Product/UpdateProd/"+ product.productID, product);
                
                MessageBox.Show("Updated product successfully in the database.");

                refreshDataButton_Click(sender, e); //this auto clicks the refresh button at the end of the operation so the user doesnt have to manually press it
            }
            catch
            {
                MessageBox.Show("Update operation failed.");
            }
        }

        //DELETE
        //this allows deleting existing items in the database table
        private async void deleteButton_Click(object sender, RoutedEventArgs e) //this method seems to work well
        {
            //add code to check to see if the product exists first-- if you write anything in productID, whether it exists already or not, it will say it was deleted successfully.
            try
            {
                var product = new Product()
                {
                    productID = int.Parse(productID.Text)
                };

                var response = await client.DeleteAsync("Product/DeleteProd/" + product.productID);
                MessageBox.Show("Deleted product from database.");

                refreshDataButton_Click(sender, e); //this auto clicks the refresh button at the end of the operation so the user doesnt have to manually press it
            }
            catch
            {
                MessageBox.Show("Delete operation failed.");
            }
        }

        private void goToSales_Click(object sender, RoutedEventArgs e)
        {
            Sales sales = new Sales();
            this.Visibility = Visibility.Hidden;
            sales.Show();
        }
    }
}
