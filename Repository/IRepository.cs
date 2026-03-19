// using System.Collections.Generic;

// namespace MyApi.Repository
// {
//     public interface IRepository<T>
//     {
//         List<T> GetAll();
//         T GetById(int id);
//         void Add(T item);
//         void Delete(int id);
//         void Update(int id, T item);
//     }
// }
using MyApi.Models;

namespace MyApi.Repository
{
    public interface IRepository
    {
        // PRODUCT METHODS
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product item);
        void Update(int id, Product item);
        void Delete(int id);
        // ORDER METHODS
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
        void UpdateOrder(int id, Order order);
        void DeleteOrder(int id);
    }
}