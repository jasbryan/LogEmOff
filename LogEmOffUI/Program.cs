using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LogEmOff;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Cloud.InstrumentationFramework;
using System.Threading;

namespace LogEmOffUI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            MdmSample();
            HealthSample();
                       
            CreateWebHostBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();
                })
                .Build()
                .Run();
            //EmitMetrics();


            // IFx initialization is a required step for emitting logs
            IfxInitializer.Initialize(
                "cloudAgentTenantIdentity",
                "cloudAgentRoleIdentity",
                "cloudAgentRoleInstanceIdentity");

        }

        static void MdmSample()
        {
            ErrorContext mdmError = new ErrorContext();

            // MeasureMetric usage sample
            MeasureMetric1D testMeasure = MeasureMetric1D.Create(
                    "Fabricator",                                        // MonitoringAccount
                    "Microsoft/Azure/Fabric/Tenant Manager/Management",  // MetricNamespace
                    "HI node count",                                     // MetricName
                    "Cluster",                                           // dimension 1
                    ref mdmError);

            if (testMeasure == null)
            {
                Console.WriteLine("Fail to create MeasureMetric, error code is {0:X}", mdmError.ErrorCode);
                Console.WriteLine("    error message: {0}", mdmError.ErrorMessage);
            }

            if (!testMeasure.LogValue(29, "Ch3PrdDDC03", ref mdmError))
            {
                Console.WriteLine("Fail to set MeasureMetric value, error code is {0:X}", mdmError.ErrorCode);
                Console.WriteLine("    error message: {0}", mdmError.ErrorMessage);
            }

            if (!testMeasure.LogValue(DateTime.UtcNow, 1, "HK2PrdApp03", ref mdmError))
            {
                Console.WriteLine("Fail to set MeasureMetric value, error code is {0:X}", mdmError.ErrorCode);
                Console.WriteLine("    error message: {0}", mdmError.ErrorMessage);
            }

            Thread.Sleep(1000);

            if (!testMeasure.LogValue(DateTime.UtcNow, 3, "HK2PrdApp03", ref mdmError))
            {
                Console.WriteLine("Fail to set MeasureMetric value, error code is {0:X}", mdmError.ErrorCode);
                Console.WriteLine("    error message: {0}", mdmError.ErrorMessage);
            }
        }

        static void HealthSample()
        {
            MetadataCollection resourceIdentityDimensions = new MetadataCollection();
            MetadataCollection resourceMetadataCollection = new MetadataCollection();
            MetadataCollection watchdogMetadataCollection = new MetadataCollection();

            resourceIdentityDimensions.Add("Name", "ABC");

            bool result = IfxHealth.LogWatchdogHealthReport(
                "MonitoringAccount",
                "WatchdogName",
                "ResourceType",
                resourceIdentityDimensions,
                ResourceHealthStatus.Error,
                true,
                DateTime.UtcNow,
                "Message",
                "ArmResourceId",
                "IncarnationId",
                resourceMetadataCollection,
                watchdogMetadataCollection
                );

            if (result)
            {
                Console.WriteLine("Successfully called IfxHealth.LogWatchdogHealthReport.");
            }
            else
            {
                Console.WriteLine("IfxHealth.LogWatchdogHealthReport call failed.");
            }

            MetadataCollection annotationMetadataCollection = new MetadataCollection();

            result = IfxHealth.LogAnnotationHealthReport(
                "MonitoringAccount",
                "Content",
                "WatchdogName",
                "ResourceType",
                resourceIdentityDimensions,
                true,
                DateTime.UtcNow,
                "DisplayName",
                "ArmResourceId",
                annotationMetadataCollection
                );

            if (result)
            {
                Console.WriteLine("Successfully called IfxHealth.LogAnnotationHealthReport.");
            }
            else
            {
                Console.WriteLine("IfxHealth.LogAnnotationHealthReport call failed.");
            }
        }



        static void EmitLogs()
        {
            using (Operation operation = new Operation("Some Operation"))
            {
                operation.SetResult(OperationResult.Success);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        private static void TestComputers()
        {
            foreach(var comp in Network.GetComputers())
            {
                comp.TestConnection();
            }
        }
    }
}
