using System;

namespace amper_api_client
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddUserSecrets<Program>()
               .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            var b2bWsConfig = new B2BWSConfig();
            configuration.GetSection("B2BWSSettings").Bind(b2bWsConfig);

            Console.WriteLine("Setting from appsettings.json: " + b2bWsConfig.B2BWSUrl);

            AmplifierJWTAuth amplifierJWTAuth = new AmplifierJWTAuth("ik9dz8", "4043d1b3-0649-48d7-b45c-141a9e3d2fcb", "ymdunr", "dcCgq3QUdwAcC5jg");
            b2bWsConfig.JWTToken = await amplifierJWTAuth.GetToken();

            Import import = new Import(b2bWsConfig);

            if (args.Length > 0)
                switch (args[0])
                {
                    case "products":
                        await import.ImportProductsAsync();
                        await import.ImportProductCategories();
                        break;
                    case "prices":
                        await import.ImportPriceLevels();
                        break;
                    case "accounts":
                        await import.ImportAcconuntsAsync();
                        await import.ImportSettlmentsAsync();
                        await import.ImportAddresses();
                        break;
                    case "stock":
                        await import.ImportStockLocations();
                        await import.ImportStocks();
                        break;
                    case "orders":
                        Export export = new Export(b2bWsConfig);
                        await export.ExportOrders();
                        break;
                    case "complaint":
                        Export complaint = new Export(b2bWsConfig);
                        await complaint.ExportComplaints();
                        break;
                    case "photos":
                        await import.ImportPhotos();
                        break;
                    case "documents":
                        await import.ImportCustomerDocuments();
                        break;
                }
        }
    }
}
