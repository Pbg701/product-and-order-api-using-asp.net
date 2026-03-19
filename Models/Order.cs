namespace MyApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public double TotalAmount { get; set; }
    }
}