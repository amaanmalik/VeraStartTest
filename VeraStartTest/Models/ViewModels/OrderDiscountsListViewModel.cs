namespace VeraStartTest.Models.ViewModels
{
    public class OrderDiscountsListViewModel
    {

        public OrderDiscountsListViewModel()
        {
            StatesList = new List<Itemlist>()
            {
            new Itemlist { Text = "CA", Value = "CA" },
            new Itemlist { Text = "NY", Value = "NY" },
            new Itemlist { Text = "TX", Value = "TX" }
            };
        }
        public string StateId { get; set; }

        public double DiscountPercentage { get; set; }

        public List<Itemlist> StatesList { get; set; } 

        public List<OrderDiscountListModel> OrdersList { get; set; }
    }
}
