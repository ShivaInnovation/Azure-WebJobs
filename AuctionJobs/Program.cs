using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.Azure.WebJobs;

namespace AuctionJobs
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        public static void Main()
        {
            while (true)
            {
                Functions.NotifyOfExpiringAuction(Console.Out);
            }
        }

        private static async Task SetupSignalRClient()
        {
            var connection = new HubConnection("http://localhost/");
            Functions.auctionHubClient = connection.CreateHubProxy("auctionHub");
            try
            {
                await connection.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           

        }
    }
}
