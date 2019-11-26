using Contoso.Apps.Movies.Data;
using Contoso.Apps.Movies.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Apps.Common
{
    public class SqlDbHelper
    {
        static StoreDbContext _dbContext = new StoreDbContext();

        #region Item
        public static IQueryable<Item> GetItems()
        {
            return _dbContext.Items;
        }

        public static List<Item> GetMoviesByType(int id)
        {
            return _dbContext.Items.Where(c => c.CategoryId == id).ToList();
        }

        public static async Task<Item> GetItem(int? itemId)
        {
            return _dbContext.Items.FirstOrDefault(a => a.ItemId == itemId);
        }

        public static IQueryable<Item> GetItemsByIds(List<int?> itemIds)
        {
            return _dbContext.Items
                    .Where(c => itemIds.Contains(c.ImdbId))
                    .Distinct();
        }

        public static IQueryable<Item> GetRandomItems(int skip, int count)
        {
            return _dbContext.Items.OrderBy(a => a.ItemId).Skip(skip).Take(count);
        }

        #endregion

        #region Cart Item
        public static List<CartItem> GetCartItems()
        {
            var res = _dbContext.CartItems.ToList();
            return res.Select(a => { a.Product = _dbContext.Items.FirstOrDefault(p => p.ItemId == a.ItemId); return a; }).ToList();
        }

        public async static Task<CartItem> GetCartItem(string cartItemId)
        {
            return _dbContext.CartItems.FirstOrDefault(a => a.CartItemId == cartItemId);
        }

        public async static Task<int> SaveCartItem(CartItem cartItem)
        {
            CartItem _cartItem = null;
            if (!string.IsNullOrWhiteSpace(cartItem.CartItemId))
            {
                _cartItem = _dbContext.CartItems.FirstOrDefault(a => a.CartItemId == cartItem.CartItemId);
            }

            if (_cartItem == null)
            {
                _dbContext.CartItems.Add(cartItem);
            }

            return await _dbContext.SaveChangesAsync();
        }

        public async static Task<int> CreateEvent(CollectorLog log)
        {
            _dbContext.Events.Add(log);
            return await _dbContext.SaveChangesAsync();
        }

        public async static Task DeleteCartItem(string cartItemId)
        {
            CartItem ci = await SqlDbHelper.GetCartItem(cartItemId);
            _dbContext.CartItems.Remove(ci);
            await _dbContext.SaveChangesAsync();
        }

        public static IQueryable<Item> GetItemsByCategory(int categoryId)
        {
            return _dbContext.Items.Where(a => a.CategoryId == categoryId);
        }

        #endregion

        #region User
        public static IQueryable<User> GetUsers()
        {
            return _dbContext.Users;
        }


        public async static Task<User> GetUser(int userId)
        {
            return _dbContext.Users.First(a => a.UserId == userId);
        }

        #endregion

        #region Category
        public static IQueryable<Category> GetCategories()
        {
            return _dbContext.Categories;
        }

        internal async static Task<Category> GetCategory(int id)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        #endregion

        #region Order

        public async static Task<int> SaveOrder(Order myOrder)
        {
            Order order = _dbContext.Orders.FirstOrDefault(a => a.OrderId == myOrder.OrderId);
            if (order == null)
            {
                _dbContext.Orders.Add(myOrder);
                _dbContext.Entry(myOrder).State = EntityState.Added;
            }
            else
            {
                order.PaymentTransactionId = myOrder.PaymentTransactionId;
                _dbContext.Entry(myOrder).State = EntityState.Modified;
            }

            return await _dbContext.SaveChangesAsync();
        }

        public async static Task<int> SaveOrderDetails(OrderDetail myOrderDetail)
        {
            _dbContext.OrderDetails.Add(myOrderDetail);
            return await _dbContext.SaveChangesAsync();
        }

        public async static Task<Order> GetOrder(int currentOrderId)
        {
            return _dbContext.Orders.FirstOrDefault(a => a.OrderId == currentOrderId);
        }
        #endregion

        #region Event
        public static List<CollectorLog> GetUserLogs(int userId, int take)
        {
            return _dbContext.Events.Where(a => a.UserId == userId).OrderByDescending(a => a.Created).Take(take).ToList();
        }

        public static IQueryable<CollectorLog> GetEventsByUser(int userId)
        {
            return _dbContext.Events.Where(a => a.UserId == userId);
        }

        #endregion

        #region Others
        public static IQueryable<ItemRating> GetRatings(int userId, int take)
        {
            return _dbContext.ItemRatings.Where(a => a.UserId == userId).Take(take);
        }

        public static IQueryable<ItemAggregate> GetItemAggregates(int take)
        {
            return _dbContext.ItemAggregates.OrderByDescending(c => c.BuyCount).Take(take);
        }

        public static IQueryable<Rule> GetAssociationsByContentIds(List<int?> strKeys1)
        {
            return _dbContext.Associations.Where(c => strKeys1.Contains(c.source) && !strKeys1.Contains(c.target))
                    .OrderByDescending(c => c.confidence);
        }

        public static IQueryable<SimilarItem> GetSimilarItems(List<int?> strKeys1, double minSim)
        {
            return _dbContext.Similarity.Where(c => strKeys1.Contains(c.sourceItemId) && !strKeys1.Contains(c.targetItemId) && c.similarity > minSim);
        }

        #endregion
    }
}