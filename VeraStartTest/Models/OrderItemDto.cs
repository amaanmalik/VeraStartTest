using CsvHelper.Configuration.Attributes;

namespace VeraStartTest.Models
{
    public class OrderItemDto
    {
        [Name("order_id")]
        public int OrderId { get; set; }

        [Name("item_id")]
        public int ItemId { get; set; }

        [Name("list_price")]
        public decimal ListPrice { get; set; }

        [Name("discount")]
        public decimal Discount { get; set; }

    }
}
