namespace A2RESTAPI.Models
{
    public class Cart
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public float price { get; set; }
        public int kgCart { get; set; }
        public float LineTotal { get; set; }
    }
}
