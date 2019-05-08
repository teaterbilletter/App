using System;
using Newtonsoft.Json;

namespace Billetautomat
{
    public class Bookinger
    {

        public class ListBookinger
        {
            [JsonProperty("bookingID")]
            public string bookingID { get; set; }

            [JsonProperty("customerID")]
            public string customerID { get; set; }


            [JsonProperty("seats")]
            public String seats { get; set; }

            [JsonProperty("theater")]
            public String theater { get; set; }


            [JsonProperty("date")]
            public String date { get; set; }


        }




        public class show
        {
            public string title { get; set; }
            public string dates { get; set; }
            public int theater { get; set; }
            public string imgUrl { get; set; }

        }

    }




}
