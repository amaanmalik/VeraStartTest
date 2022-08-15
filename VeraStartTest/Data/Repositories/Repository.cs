using Microsoft.EntityFrameworkCore;
using VeraStartTest.Data.Db;
using VeraStartTest.Data.Entities;
using VeraStartTest.Models.ViewModels;

namespace VeraStartTest.Data.Repositories
{
    public class Repository : IRepository
    {
        private ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Customer GetCustomer(int customerid)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDisplayViewModel> GetCustomers()
        {
            //using (_context)
            {
                List<Customer> customers = new List<Customer>();
                customers = _context.Customers.AsNoTracking()
                    .ToList();

                if (customers != null)
                {
                    List<CustomerDisplayViewModel> customersDisplay = new List<CustomerDisplayViewModel>();
                    foreach (var x in customers)
                    {
                        var customerDisplay = new CustomerDisplayViewModel()
                        {
                            CustomerID = x.CustomerId.Value,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            Email = x.Email,
                            City = x.City,
                            Phone = x.Phone,
                            State = x.State,
                            Street = x.Street,
                            ZipCode = x.ZipCode
                        };
                        customersDisplay.Add(customerDisplay);
                    }
                    return customersDisplay;
                }
                return null;
            }
        }

        public CustomerOrdersListViewModel GetCustomerOrdersDisplay(int customerid)
        {
            var customer = _context.Customers.AsNoTracking()
                       .Where(x => x.CustomerId == customerid)
                       .Single();

            if (customer != null)
            {
                var customerOrdersListVm = new CustomerOrdersListViewModel()
                {
                    CustomerID = customer.CustomerId.Value,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                };

                List<OrderDisplayViewModel> orderList = _context.Orders.AsNoTracking()
                    .Where(x => x.CustomerId == customerid)
                    .Select(x =>
                   new OrderDisplayViewModel
                   {
                       CustomerID = x.CustomerId.Value,
                       OrderID = x.OrderId.Value,
                       OrderDate = x.OrderDate,
                       Total = _context.OrderItems.Where(o => o.OrderId == x.OrderId).Sum(o => o.ListPrice),
                       Items = _context.OrderItems.Where(o => o.OrderId == x.OrderId).ToList()

                   }).ToList();
                customerOrdersListVm.Orders = orderList;
                return customerOrdersListVm;
            }



            return null;
        }

        public List<OrderDiscountListModel> GetCustomerDiscountedOrderByState(string state, double percentage)
        {
            //testvm testvm = new testvm();
            //var customers = _customerRepository.GetCustomers();

            var list = (from T1 in _context.Customers
                        join T2 in _context.Orders on T1.CustomerId equals T2.CustomerId
                        join T3 in _context.OrderItems on T2.OrderId equals T3.OrderId
                        where T1.State == state
                        group T3 by new { T1.CustomerId, T1.FirstName, T1.LastName, T1.State, T2.OrderId, T2.OrderDate } into g
                        select new OrderDiscountListModel
                        {
                            CustomerID = g.Key.CustomerId.Value,
                            FirstName = g.Key.FirstName,
                            LastName = g.Key.LastName,
                            State = g.Key.State,
                            OrderID = g.Key.OrderId.Value,
                            Total = g.Sum(t => t.ListPrice),
                            DiscountPercentage = percentage


                        }).ToList();

            foreach ( var order in list)
            {
                order.DiscountedTotal = ApplyDiscount(order.Total, percentage);
            }
            return list;
        }

        private decimal ApplyDiscount(decimal value, double percentage)
        {
            var discountedValue = value * (Convert.ToDecimal(percentage)/100);
            return value - discountedValue;

        }
    }
}
