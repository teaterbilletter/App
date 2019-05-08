
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Billetautomat
{


    [Activity(Label = "Secondpage")]
    public class Secondpage : ListActivity
    {
    
    static readonly string[] countries = new String[] {
    "Otto","Rocky", "Karius og Baktus","R","Felt","DU ER DEN", "Cykelmyggen Egon", "LystSpil"
  };



        public HttpResponseMessage request;
     

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            HentdataAsync();
          

            



            // Create your application here

            ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.Listrow,countries);

            ListView.TextFilterEnabled = true;

            ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
               
                Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();
                String Listdata = (string)((TextView)args.View).Text;
                Console.WriteLine(Listdata);

          


                var activity = new Intent(this, typeof(Visbillet));
                activity.PutExtra("Myitem", Listdata);
                StartActivity(activity);

            };
        }

        public static async void HentdataAsync()
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetAsync("https://ticket.northeurope.cloudapp.azure.com/Customer/1");
                var content = await result.Content.ReadAsStringAsync();
                var resp = JsonConvert.DeserializeObject<Bookinger.ListBookinger>(content);

                Console.WriteLine("jep");

                Console.WriteLine(content);

                Console.WriteLine("jep");
                Console.WriteLine(resp.bookingID);
                Console.WriteLine(resp.customerID);
                Console.WriteLine(resp.date);
                Console.WriteLine(resp.seats);
                Console.WriteLine(resp.theater);




            }
            catch (Exception ex)
            {
            }



        }
    }

   


}
