using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Amplifier.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amplifier
{
    public class Backend : IDisposable
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly WSConfig _wsConfig = null;

        public Backend(WSConfig wsConfig)
        {
            this._wsConfig = wsConfig;
            AttachAuthorizationHeader();
        }

        private void AttachAuthorizationHeader()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _wsConfig.JWTToken["access_token"]);
        }

        public async System.Threading.Tasks.Task SendProductsAsync(List<Product> products)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + products.Count() + " products records.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "products-import",
                    new StringContent(JsonConvert.SerializeObject(products), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error, 
                        "FAILURE while sending products after " + watch.ElapsedMilliseconds + " ms; " 
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info, 
                        "Success while sending products records after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendPriceLevelsAsync(List<PriceLevel> priceLevels)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + priceLevels.Count() + " price levels.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "price-levels-import",
                    new StringContent(JsonConvert.SerializeObject(priceLevels), Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending price levels after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending price levels after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendPricesAsync(List<Price> priceLevels)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + priceLevels.Count() + " prices.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "prices-import",
                    new StringContent(JsonConvert.SerializeObject(priceLevels), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending prices after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending prices after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendStockLocationsAsync(List<StockLocation> stockLocations)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + stockLocations.Count() + " stock locations.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "stock-locations-import",
                    new StringContent(JsonConvert.SerializeObject(stockLocations), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending stock locations after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending prices after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendStocksAsync(List<Stock> stocks)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + stocks.Count() + " stocks.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "stocks-import",
                    new StringContent(JsonConvert.SerializeObject(stocks), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending stocks after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending stocks after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendProductCategoriesAsync(List<ProductCategory> categories)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + categories.Count() + " product categories.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "product-categories-import",
                    new StringContent(JsonConvert.SerializeObject(categories), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending product categories after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending product categories after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendProductCategoriesRelationAsyncsAsync(
            List<ProductCategoryRelation> relations)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + relations.Count() + " product categories relations.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "product-categories-relation-import",
                    new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending product categories relations after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending product categories relations after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendCustomerProductsRelationAsyncsAsync(
            List<CustomerProductRelation> relations)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + relations.Count() + " customer products relations.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-products-import",
                    new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending customer products relations after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending customer products relations after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendCustomerProductLogisticMinimumAsync(
            List<CustomerProductLogisticMinimum> relations)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + relations.Count() + " customer product logistics.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-logistic-minimum-import",
                    new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending customer product logistics after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending customer product logistics after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendRelatedProductsAsync(List<RelatedProducts> related_products)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + related_products.Count() + " related products.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "product-related-products-import",
                    new StringContent(JsonConvert.SerializeObject(related_products), Encoding.UTF8,
                        "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending related products after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending related products after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendAccountsAsync(List<Account> accounts)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + accounts.Count() + " accounts.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "accounts-import",
                    new StringContent(JsonConvert.SerializeObject(accounts), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending accounts after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending accounts after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendDocumentsAsync(List<Document> documents)
        {
            try
            {
                await ValidateJWTToken();
                IEnumerable<List<Document>> toSend = WSUtilities.SplitList(documents);
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + documents.Count() + " documents.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                int errors = 0;
                foreach (List<Document> p in toSend)
                {
                    var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "document-import",
                        new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json"));
                    if (!response.IsSuccessStatusCode)
                    {
                        await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending a batch of " + p.Count() + " documents; "
                        + await response.Content.ReadAsStringAsync());
                        errors++;
                    }
                }
                watch.Stop();
                await CreateLogEntryAsync(LogSeverity.Info,
                    "Sending documents finished after " + watch.ElapsedMilliseconds + " ms with " + errors + " errors.");
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendAlignDocumentAsync(Document document)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send align document.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "document-align",
                    new StringContent(JsonConvert.SerializeObject(document), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending align document after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending align document after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendSettlementsAsync(List<Settlement> settlements)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + settlements.Count() + " settlements.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "settlement-import",
                    new StringContent(JsonConvert.SerializeObject(settlements), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending settlements after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending settlements after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendCategoryDiscountAsync(List<CategoryDiscount> category_discounts)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + category_discounts.Count() + " category discounts.");
                IEnumerable<List<CategoryDiscount>> toSend = WSUtilities.SplitList(category_discounts, 50000);
                string first_package = "1";
                string last_package = "0";
                string single_thread = "1";
                var watch = System.Diagnostics.Stopwatch.StartNew();
                int errors = 0;
                foreach (List<CategoryDiscount> p in toSend)
                {
                    if (p.Count() < 50000)
                    {
                        last_package = "1";
                        single_thread = "0";
                    }

                    var response = await _client.PostAsync(
                        _wsConfig.B2BWSUrl + "category-discount-import?single_thread=1&first_package=" + first_package +
                        "&last_package=" + last_package + "&single_thread=" + single_thread,
                        new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json"));
                    first_package = "0";
                    if (!response.IsSuccessStatusCode)
                    {
                        await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending a batch of " + p.Count() + " category discounts; "
                        + await response.Content.ReadAsStringAsync());
                        errors++;
                    }
                }
                watch.Stop();
                await CreateLogEntryAsync(LogSeverity.Info,
                    "Sending category discounts finished after " + watch.ElapsedMilliseconds + " ms with " + errors + " errors.");
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task<string> SendFile(string path, string fileName, string product_external_id,
            string order)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send file " + fileName);
                var fileBytes = File.ReadAllBytes(path);
                var byteArrayContent = new ByteArrayContent(fileBytes);
                var multipartContent = new MultipartFormDataContent();
                multipartContent.Add(byteArrayContent, "image", fileName);
                multipartContent.Add(new StringContent(order), "order");
                multipartContent.Add(new StringContent("0"), "product_id");
                multipartContent.Add(new StringContent(fileName), "alt");
                multipartContent.Add(new StringContent(product_external_id), "product_external_id");
                var watch = System.Diagnostics.Stopwatch.StartNew();

                var response = await _client.PostAsync(_wsConfig.B2BWSUrl.Replace("api/", "") + "product-images/",
                    multipartContent);
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending file after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending file after " + watch.ElapsedMilliseconds + " ms.");
                    return "OK";
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
                return e.Message;
            }
        }

        public async System.Threading.Tasks.Task<List<Order>> GetListOfOrders(string status)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to get list of orders for status " + status);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                HttpResponseMessage response =
                    await _client.GetAsync(_wsConfig.B2BWSUrl.Replace("api/", "") + "orders-translator/?status=" +
                                           status);
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while getting list of orders after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while getting list of orders after " + watch.ElapsedMilliseconds + " ms.");
                }
                List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(await response.Content.ReadAsStringAsync());
                return orders;
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
                return new List<Order>();
            }
        }

        public async System.Threading.Tasks.Task<Order> GetOrder(string token)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to get order for token " + token);
                string uri = String.Format(_wsConfig.B2BWSUrl.Replace("api/", "") + "orders-translator/{0}/", token);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                HttpResponseMessage response = await _client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while getting order after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while getting order after " + watch.ElapsedMilliseconds + " ms.");
                }
                Order order = JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());
                return order;
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
                return null;
            }
        }

        public async System.Threading.Tasks.Task<string> ChangeOrderStatus(string status, string token)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to change order status for token " + token);
                var content = JsonConvert.SerializeObject(new {status = status});
                string uri = String.Format(_wsConfig.B2BWSUrl.Replace("api/", "") + "orders-translator/{0}/", token);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), uri)
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                });
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while changing order status after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while changing order status after " + watch.ElapsedMilliseconds + " ms.");
                }
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
                return string.Empty;
            }
        }

        public async System.Threading.Tasks.Task SendAddresses(List<Address> addresses)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + addresses.Count() + " addresses.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "addresses-import",
                    new StringContent(JsonConvert.SerializeObject(addresses), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending addresses after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending addresses after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task<List<Complaint>> GetListOfComplaints()
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to get list of complaints.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                HttpResponseMessage response =
                    await _client.GetAsync(_wsConfig.B2BWSUrl.Replace("api/", "") + "complaints-translator/?status=NEW");
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while getting list of complaints after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while getting list of complaints after " + watch.ElapsedMilliseconds + " ms.");
                }
                List<Complaint> complaintList = JsonConvert.DeserializeObject<List<Complaint>>( await response.Content.ReadAsStringAsync());
                return complaintList;
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
                return new List<Complaint>();
            }
        }
        
        public async System.Threading.Tasks.Task<string> ChangeComplaintStatus(string status, string token)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to change complaint status for token " + token);
                var content = JsonConvert.SerializeObject(new { status = status });
                string uri = String.Format(_wsConfig.B2BWSUrl.Replace("api/", "") + "complaints-translator/{0}/", token);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), uri)
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                });
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while changing complaint status after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while changing complaint status after " + watch.ElapsedMilliseconds + " ms.");
                }
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
                return string.Empty;
            }

        }

        public async System.Threading.Tasks.Task SendCustomerCategoriesAsync(List<CustomerCategory> categories)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + categories.Count() + " categories.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-categories-import",
                    new StringContent(JsonConvert.SerializeObject(categories), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending categories after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending categories after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendCustomerCategoriesRelationAsyncsAsync(
            List<CustomerCategoryRelation> relations)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + relations.Count() + " customer categories relations.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-categories-relation-import",
                    new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending customer categories relations after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending customer categories relations after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }
        
        public async System.Threading.Tasks.Task SendPriceLevelAssigmentAsync(List<PriceLevelAssigment> assigments)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + assigments.Count() + " price level assignments.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "price-level-assigment-import",
                    new StringContent(JsonConvert.SerializeObject(assigments), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending price level assignments after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending price level assignments after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendPromotionsAsync(List<Promotion> promotions)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + promotions.Count() + " promotions.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "promotions-import",
                    new StringContent(JsonConvert.SerializeObject(promotions), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending promotions after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending promotions after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendPromotinCustomersAsync(List<PromotionCustomer> promotions)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + promotions.Count() + " promotion customers.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "promotions-customers-import",
                    new StringContent(JsonConvert.SerializeObject(promotions), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending promotion customers after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending promotion customers after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendPromotionCustomerCategoriesAsync(List<PromotionCustomerCategory> promotions)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + promotions.Count() + " promotion customer categories.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "promotions-customer-categories-import",
                    new StringContent(JsonConvert.SerializeObject(promotions), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending promotion customer categories after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending promotion customer categories after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }        
        
        public async System.Threading.Tasks.Task<List<Document>> GetListOfDocuments(string status)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to get list of documents.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                HttpResponseMessage response =
                    await _client.GetAsync(_wsConfig.B2BWSUrl.Replace("api/", "") + "documents-translator/?status=" +
                                           status);
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while getting list of documents after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while getting list of documents after " + watch.ElapsedMilliseconds + " ms.");
                }

                List<Document> documents = JsonConvert.DeserializeObject<List<Document>>(await response.Content.ReadAsStringAsync());
                return documents;
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
                return new List<Document>();
            }
        }

        public async System.Threading.Tasks.Task<Document> GetDocument(string id)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to get a document.");
                string uri = String.Format(_wsConfig.B2BWSUrl.Replace("api/", "") + "documents-translator/{0}/", id);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                HttpResponseMessage response = await _client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while getting a document after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while getting a document after " + watch.ElapsedMilliseconds + " ms.");
                }
                Document document = JsonConvert.DeserializeObject<Document>(await response.Content.ReadAsStringAsync());
                return document;
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
                return null;
            }
        }

        public async System.Threading.Tasks.Task<string> ChangeDocumentStatus(string status, string id)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to change document status for id " + id);
                var content = JsonConvert.SerializeObject(new {status = status});
                string uri = String.Format(_wsConfig.B2BWSUrl.Replace("api/", "") + "documents-translator/{0}/", id);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), uri)
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                });
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while changing document status after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while changing document status after " + watch.ElapsedMilliseconds + " ms.");
                }
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
                return string.Empty;
            }
        }        
        
        public async System.Threading.Tasks.Task SendUnitOfMeasuresAsync(List<UnitOfMeasure> units)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + units.Count() + " units of measure.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "unitofmeasure-import",
                    new StringContent(JsonConvert.SerializeObject(units), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending units of measure after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending units of measure after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        public async System.Threading.Tasks.Task CreateLogEntryAsync(string level, string message)
        {
            try
            {
                await ValidateJWTToken();

                switch (level)
                {
                    case "info":
                        log.Info(message);
                        break;
                    case "warning":
                        log.Warn(message);
                        break;
                    case "debug":
                        log.Debug(message);
                        break;
                    case "error":
                        log.Error(message);
                        break;
                    default:
                        log.Error(message);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async System.Threading.Tasks.Task CreateLogEntryAsync(string level, string message, Exception ex)
        {
            try
            {
                await ValidateJWTToken();

                switch (level)
                {
                    case "info":
                        log.Info(ex, message);
                        break;
                    case "warning":
                        log.Warn(ex, message);
                        break;
                    case "debug":
                        log.Debug(ex, message);
                        break;
                    case "error":
                        log.Error(ex, message);
                        break;
                    default:
                        log.Error(ex, message);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendDefaultPriceOverwriteForCategoryDiscountAsync(List<DefaultPriceOverwriteForCategoryDiscount> overwrites)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + overwrites.Count() + " default price overwrites for category discounts.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "default-price-overwrite-import",
                    new StringContent(JsonConvert.SerializeObject(overwrites), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending default price overwrites for category discounts after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending default price overwrites for category discounts after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async Task ValidateJWTToken()
        {
            if (!WSUtilities.IsTokenExpired((string) _wsConfig.JWTToken["access_token"]))
                await RefreshToken();
        }

        private async Task RefreshToken()
        {
            var response = await _client.PostAsync(_wsConfig.B2BWSUrl.Replace("api/", "") + "/auth/token-refresh/",
                new StringContent(JsonConvert.SerializeObject(_wsConfig.JWTToken), Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode)
                await CreateLogEntryAsync(LogSeverity.Error, "JWT token refresh failed; " + await response.Content.ReadAsStringAsync());
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _wsConfig.JWTToken = JObject.Parse(responseContent);
                await CreateLogEntryAsync(LogSeverity.Info, "JWT token refresh successful.");
            }
        }
        
        public async System.Threading.Tasks.Task SendPaymentFormsAsync(List<PaymentForm> payment_forms)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + payment_forms.Count() + " payment forms.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "payment-forms-import",
                    new StringContent(JsonConvert.SerializeObject(payment_forms), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending payment forms after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending payment forms after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }
        
        public async System.Threading.Tasks.Task SendCustomerSalesRepresentativeRelationAsync(List<CustomerSalesRepresentative> sf_customer_relations)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + sf_customer_relations.Count() + " customer sales rep relations.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-sales-representative-import",
                    new StringContent(JsonConvert.SerializeObject(sf_customer_relations), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending customer sales rep relations after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending customer sales rep relations after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }
        
        public async System.Threading.Tasks.Task SendSchedulesAsync(List<SchedulerEntry> schedules)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + schedules.Count() + " schedules.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "schedules-import",
                    new StringContent(JsonConvert.SerializeObject(schedules), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending schedules after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending schedules after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendCustomerTasksAsync(List<CustomerTask> schedules)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + schedules.Count() + " customer tasks.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-tasks-import",
                    new StringContent(JsonConvert.SerializeObject(schedules), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending customer tasks after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending customer tasks after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendManufacturersAsync(List<Manufacturer> manufacturers)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + manufacturers.Count() + " manufacturers.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "manufacturers-import",
                    new StringContent(JsonConvert.SerializeObject(manufacturers), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending manufacturers after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending manufacturers after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public async System.Threading.Tasks.Task SendManufacturerBrandsAsync(List<Brand> brands)
        {
            try
            {
                await ValidateJWTToken();
                await CreateLogEntryAsync(LogSeverity.Info, "About to send " + brands.Count() + " brands.");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "manufacturer-brand-import",
                    new StringContent(JsonConvert.SerializeObject(brands), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Error,
                        "FAILURE while sending brands after " + watch.ElapsedMilliseconds + " ms; "
                        + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    watch.Stop();
                    await CreateLogEntryAsync(LogSeverity.Info,
                        "Success while sending brands after " + watch.ElapsedMilliseconds + " ms.");
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message, e);
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}