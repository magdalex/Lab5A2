using Lab5Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Lab5Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController
    {
        private readonly IConfiguration configuration1; // receive the connection state with sql server
        public ProductController(IConfiguration configuration2)
        {
            configuration1 = configuration2;
        }

        //SELECT ALL
        [HttpGet]
        [Route("GetAllProd")]
        public Response GetAllProd()
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("ProductCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetAllProducts(con);
            return response;
        }

        //SELECT BY ID
        [HttpGet]
        [Route("GetAllProdByID/{id}")]
        public Response GetAllProdByID(int id)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("productCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetAllProductByID(con, id);
            return response;
        }

        //INSERT
        [HttpPost]
        [Route("InsertProd")]
        public Response InsertProd(Product product)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("productCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.InsertProduct(con, product);
            return response;
        }

        //UPDATE
        [HttpPut]
        [Route("UpdateProd")]
        public Response UpdateProd(Product product)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("productCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.UpdateProduct(con, product);
            return response;
        }

        //DELETE
        [HttpDelete]
        [Route("DeleteProd/{id}")]
        public Response DeleteProd(int id)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("productCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.DeleteProduct(con, id);
            return response;
        }
    }
}
