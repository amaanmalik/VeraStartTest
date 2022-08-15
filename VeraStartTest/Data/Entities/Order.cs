namespace VeraStartTest.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }

        public int? CustomerId { get; set; }

        public int OrderStatus { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public string ShippedDate { get; set; }

    }
}
