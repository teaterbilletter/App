using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using System.Net.Http;
using System.Threading.Tasks;
using System.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using static Android.Content.ClipData;
using System.Text;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;

namespace Billetautomat
{


    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        public HttpResponseMessage request;
        public HttpClient _client;
        EditText email;
        EditText password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            email = FindViewById<EditText>(Resource.Id.email);
            password = FindViewById<EditText>(Resource.Id.password);

            var button = FindViewById<Button>(Resource.Id.button1);



            button.Click += logonButtonClick;

            var activity = new Intent(this, typeof(Secondpage));
            StartActivity(activity);

        }



        async public void logonButtonClick(object sender, EventArgs e)
        {
            if (email.Text == "" || password.Text == "")
            {

                Toast.MakeText(this, "Du mangler at skrive Email og Password", ToastLength.Long).Show();
            }
            else
            {

                HttpClient client = new HttpClient();

                try
                {

                    var result1 = await client.PostAsync("https://ticket.northeurope.cloudapp.azure.com/Login",
                    new StringContent(JsonConvert.SerializeObject(new User() { name = email.Text, password = password.Text }), Encoding.UTF8, "application/json"));

                    Console.WriteLine(result1);
                    if (result1.StatusCode == HttpStatusCode.OK)
                    {
                        var content1 = await result1.Content.ReadAsStringAsync();
                        var resp1 = JsonConvert.DeserializeObject<EmptyClass.Login>(content1);

                        Preferences.Set("token", resp1.token);
                        var activity = new Intent(this, typeof(Secondpage));
                        StartActivity(activity);
                        Console.WriteLine("nyside");

                    }

            
                    else
                    {

                        Toast.MakeText(this, "Brugernavn eller Password er forkert", ToastLength.Long).Show();
                    }
                    /* var myValue = Preferences.Get("token", "ok");
                      httpClient.DefaultRequestHeaders.Authorization
                           = new AuthenticationHeaderValue("Bearer", myValue);

      */

                }
                catch (Exception ex)
                {


                }


            }
        }
    }

}







