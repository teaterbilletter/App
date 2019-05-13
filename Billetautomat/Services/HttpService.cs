using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Android.Graphics;
using Xamarin.Essentials;

namespace Billetautomat.Services
{

    public class HttpService
    {
        private static HttpClient client = new HttpClient();
        public static  readonly string Basepath = "https://disttickets.northeurope.cloudapp.azure.com";
        public static List<Booking> bookings = new List<Booking>();

        public static async Task<string> GetCustomerBookings()
        {
            //Add Authentication token to the header of the getbookings request
            var token = Preferences.Get("token", null);
            var user = Preferences.Get("username", null);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
       
            try
            {

                var httpResponse = await client.GetAsync(Basepath+ $"/Bookings/{user}");
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                bookings = JsonConvert.DeserializeObject<List<Booking>>(responseContent);

                if (bookings.Any())
                {
                    return "Hentet";
                }
             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Ingen bookinger at vise";
   
            }


            return "Der opstod en fejl";


        }

        public static async Task<String> GetBookingDetails(int id, int arrayposition)
        {
            //Add Authentication token to the header of the getbookings request
            var token = Preferences.Get("token", null);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {

                var httpResponse = await client.GetAsync(Basepath + $"/Booking/{id}");
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                bookings[arrayposition] = JsonConvert.DeserializeObject<Booking>(responseContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Fejl";

            }

            return "Hentet";



        }






        public static async Task<string> GetLoginResponse(string username, string password)
        {


            try
            {

                var httpResponseMessage = await client.PostAsync(Basepath+ "/UserLogin",
                    new StringContent(JsonConvert.SerializeObject(new User() { name = username, password = password }), Encoding.UTF8, "application/json"));
                var readcContent = await httpResponseMessage.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(readcContent);
          
                if (!(loginResponse == null))
                {


                    Preferences.Set("token", loginResponse.token);
                    Preferences.Set("username", loginResponse.username);
                    Preferences.Set("name", loginResponse.response);
                    return "Success";


                }

                return "Forkert brugernavn eller adgangskode";

            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "Forkert brugernavn eller adgangskode";
               

            }
        }

        public static Bitmap ConvertToBitmapfromURL(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

    }
}