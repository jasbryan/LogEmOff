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


namespace LogEmOffUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            EmitMetrics();

            // IFx initialization is a required step for emitting logs
            IfxInitializer.Initialize(
                "cloudAgentTenantIdentity",
                "cloudAgentRoleIdentity",
                "cloudAgentRoleInstanceIdentity");

            EmitLogs();
        }

        static void EmitMetrics()
        {
            ErrorContext mdmError = new ErrorContext();

            MeasureMetric1D testMeasure = MeasureMetric1D.Create(
                "MyMonitoringAccount",
                "MyMetricNamespace",
                "MyMetricName",
                "MyDimensionName",
                ref mdmError);

            if (testMeasure == null)
            {
                Console.WriteLine("Fail to create MeasureMetric, error code is {0:X}, error message is {1}",
                    mdmError.ErrorCode,
                    mdmError.ErrorMessage);
            }
            else if (!testMeasure.LogValue(101, "MyDimensionValue", ref mdmError))
            {
                Console.WriteLine("Fail to log MeasureMetric value, error code is {0:X}, error message is {1}",
                    mdmError.ErrorCode,
                    mdmError.ErrorMessage);
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
