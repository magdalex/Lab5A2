using A2RESTAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using Application = A2RESTAPI.Models.Application;

namespace A2RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly IConfiguration configuration1; // receive the connection state with sql server
        public CartController(IConfiguration configuration2)
        {
            configuration1 = configuration2;
        }
        //View cart ALL
        [HttpGet]
        [Route("GetAllCart")]
        public Response GetAllCart()
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("ProductCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.ViewAllCart(con);
            return response;
        }
        
        //View cart ALL
        [HttpGet]
        [Route("ViewCartTotal")]
        public Response ViewCartTotal()
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("ProductCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.ViewCartTotal(con);
            return response;
        }
        
        //INSERT
        [HttpPost]
        [Route("AddToCart")]
        public Response AddToCart(Cart cart)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("productCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.AddToCart(con, cart);
            return response;
        }

        //Clear Cart
        [HttpDelete]
        [Route("PayAndClearCart")]
        public Response PayAndClearCart()
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("productCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.PayAndClearCart(con);
            return response;
        }
    }
}
