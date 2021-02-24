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
        private string scope = null;
        private string client_secret = null;
        private string username = null;
        private string password = null;

        private const string authUrl = "https://account.ampliapps.com/auth/realms/{0}/protocol/openid-connect/token";

        public AmplifierJWTAuth(string scope, string client_secret, string username, string password)
        {
            this.scope = scope;
            this.client_secret = client_secret;
            this.username = username;
            this.password = password;
        }

        public async System.Threading.Tasks.Task<string> GetToken()
        {
            HttpClient client = new HttpClient();
            string uri = String.Format(authUrl, this.scope);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("client_id", "translator"),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("client_secret", this.client_secret),
                new KeyValuePair<string, string>("scope", this.scope),
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
