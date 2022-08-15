using CsvHelper.Configuration.Attributes;

namespace VeraStartTest.Models
{
    public class OrderDto
    {
        [Name("order_id")]
        public int OrderId { get; set; }
        [Name("customer_id")]
        public int CustomerId { get; set; }
        [Name("order_status")]
        public int OrderStatus { get; set; }
        [Name("order_date")]
        public string OrderDate { get; set; }
        [Name("required_date")]
        public string RequiredDate { get; set; }
        [Name("shipped_date")]
        public string ShippedDate { get; set; }
    }
}
