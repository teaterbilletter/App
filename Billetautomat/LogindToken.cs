using System;
using Newtonsoft.Json;

namespace Billetautomat
{
    public class EmptyClass
    {

        public class Login
        {

            [JsonProperty("response")]
            public string response { get; set; }
            [JsonProperty("token")]
            public string token { get; set; }
           
        }


    }

}


