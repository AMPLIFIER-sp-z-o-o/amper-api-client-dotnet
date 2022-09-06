using Newtonsoft.Json.Linq;

public class WSConfig
{
    public string B2BWSUrl { get; set; }
    public string ERPConnectionString { get; set; }
    public JObject JWTToken { get; set; }
    public string ClientIdentifier { get; set; }
}