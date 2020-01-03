using AutoMapper;
using Contoso.Apps.Common;
using Contoso.Apps.Movies.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Contoso.Apps.Movies.Logic
{
    public class RecommendationHelper
    {
        public static List<Item> GetViaFunction(string algo, int userId)
        {
            try
            {
                return GetViaFunction(algo, userId, 100);
            }
            catch (Exception ex)
            {
                return new List<Item>();
            }
        }

        public static List<Item> GetViaFunction(string algo, int userId, int take)
        {
            List<Item> items = new List<Item>();

            items = RecommendationHelper.Get(algo, userId, take);

            if (items == null)
                return new List<Item>();

            if (items.Count > take)
                items = items.Take<Item>(take).ToList();

            return items;
        }

        public static List<Data.Models.User> GetViaFunction(int userId)
        {
            throw new NotImplementedException();
        }

        public static List<Item> Get(string algo, int userId, int take)
        {
            List<Item> items = new List<Item>();

            switch (algo)
            {
                case "top":
                    items = RecommendationHelper.TopRecommendation(userId, take);
                    break;
                case "random":
                    items = GetRandom(take);
                    break;
            }

            return items;
        }

        public static List<Item> GetRandom(int count)
        {
            Random r = new Random();
            int skip = r.Next(100);

            var items = SqlDbHelper.GetRandomItems(skip, count);

            return items.ToList();
        }

        private static List<CollectorLog> GetUserLogs(int userId, int take)
        {
            var query = SqlDbHelper.GetEventsByUser(userId);

            if (take > 0)
                return query.Take(take).ToList();
            else
                return query.ToList();
        }

        private static List<Item> GetItemsByItemIds(List<int?> itemIds)
        {
            List<Item> items = new List<Item>();

            try
            {
                var query = SqlDbHelper.GetItemsByIds(itemIds);

                items = query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return items;
        }

        private static List<Item> TopRecommendation(int userId, int take)
        {
            List<Item> items = new List<Item>();

            List<Item> topItems = new List<Item>();

            List<int?> itemIds = new List<int?>();

            var query = SqlDbHelper.GetItemAggregates(take);

            var itemsAggregates = query.ToList();
            items = Mapper.Map<List<Item>>(itemsAggregates);

            foreach (var i in items)
            {
                if (!itemIds.Contains(i.ItemId))
                    itemIds.Add(i.ItemId);
            }

            topItems = GetItemsByItemIds(itemIds);

            return topItems;
        }
    }
}
