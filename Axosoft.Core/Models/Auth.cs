using Newtonsoft.Json;
using System;

public class AuthSettings
{
    public String URL { get; set; }

    [JsonProperty("access_token")]
    public String AccessToken { get; set; }

    [JsonProperty("data")]
    public UserData User { get; set; }
}

public class UserData
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("first_name")]
    public String FirstName { get; set; }

    [JsonProperty("last_name")]
    public String LastNamee { get; set; }
    
    [JsonProperty("email")]
    public String Email { get; set; }

}