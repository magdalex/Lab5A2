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
            client.BaseAddress = new Uri("https://localhost:7281/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            { //Exception handling
                string connectionString = "Data Source=DESKTOP-VMP9DN3;Initial Catalog=Assignment1;Integrated Security=True";
                con = new SqlConnection(connectionString);
                con.Open();
                MessageBox.Show("Connection established properly.");
                con.Close();

                refreshDataButton_Click(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshDataButton_Click(object sender, RoutedEventArgs e) //works well
        {
            this.RefreshProducts();
        }

        private async void RefreshProducts() //works well
        {

            var response = await client.GetStringAsync("Product/GetAllProd");
            var products = JsonConvert.DeserializeObject<Response>(response).listProduct;
           
            dataGrid.ItemsSource = products;
            
        }

        private async void insertButton_Click(object sender, RoutedEventArgs e) //works well
        {

            var product = new Product() {
                productID = int.Parse(productID.Text),
                productName = productName.Text,
                price = float.Parse(price.Text),
                kgInventory = int.Parse(amountKG.Text)
            };

            var response = await client.PostAsJsonAsync("Product/InsertProd", product);
            MessageBox.Show("Inserted product successfully into the database.");
            

            refreshDataButton_Click(sender, e);

        }

        private async void updateButton_Click(object sender, RoutedEventArgs e) //does not work
        {

            var product = new Product()
            {
                productID = int.Parse(productID.Text),
                productName = productName.Text,
                price = float.Parse(price.Text),
                kgInventory = int.Parse(amountKG.Text)
            };

            var response = await client.PutAsJsonAsync("Product/UpdateProd/" + product.productID, product);
            MessageBox.Show("Updated product successfully in the database.");
        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e) //works well
        {

            var product = new Product()
            {
                productID = int.Parse(productID.Text),
            };

            var response = await client.DeleteAsync("Product/DeleteProd/" + product.productID);
            MessageBox.Show("Deleted product from database.");
        }

    }
}
