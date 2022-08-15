using AutoMapper;
using CsvHelper;
using System.Globalization;
using VeraStartTest.Data.Db;
using VeraStartTest.Data.Entities;
using VeraStartTest.Models;

namespace VeraStartTest.Services
{
    public class FileUploadService : IFileUploadService
    {
        private ApplicationDbContext _ctx;
        private Mapper _mapper;

        public FileUploadService(ApplicationDbContext ctx)
        {
            _ctx = ctx;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerDto, Customer>();
                cfg.CreateMap<OrderItem, OrderItemDto>();
                cfg.CreateMap<OrderItemDto, OrderItem>();
                cfg.CreateMap<Order, OrderDto>();
                cfg.CreateMap<OrderDto, Order>();
            }
            );

            _mapper = new Mapper(config);
        }

        public void UploadCustomerFile(IFormFile file)
        {
            List<Customer> customerList;
            using (var stream = file.OpenReadStream())
            using (StreamReader sr = new StreamReader(stream))
            using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {

                var cList = csv.GetRecords<CustomerDto>().ToList();
                customerList = _mapper.Map<List<CustomerDto>, List<Customer>>(cList);

            }

            if (!_ctx.Customers.Any())
            {
                _ctx.AddRange(customerList);
                _ctx.SaveChanges();
            }

            var missingRecords = customerList.Where(x => !_ctx.Customers.Any(z => z.CustomerId == x.CustomerId)).ToList();
            if (missingRecords.Any())
            {
                _ctx.Customers.AddRange(missingRecords);
                _ctx.SaveChanges();
            }


        }

        public void UploadOrderFile(IFormFile file)
        {
            List<Order> orderList;
            using (var stream = file.OpenReadStream())
            using (StreamReader sr = new StreamReader(stream))
            using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {

                var oList = csv.GetRecords<OrderDto>().ToList();
                orderList = _mapper.Map<List<OrderDto>, List<Order>>(oList);

            }


            if (!_ctx.Orders.Any())
            {
                foreach (var order in orderList)
                {
                    _ctx.Orders.Add(new Order
                    {
                        CustomerId = order.CustomerId,
                        OrderId = order.OrderId,
                        OrderDate = order.OrderDate,
                        OrderStatus = order.OrderStatus,
                        RequiredDate=order.RequiredDate,
                        ShippedDate = order.ShippedDate
                    });

                    _ctx.SaveChanges();
                }
           
            }

            var missingRecords = orderList.Where(x => !_ctx.Orders.Any(z => z.OrderId == x.OrderId)).ToList();
            if (missingRecords.Any())
            {
                foreach (var order in missingRecords)
                {
                    _ctx.Orders.Add(order);
                    _ctx.SaveChanges();
                }

            }
        }

        public void UploadOrderItemFile(IFormFile file)
        {
            List<OrderItemDto> orderItemList = new List<OrderItemDto>();
            using (var stream = file.OpenReadStream())
            using (StreamReader sr = new StreamReader(stream))
            using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {

                orderItemList = csv.GetRecords<OrderItemDto>().ToList();

            }
            if (!_ctx.Orders.Any())
            {
                foreach (var o in orderItemList)
                {

                    _ctx.OrderItems.Add(new OrderItem
                    {
                        OrderId = o.OrderId,
                        ItemId = o.ItemId,
                        Discount = o.Discount,
                        ListPrice = o.ListPrice
                    });

                    _ctx.SaveChanges();
                }
            }

            var missingRecords = orderItemList.Where(x => !_ctx.OrderItems.Any(z => z.OrderId == x.OrderId)).ToList();
            if (missingRecords.Any())
            {
                foreach (var o in missingRecords)
                {

                    _ctx.OrderItems.Add(new OrderItem
                    {
                        OrderId = o.OrderId,
                        ItemId = o.ItemId,
                        Discount = o.Discount,
                        ListPrice = o.ListPrice
                    });

                    _ctx.SaveChanges();
                }

            }


        }
    }
}
