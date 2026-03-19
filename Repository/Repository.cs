// // using System.Collections.Generic;
// // using System.Linq;
// // using MyApi.Data;
// // using MyApi.Models;
// // using Microsoft.EntityFrameworkCore;
// // namespace MyApi.Repository
// // {
// //     public class Repository<T> : IRepository<T> where T : class
// //     {
// //         //private readonly List<T> _items = new List<T>();
// //         private readonly AppDbContext _context;

// //         public Repository(AppDbContext context)
// //         {
// //             _context = context;
// //         }
// //         //public List<T> GetAll() => _items;
// //         public List<Product> GetAll()
// //         {
// //             return _context.Products.ToList();
// //         }
// //         public T GetById(int id)
// //         {
// //             return _items.FirstOrDefault(x =>
// //                 (int)x.GetType().GetProperty("Id").GetValue(x) == id);
// //         }

// //         public void Add(T item) => _items.Add(item);
// //         public void Update(int id, T item)
// //         {
// //             var existingItem = GetById(id);
// //             if (existingItem != null)
// //             {
// //                 _items.Remove(existingItem);
// //                 _items.Add(item);
// //             }
// //         }

// //         public void Delete(int id)
// //         {
// //             var item = GetById(id);
// //             if (item != null)
// //                 _items.Remove(item);
// //         }
// //     }
// // }
// using MyApi.Data;
// using MyApi.Models;

// namespace MyApi.Repository
// {
//     public class Repository : IRepository
//     {
//         private readonly AppDbContext _context;

//         public Repository(AppDbContext context)
//         {
//             _context = context;
//         }

//         public List<Product> GetAll()
//         {
//             return _context.Products.ToList();
//         }

//         public Product GetById(int id)
//         {
//             return _context.Products.FirstOrDefault(x => x.Id == id);
//         }

//         public void Add(Product item)
//         {
//             _context.Products.Add(item);
//             _context.SaveChanges();
//         }

//         public void Update(int id, Product item)
//         {
//             var existing = _context.Products.Find(id);
//             if (existing != null)
//             {
//                 existing.Name = item.Name;
//                 existing.Price = item.Price;
//                 _context.SaveChanges();
//             }
//         }

//         public void Delete(int id)
//         {
//             var item = _context.Products.Find(id);
//             if (item != null)
//             {
//                 _context.Products.Remove(item);
//                 _context.SaveChanges();
//             }
//         }
//     }
// }
using MyApi.Data;
using MyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public void Update(int id, Product item)
        {
            var existing = _context.Products.Find(id);

            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Price = item.Price;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = _context.Products.Find(id);

            if (item != null)
            {
                _context.Products.Remove(item);
                _context.SaveChanges();
            }
        }
        // GET ALL ORDERS
        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        // GET ORDER BY ID
        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
        }

        // ADD ORDER
        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        // UPDATE ORDER
        public void UpdateOrder(int id, Order order)
        {
            var existing = _context.Orders.Find(id);

            if (existing != null)
            {
                existing.CustomerName = order.CustomerName;
                existing.TotalAmount = order.TotalAmount;
                _context.SaveChanges();
            }
        }

        // DELETE ORDER
        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }

}