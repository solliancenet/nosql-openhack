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
        public static List<Item> GetViaFunction(string algo, int userId, int contentId)
        {
            try
            {
                return GetViaFunction(algo, userId, contentId, 10);
            }
            catch (Exception ex)
            {
                return new List<Item>();
            }
        }

        public static List<Item> GetViaFunction(string algo, int userId, int contentId, int take)
        {
            List<Item> items = new List<Item>();

            items = RecommendationHelper.Get(algo, userId, contentId, take);

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

        public static List<Item> Get(string algo, int userId, int contentId, int take)
        {
            List<Item> items = new List<Item>();

            switch (algo)
            {
                case "assoc":
                    items = RecommendationHelper.AssociationRecommendationByUser(userId, take);
                    break;
                case "top":
                    items = RecommendationHelper.TopRecommendation(userId, take);
                    break;
                case "random":
                    items = GetRandom(take);
                    break;
                case "collab":
                    List<int?> precRecs2 = RecommendationHelper.CollaborativeBasedRecommendation(userId, take);

                    if (precRecs2.Count > 0)
                        items = GetItemsByImdbIds(precRecs2);

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

        public static List<Item> AssociationRecommendationByUser(int userId, int take)
        {
            List<Item> items = new List<Item>();

            List<int?> itemIds = new List<int?>();

            //get 20 log events for the user.
            List<CollectorLog> logs = GetUserLogs(userId, 20);

            if (logs.Count == 0)
                return items;

            List<Rule> rules = GetSeededRules(logs);

            //get the pre-seeded objects based on confidence
            List<Recommendation> recs = new List<Recommendation>();

            //for each rule returned, evaluate the confidence
            foreach (Rule r in rules)
            {
                Recommendation rec = new Recommendation();
                rec.id = r.target;
                rec.confidence = r.confidence;
                recs.Add(rec);

                itemIds.Add(rec.id);
            }

            items = GetItemsByImdbIds(itemIds);

            //return the "take" number of records
            return items.Take(take).ToList();
        }

        private static List<Rule> GetSeededRules(List<CollectorLog> logs)
        {
            List<Rule> rules = new List<Rule>();
            List<int?> strKeys1 = new List<int?>();

            foreach (CollectorLog cl in logs)
            {
                strKeys1.Add(cl.ContentId);
            }

            try
            {
                var query = SqlDbHelper.GetAssociationsByContentIds(strKeys1);

                rules = query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rules;
        }

        private static List<CollectorLog> GetUserLogs(int userId, int take)
        {
            var query = SqlDbHelper.GetEventsByUser(userId);

            if (take > 0)
                return query.Take(take).ToList();
            else
                return query.ToList();
        }

        //aka NeighborhoodBasedRecs
        public static List<int?> CollaborativeBasedRecommendation(int userId, int take)
        {
            List<int?> itemIds = new List<int?>();

            //TODO 3 - replace the following lines
            int neighborhoodSize = 15;
            double minSim = 0.0;
            int maxCandidates = 100;

            //inside this we do the implict rating of events for the user...
            Hashtable userRatedItems = GetRatedItems(userId, 100);

            if (userRatedItems.Count == 0)
                return new List<int?>();

            //this is the mean rating a user gave
            double ratingSum = 0;

            foreach (double r in userRatedItems.Values)
            {
                ratingSum += r;
            }

            double userMean = ratingSum / userRatedItems.Count;

            //get similar items
            List<SimilarItem> candidateItems = GetCandidateItems(userRatedItems.Keys, minSim);

            //sort by similarity desc, take only max candidates
            candidateItems = candidateItems.OrderByDescending(c => c.similarity).Take(maxCandidates).ToList();

            Hashtable recs = new Hashtable();

            List<PredictionModel> precRecs = new List<PredictionModel>();

            foreach (SimilarItem candidate in candidateItems)
            {
                int target = candidate.Target;
                double pre = 0;
                double simSum = 0;

                List<SimilarItem> ratedItems = candidateItems.Where(c => c.Target == target).Take(neighborhoodSize).ToList();

                if (ratedItems.Count > 1)
                {
                    foreach (SimilarItem simItem in ratedItems)
                    {
                        try
                        {
                            string source = userRatedItems[simItem.sourceItemId].ToString();

                            //rating of the movie - userMean;
                            double r = double.Parse(source) - userMean;

                            pre += simItem.similarity * r;
                            simSum += simItem.similarity;

                            if (simSum > 0)
                            {
                                PredictionModel p = new PredictionModel();
                                p.Prediction = userMean + pre / simSum;
                                p.Items = ratedItems;
                                precRecs.Add(p);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }

            //sort based on the prediction, only take x of them
            List<PredictionModel> sortedItems = precRecs.OrderByDescending(c => c.Prediction).Take(take).ToList();

            //get first model's items...
            foreach (PredictionModel pm in sortedItems)
            {
                foreach (SimilarItem ri in pm.Items)
                {
                    if (ri.targetItemId != null)
                    {
                        itemIds.Add(ri.targetItemId);
                        break;
                    }
                }
            }



            return itemIds;
        }

        private static List<SimilarItem> GetCandidateItems(ICollection keys1, double minSim)
        {
            List<SimilarItem> items = new List<SimilarItem>();

            List<int?> strKeys1 = new List<int?>();

            foreach (object key in keys1)
                strKeys1.Add(Convert.ToInt32(key));

            try
            {
                var query = SqlDbHelper.GetSimilarItems(strKeys1,minSim);

                items = query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return items;
        }

        private static Hashtable GetRatedItems(int userId, int take)
        {
            Hashtable ht = new Hashtable();

            //get from ratings collection (offline)
            List<ItemRating> ratedItems = GetUserRanking(userId, take);

            foreach (ItemRating ir in ratedItems)
            {
                if (!ht.ContainsKey(ir.ItemId))
                    ht.Add(ir.ItemId, ir.Rating);
            }

            return ht;

        }

        private static List<ItemRating> GetUserRanking(int userId, int take)
        {
            List<ItemRating> items = new List<ItemRating>();

            try
            {
                items = SqlDbHelper.GetRatings(userId, take).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return items;
        }
        
        private static List<Item> GetItemsByImdbIds(List<int?> itemIds)
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

            foreach (Item i in items)
            {
                if (!itemIds.Contains(i.ItemId))
                    itemIds.Add(i.ItemId);
            }

            topItems = GetItemsByImdbIds(itemIds);

            return topItems;
        }
    }
}
