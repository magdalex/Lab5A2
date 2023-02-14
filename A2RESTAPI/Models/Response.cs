namespace A2RESTAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public Product product { get; set; }
        public List<Product> listProduct { get; set; }
    }
}
