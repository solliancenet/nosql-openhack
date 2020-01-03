using Microsoft.Azure.EventHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Apps.Common
{
    public class EventHubHelper
    {
        EventHubClient eventHubClient;
        public EventHubHelper(string eventHubName, string eventHubConnectionString)
        {
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(eventHubConnectionString)
            {
                //EntityPath = eventHubName
            };

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

        }
        public async Task SendMessageToEventHub(byte[] message)
        {
            await eventHubClient.SendAsync(new EventData(message));
            //await eventHubClient.CloseAsync();
        }

        public async Task CloseEventHub()
        {
            await eventHubClient.CloseAsync();
        }
    }
}
