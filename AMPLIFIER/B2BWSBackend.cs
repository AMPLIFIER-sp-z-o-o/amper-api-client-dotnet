using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Amplifier.Utils;
using Newtonsoft.Json;

namespace Amplifier
{
    public class B2BWSBackend
    {
        private readonly HttpClient client = new HttpClient();
        B2BWSConfig b2BWSConfig = null;

        public B2BWSBackend(B2BWSConfig b2BWSConfig)
        {
            this.b2BWSConfig = b2BWSConfig;
            AttachAuthorizationHeader();
        }

        private void AttachAuthorizationHeader()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + b2BWSConfig.JWTToken);
        }

        public async System.Threading.Tasks.Task SendProductsAsync(List<Product> products)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "products-import", new StringContent(JsonConvert.SerializeObject(products), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendPriceLevelsAsync(List<PriceLevel> priceLevels)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "price-levels-import", new StringContent(JsonConvert.SerializeObject(priceLevels), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendPricesAsync(List<Price> priceLevels)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "prices-import", new StringContent(JsonConvert.SerializeObject(priceLevels), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendStockLocationsAsync(List<StockLocation> stockLocations)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "stock-locations-import", new StringContent(JsonConvert.SerializeObject(stockLocations), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendStocksAsync(List<Stock> stocks)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "stocks-import", new StringContent(JsonConvert.SerializeObject(stocks), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendProductCategoriesAsync(List<ProductCategory> categories)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "product-categories-import", new StringContent(JsonConvert.SerializeObject(categories), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendProductCategoriesRelationAsyncsAsync(List<ProductCategoryRelation> relations)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "product-categories-relation-import", new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
        }
        public async System.Threading.Tasks.Task SendCustomerProductsRelationAsyncsAsync(List<CustomerProductRelation> relations)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "customer-products-import", new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendCustomerProductLogisticMinimumAsync(List<CustomerProductLogisticMinimum> relations)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "customer-logistic-minimum-import", new StringContent(JsonConvert.SerializeObject(relations), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendRelatedProductsAsync(List<RelatedProducts> related_products)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "product-related-products-import", new StringContent(JsonConvert.SerializeObject(related_products), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendAccountsAsync(List<Account> accounts)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "accounts-import", new StringContent(JsonConvert.SerializeObject(accounts), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendDocumentsAsync(List<Document> documents)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "document-import", new StringContent(JsonConvert.SerializeObject(documents), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendSettlementsAsync(List<Settlement> settlements)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "settlement-import", new StringContent(JsonConvert.SerializeObject(settlements), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendCategoryDiscountAsync(List<CategoryDiscount> category_discounts)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "category-discount-import", new StringContent(JsonConvert.SerializeObject(category_discounts), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task SendFile(string path, string fileName, string product_external_id, string order)
        {
            var fileBytes = File.ReadAllBytes(path);
            var byteArrayContent = new ByteArrayContent(fileBytes);
            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(byteArrayContent, "image", fileName);
            multipartContent.Add(new StringContent(order), "order");
            multipartContent.Add(new StringContent("0"), "product_id");
            multipartContent.Add(new StringContent(fileName), "alt");
            multipartContent.Add(new StringContent(product_external_id), "product_external_id");

            var postResponse = await client.PostAsync(b2BWSConfig.B2BWSUrl.Replace("api/", "") + "product-images/", multipartContent);
        }

        public async System.Threading.Tasks.Task<string> GetListOfOrders(string status)
        {
            HttpResponseMessage response = await client.GetAsync(b2BWSConfig.B2BWSUrl.Replace("api/", "") + "orders-translator/?status=" + status);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async System.Threading.Tasks.Task<string> GetOrder(string token)
        {
            string uri = String.Format(b2BWSConfig.B2BWSUrl.Replace("api/", "") + "orders-translator/{0}/", token);
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async System.Threading.Tasks.Task<string> ChangeOrderStatus(string status, string token)
        {
            var content = JsonConvert.SerializeObject(new { status = status });
            string uri = String.Format(b2BWSConfig.B2BWSUrl.Replace("api/", "") + "orders-translator/{0}/", token);
            var response = await client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), uri)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            });
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async System.Threading.Tasks.Task SendAddresses(List<Address> addresses)
        {
            var t = await client.PostAsync(b2BWSConfig.B2BWSUrl + "addresses-import", new StringContent(JsonConvert.SerializeObject(addresses), Encoding.UTF8, "application/json"));
        }

        public async System.Threading.Tasks.Task<string> GetListOfComplaints()
        {
            HttpResponseMessage response = await client.GetAsync(b2BWSConfig.B2BWSUrl.Replace("api/", "") + "complaints-translator/");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}