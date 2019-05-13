using Newtonsoft.Json;

namespace Billetautomat
{
    public class LoginResponse
    {

        [JsonProperty("response")]
        public string response { get; set; }
        [JsonProperty("token")]
        public string token { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

    }



}




