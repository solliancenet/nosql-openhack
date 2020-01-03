using Contoso.Apps.Movies.Data;
using Contoso.Apps.Movies.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Apps.Common
{
    public class SqlDbHelper
    {
        readonly StoreDbContext _dbContext;

        public SqlDbHelper()
        {
            _dbContext = new StoreDbContext();
        }
        
        public List<Item> GetMoviesByType(int id)
        {
            return _dbContext.Items.Where(c => c.CategoryId == id).ToList();
        }

        public List<Item> GetRandomMovies(int skip, int count)
        {
            if(count == 0)
            {
                count = 1;
            }
            return _dbContext.Items.OrderBy(a => a.ItemId).Skip(skip).Take(count).ToList();
        }
        //public static int SaveOrder(Order myOrder)
        //{
        //    Order order = _dbContext.Orders.FirstOrDefault(a => a.OrderId == myOrder.OrderId);
        //    if (order == null)
        //    {
        //        _dbContext.Orders.Add(myOrder);
        //        _dbContext.Entry(myOrder).State = EntityState.Added;
        //    }
        //    else
        //    {
        //        order.PaymentTransactionId = myOrder.PaymentTransactionId;
        //        _dbContext.Entry(myOrder).State = EntityState.Modified;
        //    }

        //    _dbContext.SaveChanges();
        //    return myOrder.OrderId;
        //}
        
        //public static int SaveOrderDetails(OrderDetail myOrderDetail)
        //{
        //    _dbContext.OrderDetails.Add(myOrderDetail);
        //    _dbContext.Entry(myOrderDetail).State = EntityState.Added;
        //    return _dbContext.SaveChanges();
        //}
    }
}