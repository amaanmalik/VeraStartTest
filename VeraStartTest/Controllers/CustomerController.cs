using Microsoft.AspNetCore.Mvc;
using VeraStartTest.Data.Repositories;
using VeraStartTest.Models.ViewModels;

namespace VeraStartTest.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository _repo;

        public CustomerController(IRepository repository)
        {
            _repo = repository;
        }
        public IActionResult Index()
        {
            var customerList = _repo.GetCustomers();
            return View(customerList);
           
        }

        public IActionResult CustomerOrders(int customerId)
        {
            var orders = _repo.GetCustomerOrdersDisplay(customerId);
            return View(orders);
        }

        public IActionResult Discounts()
        {
            var model = new OrderDiscountsListViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Discounts(OrderDiscountsListViewModel model)
        {
            var StateId = model.StateId;

            var list = _repo.GetCustomerDiscountedOrderByState(model.StateId,model.DiscountPercentage);

            model.OrdersList = list;

            return View(model);
        }

        [HttpPost]
        public IActionResult Add()
        {
            try
            {
                int num1 = Convert.ToInt32(HttpContext.Request.Form["Text1"].ToString());
                int num2 = Convert.ToInt32(HttpContext.Request.Form["Text2"].ToString());
                ViewBag.Result = (num1 + num2).ToString();
            }
            catch (Exception)
            {
                ViewBag.Result = "Wrong Input Provided.";
            }
            return View("CalPage");
        }
    }
}
