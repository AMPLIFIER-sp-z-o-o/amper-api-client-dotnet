using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Amplifier
{
    public class AmplifierJWTAuth
    {
        private string username = null;
        private string password = null;

        private string authUrl = "";

        public AmplifierJWTAuth(string username, string password, string authUrl)
        {
            this.username = username;
            this.password = password;
            this.authUrl = authUrl;
        }

        public async System.Threading.Tasks.Task<string> GetToken()
        {
            HttpClient client = new HttpClient();
            string uri = authUrl;

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("password", this.password),
                new KeyValuePair<string, string>("username", this.username),
            });

            var response = await client.PostAsync(uri, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            JObject jwtObj = JObject.Parse(responseContent);
            return (string)jwtObj["access_token"];
        }
    }
}
