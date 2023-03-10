using A2RESTAPI.Models;
using Assignment2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    
    public partial class Sales : Window
    {
        SqlConnection con;
        HttpClient client = new HttpClient();
        public string[] operations { get; set; }
        public Sales()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:7295/api/"); //this is the base path for me that got auto-generated-- the port number may be different for you
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void connectCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-5DGA5O7\\SQLEXPRESS;Initial Catalog=DesptopAppDevAssignment1;Integrated Security=True;MultipleActiveResultSets=True"; //change this to your connection string!
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
        private void refreshDataButton_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                this.RefreshCart();
                this.ViewCartTotal();
            }
            catch
            {
                MessageBox.Show("Could not refresh inventory.");
            }
        }
        private async void RefreshCart() //this method works
        {

            var response = await client.GetStringAsync("Cart/GetAllCart/");
            var cart = JsonConvert.DeserializeObject<Response>(response).listCart; 

            cartGrid.ItemsSource = cart; 

        }
        private async void ViewCartTotal() 
        {

            var response = await client.GetStringAsync("Cart/ViewCartTotal/");
            var cartTotal = JsonConvert.DeserializeObject<Response>(response).finalPrice;
            
            totalSales.Text = cartTotal.ToString();

        }

        private void goBackToAdmin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow admin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            admin.Show();
        }

        private async void OkToPay_Click(object sender, RoutedEventArgs e)
        {
            var response = await client.DeleteAsync("Cart/PayAndClearCart/");

            MessageBox.Show("Payment Success");

            refreshDataButton_Click(sender, e);
        }
    }
}
