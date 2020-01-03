using Contoso.Apps.Common;
using Contoso.Apps.Movies.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DataGenerator
{
    public class UserActor
    {
        private readonly SqlDbHelper sqlDbHelper;
        public readonly List<EventHubElement> EventHubs;
        private readonly Random r;

        public UserActor()
        {
            this.sqlDbHelper = new SqlDbHelper();
            this.EventHubs = GetEventHubsConfiguration();
            this.r = new Random();
        }

        public async void DoWork()
        {
            try
            {
                int loop = 1;
                var eventHubs = EventHubs;
                EventHubElement eventHub = eventHubs.First();
                //loop...
                while (true)
                {
                    //Thread.Sleep(50);
                    if (eventHubs.Count > 1)
                    {
                        if ((loop % 2 == 0))
                        {
                            eventHub = eventHubs[1];
                        }
                        else
                        {
                            eventHub = eventHubs.First();
                        }
                    }

                    GenerateAction(eventHub);

                    loop++;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                Console.ReadLine();
            }
        }

        private List<EventHubElement> GetEventHubsConfiguration()
        {
            var eventHubs = new List<EventHubElement>();
            if (!string.IsNullOrEmpty(AppSettings.Configuration["EVENT_HUB_1_CONNECTION_STRING"]))
            {
                eventHubs.Add(new EventHubElement { ConnectionString = AppSettings.Configuration["EVENT_HUB_1_CONNECTION_STRING"], Region = "Region1" });
            }

            if (!string.IsNullOrEmpty(AppSettings.Configuration["EVENT_HUB_2_CONNECTION_STRING"]))
            {
                eventHubs.Add(new EventHubElement { ConnectionString = AppSettings.Configuration["EVENT_HUB_2_CONNECTION_STRING"], Region = "Region2" });
            }

            return eventHubs;
        }

        private void GenerateAction(EventHubElement eventHub)
        {
            // Event hub client
            var eventHubHelper = new EventHubHelper(eventHub.EventHubName, eventHub.ConnectionString);

            // Send order to event hub
            var order = GenerateOrder(eventHub.Region);
            Console.WriteLine($"Sending order message to {eventHub.Region}");
            eventHubHelper.SendMessageToEventHub(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(order))).GetAwaiter().GetResult();

            // Close connection
            eventHubHelper.CloseEventHub().GetAwaiter().GetResult();
        }

        private Order GenerateOrder(string region)
        {
            var user = GetRandomUser();
            // Get Random User
            Console.WriteLine($"{user.UserId} performed order");

            var order = new Order
            {
                Region = region,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                FirstName = user.FirstName,
                HasBeenShipped = false,
                LastName = user.LastName,
                OrderDate = DateTime.UtcNow,
                PaymentTransactionId = "",
                Phone = user.Phone,
                PostalCode = user.PostalCode,
                ReceiptUrl = "",
                SMSOptIn = false,
                SMSStatus = "",
                State = user.State
            };

            int skip = GetRandomValue(10);
            int count = GetRandomValue(10);
            int quantity = GetRandomValue(5);
            if (quantity == 0)
            {
                quantity = 1;
            }

            var items = sqlDbHelper.GetRandomMovies(skip, count);
            order.Total = Math.Round((decimal)(from cartItems in items select (quantity * cartItems.UnitPrice ?? 0)).Sum(), 2);
            //order.OrderId = SqlDbHelper.SaveOrder(order);

            List<OrderDetail> orderDetails = GetRandomOrderDetails(order, user, items, quantity);
            order.OrderDetails = orderDetails;
            return order;
        }

        private int GetRandomValue(int count)
        {
            Random r = new Random();
            return r.Next(count);
        }

        private List<OrderDetail> GetRandomOrderDetails(Order order, User user, List<Item> items, int quantity)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            // Add OrderDetail information to the DB for each product purchased.
            for (int i = 0; i < items.Count; i++)
            {
                // Create a new OrderDetail object.
                var myOrderDetail = new OrderDetail();
                //myOrderDetail.OrderDetailId = i;
                //myOrderDetail.OrderId = order.OrderId;
                myOrderDetail.ProductId = items[i].ItemId;
                myOrderDetail.Quantity = quantity;
                myOrderDetail.UnitPrice = Math.Round(items[i].UnitPrice ?? 0, 2);
                myOrderDetail.Email = order.Email;
                //// Add OrderDetail to DB.
                //SqlDbHelper.SaveOrderDetails(myOrderDetail);

                orderDetails.Add(myOrderDetail);
            }

            return orderDetails;
        }

        private User GetRandomUser()
        {
            var users = User.GetUsers();
            return users.Skip(r.Next(users.Count)).Take(1).FirstOrDefault();
        }
    }
}
