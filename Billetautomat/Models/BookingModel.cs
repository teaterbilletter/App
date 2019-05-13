using Newtonsoft.Json;
using System;

namespace Billetautomat
{

    public class Booking
    {
        [JsonProperty("bookingID")]
        public int bookingID { get; set; }

        [JsonProperty("customerID")]
        public string customerID { get; set; }


        [JsonProperty("seats")]
        public Seats[] seats { get; set; }

        [JsonProperty("show")]
        public Show show { get; set; }

        [JsonProperty("date")]
        public DateTime date { get; set; }

        [JsonProperty("totalPrice")]
        public double totalPrice { get; set; }

    }




    public class Show
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("dates")]
        public DateTime[] dates { get; set; }
        [JsonProperty("hall")]
        public Hall hall { get; set; }
        [JsonProperty("imgUrl")]
        public string imgUrl { get; set; }
        [JsonProperty("basePrice")]
        public double basePrice { get; set; }
        [JsonProperty("active")]
        public bool active { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }


    }

    public class Hall
    {
        [JsonProperty("hallNum")]
        public int hallNum { get; set; }
        [JsonProperty("seats")]
        public int seats { get; set; }
        [JsonProperty("rows")]
        public int rows { get; set; }
        [JsonProperty("theater")]
        public Theater theater { get; set; }


    }


    public class Theater
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("address")]
        public string address { get; set; }
        [JsonProperty("active")]
        public bool active { get; set; }

    }
    public class Seats
    {
        [JsonProperty("seat_number")]
        public int seat_number { get; set; }
        [JsonProperty("row_number")]
        public int row_number { get; set; }
    

    }

}





