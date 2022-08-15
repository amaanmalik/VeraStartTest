using VeraStartTest.Data.Entities;
using VeraStartTest.Models.ViewModels;

namespace VeraStartTest.Data.Repositories
{
    public interface IRepository
    {
        List<CustomerDisplayViewModel> GetCustomers();
        Customer GetCustomer(int customerid);

        CustomerOrdersListViewModel GetCustomerOrdersDisplay(int customerid);

        List<OrderDiscountListModel> GetCustomerDiscountedOrderByState(string state, double percentage);
    }
}
