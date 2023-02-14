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

        //UPDATE
        public Response UpdateProduct(SqlConnection con, Product product)
        {
            Response response = new Response();
            string query = "UPDATE productTable SET product_Name=@product_Name,Price=@Price,KG_Inventory=@KG_Inventory where product_ID=@product_ID";
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
    }
}
