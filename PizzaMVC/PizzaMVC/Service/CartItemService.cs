using Microsoft.AspNetCore.Http;
using PizzaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMVC.Service
{
    public class CartItemServise
    {
        public async Task<IEnumerable<CartItem>> Get(int? orderId, string token)
        {
            var cartItems = new List<CartItem>();
            var orderItems = await new OrderItemService().GetByOrderId((int)orderId, token);

            foreach (var item in orderItems)
            {
                List<ToppingDTO> toppings = new();
                var orderItemDetails = await new OrderItemDetailsService().Get(item.Id, token);
                foreach (var item1 in orderItemDetails)
                {
                    toppings.Add(await new ToppingService().Get(item1.ToppingId, token));
                }
                cartItems.Add(new CartItem() { Pizza = await new PizzaService().Get((int)item.PizzaId, token), Toppings = toppings, OrderDetailsId = item.Id });
            }
            return cartItems;
        }

        public async Task<double?> GetTotalSum(int orderId, string token)
        {
            var orderService = new OrderService();
            var order = await orderService.Get(orderId, token);

            var items = await this.Get(orderId, token);
            double? sum = 0;
            foreach (var item in items)
            {
                sum += item.Pizza.Price;
                foreach (var item1 in item.Toppings)
                {
                    sum += item1.Price;
                }
            }
            order.Total = sum;
            if (sum < 50)
            {
                order.DeliveryCharge = 5;
            }
            else
            {
                order.DeliveryCharge = 0;
            }

            await orderService.Edit(order, token);
            return sum;
        }

        //public void DeleteOrder()
        //{
        //    var order = _dbSet.Where(o => o.Id == _orderId)
        //        .Include(o => o.OrderDetails)
        //        .ThenInclude(o => o.OrderItemDetails).FirstOrDefault();
        //    _dbSet.Remove(order);
        //    _context.SaveChanges();
        //}

        public async Task DeleteItem(int orderItemId, string token)
        {
            await new OrderItemService().Delete(orderItemId, token);
            await new OrderItemDetailsService().Delete(orderItemId, token);
        }
    }
}
