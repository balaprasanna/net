﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using jsreport.Client;

namespace jsreport.Embedded.Test
{

    public class Program
    {
        public static void Main()
        {
            var embededReportingServer = new EmbeddedReportingServer();
            embededReportingServer.StartAsync().Wait();

            var reportingService = new ReportingService(embededReportingServer.EmbeddedServerUri);
            reportingService.SynchronizeTemplatesAsync().Wait();
            Thread.Sleep(15000);

            var rs = new ReportingService("http://localhost:2000");
            var r = rs.GetServerVersionAsync().Result;

           
            var result = rs.RenderAsync("Report1", null).Result;
            
            Console.WriteLine("Done");
            embededReportingServer.StopAsync().Wait();
        }
    }
}
