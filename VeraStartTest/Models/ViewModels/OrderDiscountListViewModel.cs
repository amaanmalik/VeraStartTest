namespace VeraStartTest.Models.ViewModels
{
    public class OrderDiscountListModel
    {
        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string State { get; set; }

        public int OrderID { get; set; }

        public decimal Total { get; set; }

        public double DiscountPercentage { get; set; }

        public decimal DiscountedTotal { get; set; }

    }
}
