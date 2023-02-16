using System.Data;
using System.Data.SqlClient;

namespace A2RESTAPI.Models
{
    public class Application
    {
        //SELECT ALL
        public Response GetAllProducts(SqlConnection con)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from productTable", con);
            DataTable dt = new DataTable();
            List<Product> listProd = new List<Product>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Product product = new Product();
                    product.productID = (int)dt.Rows[i]["Product_ID"];
                    product.productName = (string)dt.Rows[i]["Product_Name"];
                    product.price = float.Parse(dt.Rows[i]["Price"].ToString());
                    product.kgInventory = (int)dt.Rows[i]["KG_Inventory"];

                    listProd.Add(product);
                }
            }

            if (listProd.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Products Retrieve Perfectly";
                response.listProduct = listProd;
            }
            else // Only works if your data table is empty or your connection fails
            {
                response.statusCode = 100;
                response.statusMessage = "No product found";
                response.listProduct = null;
            }

            return response;
        }
        //View all items in Cart 
        public Response ViewAllCart(SqlConnection con)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * ,KG_Cart*Price AS Line_Total from cartTable", con);
            DataTable dt = new DataTable();
            List<Cart> listCart = new List<Cart>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)// Cannot display CartTable with line total properly
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Cart cart = new Cart();
                    cart.productID = (int)dt.Rows[i]["Product_ID"];
                    cart.productName = (string)dt.Rows[i]["Product_Name"];
                    cart.price = float.Parse(dt.Rows[i]["Price"].ToString());
                    cart.kgCart = (int)dt.Rows[i]["KG_Cart"];

                    listCart.Add(cart);
                }
            }

            if (listCart.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Cart Retrieve Perfectly";
                response.listCart = listCart;
            }
            else // Only works if your data table is empty or your connection fails
            {
                response.statusCode = 100;
                response.statusMessage = "No product in cart";
                response.listProduct = null;
            }

            return response;
        }
        /*public Response ViewCartTotal(SqlConnection con) 
        {
            //To be developped
        }*/
        //SELECT BY ID
        public Response GetAllProductByID(SqlConnection con, int productID)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * from productTable Where Product_ID = '" + productID + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Product prod = new Product();
                prod.productID = (int)dt.Rows[0]["Product_ID"];
                prod.productName = (string)dt.Rows[0]["Product_Name"];
                prod.price = float.Parse(dt.Rows[0]["Price"].ToString());
                prod.kgInventory = (int)dt.Rows[0]["KG_Inventory"];
                response.statusCode = 200;
                response.statusMessage = "Product Found";
                response.product = prod;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No Data Found";
                response.listProduct = null;
            }
            return response;
        }

        //INSERT
        public Response InsertProduct(SqlConnection con, Product product)
        {
            Response response = new Response();
            string query = "INSERT INTO productTable(product_ID,product_Name,Price,KG_Inventory) VALUES(@product_ID,@product_Name,@Price,@KG_Inventory)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@product_ID", product.productID);
            cmd.Parameters.AddWithValue("@product_Name", product.productName);
            cmd.Parameters.AddWithValue("@Price", product.price);
            cmd.Parameters.AddWithValue("@KG_Inventory", product.kgInventory);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data insterted properly";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data inserted";
            }
            return response;
        }

        //AddToCart (Insert to cartTable)
        public Response AddToCart(SqlConnection con, Cart cart)
        {
            con.Open();
            Response response = new Response();
            string query = "INSERT INTO cartTable(product_ID,product_Name,Price,KG_Cart) VALUES(@product_ID,@product_Name,@Price,@KG_Cart)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@product_ID", cart.productID);
            cmd.Parameters.AddWithValue("@product_Name", cart.productName);
            cmd.Parameters.AddWithValue("@Price", cart.price);
            cmd.Parameters.AddWithValue("@KG_Cart", cart.kgCart);
            
            /*string sql1 = "select KG_Inventory from productTable where product_ID ="+ cart.productID);
            SqlCommand command1 = new SqlCommand(sql1, con);
            SqlDataReader reader1 = command1.ExecuteReader();
            reader1.Read();
            int kgInventory = (int)Convert.ToInt64(reader1["KG_Inventory"]);
            int kgCart = cart.productID;

            if (kgInventory >= kgCart)
            {
                cmd.ExecuteNonQuery();
            }        
            con.Close();

            con.Open();*/
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Add to cart properly";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No item added to cart";
            }
            return response;
        }

        //UPDATE
        public Response UpdateProduct(SqlConnection con, Product product)
        {
            Response response = new Response();
            string query = "UPDATE productTable SET product_Name=@product_Name,Price=@Price,KG_Inventory=@KG_Inventory where product_ID='"+ product.productID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@product_ID", product.productID);
            cmd.Parameters.AddWithValue("@Product_Name", product.productName);
            cmd.Parameters.AddWithValue("@Price", product.price);
            cmd.Parameters.AddWithValue("@KG_Inventory", product.kgInventory);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data updated properly";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data updated";
            }
            return response;
        }

        //DELETE
        public Response DeleteProduct(SqlConnection con, int productID)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE from productTable Where Product_ID = '" + productID + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Data deleted properly";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data deleted";
            }
            return response;
        }
        //Clear Cart
        public Response PayAndClearCart(SqlConnection con)
        {
            con.Open();
            string sql = "select * from cartTable";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string productID = Convert.ToString(reader["Product_ID"]);
                int kg = (int)Convert.ToInt64(reader["KG_Cart"]);
                string sqlquery1 = "UPDATE productTable SET KG_Inventory = KG_Inventory -" + kg + "where Product_ID =" + productID;
                SqlCommand command1 = new SqlCommand(sqlquery1, con);
                command1.ExecuteNonQuery();
            }
            string sqlquery2 = "DELETE cartTable";
            SqlCommand command2 = new SqlCommand(sqlquery2, con);
            command2.ExecuteNonQuery();            
            
            int i = command2.ExecuteNonQuery();
            con.Close();
            Response response = new Response();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Cart cleared properly";
            }
            else
            {// It can clear the cart and reduce the inventory properly but don't know why it returns fail message 
                response.statusCode = 100;
                response.statusMessage = "Fail to clear cart";
            }
            return response;
        }
    }
}
