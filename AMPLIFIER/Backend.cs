using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Amplifier.Utils;
using Newtonsoft.Json;
using Sentry;

namespace Amplifier
{
    public class Backend : IDisposable
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly WSConfig _wsConfig = null;

        public Backend(WSConfig wsConfig)
        {
            this._wsConfig = wsConfig;
            Sentry.Instance.GetTransaction("Backend", "Create");
            AttachAuthorizationHeader();
        }

        private void AttachAuthorizationHeader()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _wsConfig.JWTToken);
        }

        public async System.Threading.Tasks.Task SendProductsAsync(List<Product> products)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("products-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "products-import",
                    new StringContent(JsonConvert.SerializeObject(products), Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendPriceLevelsAsync(List<PriceLevel> priceLevels)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("price-levels-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "price-levels-import",
                    new StringContent(JsonConvert.SerializeObject(priceLevels), Encoding.UTF8, "application/json"));

                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendPricesAsync(List<Price> priceLevels)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("prices-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "prices-import",
                    new StringContent(JsonConvert.SerializeObject(priceLevels), Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendStockLocationsAsync(List<StockLocation> stockLocations)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("stock-locations-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "stock-locations-import",
                    new StringContent(JsonConvert.SerializeObject(stockLocations), Encoding.UTF8, "application/json"));

                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendStocksAsync(List<Stock> stocks)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("stocks-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "stocks-import",
                    new StringContent(JsonConvert.SerializeObject(stocks), Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendProductCategoriesAsync(List<ProductCategory> categories)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("product-categories-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "product-categories-import",
                    new StringContent(JsonConvert.SerializeObject(categories), Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendProductCategoriesRelationAsyncsAsync(
            List<ProductCategoryRelation> relations)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("product-categories-relation-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "product-categories-relation-import",
                    new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendCustomerProductsRelationAsyncsAsync(
            List<CustomerProductRelation> relations)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("customer-products-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-products-import",
                    new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendCustomerProductLogisticMinimumAsync(
            List<CustomerProductLogisticMinimum> relations)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("customer-logistic-minimum-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-logistic-minimum-import",
                    new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendRelatedProductsAsync(List<RelatedProducts> related_products)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("product-related-products-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "product-related-products-import",
                    new StringContent(JsonConvert.SerializeObject(related_products), Encoding.UTF8,
                        "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendAccountsAsync(List<Account> accounts)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("accounts-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "accounts-import",
                    new StringContent(JsonConvert.SerializeObject(accounts), Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendDocumentsAsync(List<Document> documents)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("document-import");
            try
            {
                IEnumerable<List<Document>> toSend = WSUtilities.SplitList(documents);
                foreach (List<Document> p in toSend)
                {
                    var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "document-import",
                        new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json"));
                    if (response.StatusCode != HttpStatusCode.Created)
                        SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
                }
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendSettlementsAsync(List<Settlement> settlements)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("settlement-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "settlement-import",
                    new StringContent(JsonConvert.SerializeObject(settlements), Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendCategoryDiscountAsync(List<CategoryDiscount> category_discounts)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("category-discount-import");
            try
            {
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
                    if (response.StatusCode != HttpStatusCode.Created)
                        SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
                }
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendFile(string path, string fileName, string product_external_id,
            string order)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("product-images-add");
            try
            {
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
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task<string> GetListOfOrders(string status)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("order-get-list");
            try
            {
                HttpResponseMessage response =
                    await _client.GetAsync(_wsConfig.B2BWSUrl.Replace("api/", "") + "orders-translator/?status=" +
                                           status);
                response.EnsureSuccessStatusCode();
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
                span.Finish();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return string.Empty;
            }
        }

        public async System.Threading.Tasks.Task<string> GetOrder(string token)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("order-get");
            try
            {
                string uri = String.Format(_wsConfig.B2BWSUrl.Replace("api/", "") + "orders-translator/{0}/", token);
                HttpResponseMessage response = await _client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                span.Finish();
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return string.Empty;
            }
        }

        public async System.Threading.Tasks.Task<string> ChangeOrderStatus(string status, string token)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("order-update");
            try
            {
                var content = JsonConvert.SerializeObject(new {status = status});
                string uri = String.Format(_wsConfig.B2BWSUrl.Replace("api/", "") + "orders-translator/{0}/", token);
                var response = await _client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), uri)
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                });
                response.EnsureSuccessStatusCode();
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
                span.Finish();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return string.Empty;
            }
        }

        public async System.Threading.Tasks.Task SendAddresses(List<Address> addresses)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("addresses-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "addresses-import",
                    new StringContent(JsonConvert.SerializeObject(addresses), Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task<string> GetListOfComplaints()
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("complaint-get-list");
            try
            {
                HttpResponseMessage response =
                    await _client.GetAsync(_wsConfig.B2BWSUrl.Replace("api/", "") + "complaints-translator/");
                response.EnsureSuccessStatusCode();
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
                span.Finish();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
                return string.Empty;
            }
        }

        public async System.Threading.Tasks.Task SendCustomerCategoriesAsync(List<CustomerCategory> categories)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("customer-categories-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-categories-import",
                    new StringContent(JsonConvert.SerializeObject(categories), Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public async System.Threading.Tasks.Task SendCustomerCategoriesRelationAsyncsAsync(
            List<CustomerCategoryRelation> relations)
        {
            var span = Sentry.Instance.GetTransaction("Backend").StartChild("customer-categories-relation-import");
            try
            {
                var response = await _client.PostAsync(_wsConfig.B2BWSUrl + "customer-categories-relation-import",
                    new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
                if (response.StatusCode != HttpStatusCode.Created)
                    SentrySdk.CaptureMessage(await response.Content.ReadAsStringAsync(), level: SentryLevel.Error);
            }
            catch (Exception e)
            {
                SentrySdk.CaptureException(e);
            }

            span.Finish();
        }

        public void Dispose()
        {
            Sentry.Instance.GetTransaction("Backend").Finish();
            _client?.Dispose();
        }
    }
}