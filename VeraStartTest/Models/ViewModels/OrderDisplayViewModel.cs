using VeraStartTest.Data.Entities;

namespace VeraStartTest.Models.ViewModels
{
    public class OrderDisplayViewModel
    {
        public int CustomerID { get; set; }


        public int OrderID { get; set; }


        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }

        public double totalorders { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
