using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "products-import",
                    new StringContent(JsonConvert.SerializeObject(products), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendPriceLevelsAsync(List<PriceLevel> priceLevels)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "price-levels-import",
                    new StringContent(JsonConvert.SerializeObject(priceLevels), Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendPricesAsync(List<Price> priceLevels)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "prices-import",
                    new StringContent(JsonConvert.SerializeObject(priceLevels), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendStockLocationsAsync(List<StockLocation> stockLocations)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "stock-locations-import",
                    new StringContent(JsonConvert.SerializeObject(stockLocations), Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendStocksAsync(List<Stock> stocks)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "stocks-import",
                    new StringContent(JsonConvert.SerializeObject(stocks), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendProductCategoriesAsync(List<ProductCategory> categories)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "product-categories-import",
                    new StringContent(JsonConvert.SerializeObject(categories), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendProductCategoriesRelationAsyncsAsync(
            List<ProductCategoryRelation> relations)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "product-categories-relation-import",
                    new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendCustomerProductsRelationAsyncsAsync(
            List<CustomerProductRelation> relations)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-products-import",
                    new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendCustomerProductLogisticMinimumAsync(
            List<CustomerProductLogisticMinimum> relations)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-logistic-minimum-import",
                    new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendRelatedProductsAsync(List<RelatedProducts> related_products)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "product-related-products-import",
                    new StringContent(JsonConvert.SerializeObject(related_products), Encoding.UTF8,
                        "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendAccountsAsync(List<Account> accounts)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "accounts-import",
                    new StringContent(JsonConvert.SerializeObject(accounts), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendDocumentsAsync(List<Document> documents)
        {
            try
            {
                await ValidateJWTToken();
                IEnumerable<List<Document>> toSend = WSUtilities.SplitList(documents);
                foreach (List<Document> p in toSend)
                {
                    var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "document-import",
                        new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json"));
                    if (!response.IsSuccessStatusCode)
                        await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendSettlementsAsync(List<Settlement> settlements)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "settlement-import",
                    new StringContent(JsonConvert.SerializeObject(settlements), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendCategoryDiscountAsync(List<CategoryDiscount> category_discounts)
        {
            try
            {
                await ValidateJWTToken();
                IEnumerable<List<CategoryDiscount>> toSend = WSUtilities.SplitList(category_discounts, 50000);
                string first_package = "1";
                string last_package = "0";
                string single_thread = "1";
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
                        await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task<string> SendFile(string path, string fileName, string product_external_id,
            string order)
        {
            try
            {
                await ValidateJWTToken();
                var fileBytes = File.ReadAllBytes(path);
                var byteArrayContent = new ByteArrayContent(fileBytes);
                var multipartContent = new MultipartFormDataContent();
                multipartContent.Add(byteArrayContent, "image", fileName);
                multipartContent.Add(new StringContent(order), "order");
                multipartContent.Add(new StringContent("0"), "product_id");
                multipartContent.Add(new StringContent(fileName), "alt");
                multipartContent.Add(new StringContent(product_external_id), "product_external_id");

                var response = await _client.PostAsync(_wsConfig.B2BWSUrl.Replace("api/", "") + "product-images/",
                    multipartContent);
                if (!response.IsSuccessStatusCode)
                {
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
                    return await response.Content.ReadAsStringAsync();
                }
                else
                    return "OK";
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
                return e.Message;
            }
        }

        public async System.Threading.Tasks.Task<List<Order>> GetListOfOrders(string status)
        {
            try
            {
                await ValidateJWTToken();
                HttpResponseMessage response =
                    await _client.GetAsync(_wsConfig.B2BWSUrl.Replace("api/", "") + "orders-translator/?status=" +
                                           status);
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
                List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(await response.Content.ReadAsStringAsync());
                return orders;
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
                return new List<Order>();
            }
        }

        public async System.Threading.Tasks.Task<Order> GetOrder(string token)
        {
            try
            {
                await ValidateJWTToken();
                string uri = String.Format(_wsConfig.B2BWSUrl.Replace("api/", "") + "orders-translator/{0}/", token);
                HttpResponseMessage response = await _client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
                Order order = JsonConvert.DeserializeObject<Order>(await response.Content.ReadAsStringAsync());
                return order;
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
                return null;
            }
        }

        public async System.Threading.Tasks.Task<string> ChangeOrderStatus(string status, string token)
        {
            try
            {
                await ValidateJWTToken();
                var content = JsonConvert.SerializeObject(new {status = status});
                string uri = String.Format(_wsConfig.B2BWSUrl.Replace("api/", "") + "orders-translator/{0}/", token);
                var response = await _client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), uri)
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                });
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
                return string.Empty;
            }
        }

        public async System.Threading.Tasks.Task SendAddresses(List<Address> addresses)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "addresses-import",
                    new StringContent(JsonConvert.SerializeObject(addresses), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task<List<Complaint>> GetListOfComplaints()
        {
            try
            {
                await ValidateJWTToken();
                HttpResponseMessage response =
                    await _client.GetAsync(_wsConfig.B2BWSUrl.Replace("api/", "") + "complaints-translator/?status=NEW");
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
                List<Complaint> complaintList = JsonConvert.DeserializeObject<List<Complaint>>( await response.Content.ReadAsStringAsync());
                return complaintList;
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
                return new List<Complaint>();
            }
        }
        
        public async System.Threading.Tasks.Task<string> ChangeComplaintStatus(string status, string token)
        {
            try
            {
                await ValidateJWTToken();
                var content = JsonConvert.SerializeObject(new { status = status });
                string uri = String.Format(_wsConfig.B2BWSUrl.Replace("api/", "") + "complaints-translator/{0}/", token);
                var response = await _client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), uri)
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                });
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
                return string.Empty;
            }

        }

        public async System.Threading.Tasks.Task SendCustomerCategoriesAsync(List<CustomerCategory> categories)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-categories-import",
                    new StringContent(JsonConvert.SerializeObject(categories), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendCustomerCategoriesRelationAsyncsAsync(
            List<CustomerCategoryRelation> relations)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-categories-relation-import",
                    new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }
        
        public async System.Threading.Tasks.Task SendPriceLevelAssigmentAsync(List<PriceLevelAssigment> assigments)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "price-level-assigment-import",
                    new StringContent(JsonConvert.SerializeObject(assigments), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendPromotionsAsync(List<Promotion> promotions)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "promotions-import",
                    new StringContent(JsonConvert.SerializeObject(promotions), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendPromotinCustomersAsync(List<PromotionCustomer> promotions)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "promotions-customers-import",
                    new StringContent(JsonConvert.SerializeObject(promotions), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }

        public async System.Threading.Tasks.Task SendPromotionCustomerCategoriesAsync(List<PromotionCustomerCategory> promotions)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "promotions-customer-categories-import",
                    new StringContent(JsonConvert.SerializeObject(promotions), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }        
        
        public async System.Threading.Tasks.Task<List<Document>> GetListOfDocuments(string status)
        {
            try
            {
                await ValidateJWTToken();
                HttpResponseMessage response =
                    await _client.GetAsync(_wsConfig.B2BWSUrl.Replace("api/", "") + "documents-translator/?status=" +
                                           status);
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
                
                List<Document> documents = JsonConvert.DeserializeObject<List<Document>>(await response.Content.ReadAsStringAsync());
                return documents;
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
                return new List<Document>();
            }
        }

        public async System.Threading.Tasks.Task<Document> GetDocument(string id)
        {
            try
            {
                await ValidateJWTToken();
                string uri = String.Format(_wsConfig.B2BWSUrl.Replace("api/", "") + "documents-translator/{0}/", id);
                HttpResponseMessage response = await _client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
                Document document = JsonConvert.DeserializeObject<Document>(await response.Content.ReadAsStringAsync());
                return document;
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
                return null;
            }
        }

        public async System.Threading.Tasks.Task<string> ChangeDocumentStatus(string status, string id)
        {
            try
            {
                await ValidateJWTToken();
                var content = JsonConvert.SerializeObject(new {status = status});
                string uri = String.Format(_wsConfig.B2BWSUrl.Replace("api/", "") + "documents-translator/{0}/", id);
                var response = await _client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), uri)
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                });
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
                return string.Empty;
            }
        }        
        
        public async System.Threading.Tasks.Task SendUnitOfMeasuresAsync(List<UnitOfMeasure> units)
        {
            try
            {
                await ValidateJWTToken();
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "unitofmeasure-import",
                    new StringContent(JsonConvert.SerializeObject(units), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
            }
        }
        
        public async System.Threading.Tasks.Task CreateLogEntryAsync(string level, string message)
        {
            try
            {
                await ValidateJWTToken();
                LogEntry logEntry = new LogEntry();
                logEntry.level = level;
                logEntry.message = message;
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "translator/log-entry",
                    new StringContent(JsonConvert.SerializeObject(logEntry), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
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
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "default-price-overwrite-import",
                    new StringContent(JsonConvert.SerializeObject(overwrites), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                await CreateLogEntryAsync(LogSeverity.Error, e.Message);
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
                await CreateLogEntryAsync(LogSeverity.Error, await response.Content.ReadAsStringAsync());
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _wsConfig.JWTToken = JObject.Parse(responseContent);
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}