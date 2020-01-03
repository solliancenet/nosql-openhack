using Contoso.Apps.Movies.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Contoso.Apps.Common;

namespace DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var userActor = new UserActor();
                var eventHubs = userActor.EventHubs;
                if (eventHubs.Count == 0)
                {
                    throw new Exception("At least one eventhub connection string needs to be added. Please add and try again.");
                }

                DoWork(userActor);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                Console.ReadLine();
            }
            
        }

        static void DoWork(UserActor userActor)
        {
            var t = new Thread(userActor.DoWork);
            t.Start();
        }
    }
}
