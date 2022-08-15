namespace VeraStartTest.Models.ViewModels
{
    public class CustomerOrdersListViewModel
    {

        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public List<OrderDisplayViewModel> Orders { get; set; }
    }
}
