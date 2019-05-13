using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Billetautomat.Services;
using System;

namespace Billetautomat
{


    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText brugernavn;
        EditText password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);


            brugernavn = FindViewById<EditText>(Resource.Id.brugernavn);
            password = FindViewById<EditText>(Resource.Id.password);

            var button = FindViewById<Button>(Resource.Id.submitlogin);



            button.Click += OnLogonButtonClick;



        }



        async public void OnLogonButtonClick(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Forsøger at logge ind", ToastLength.Long).Show();
            if (brugernavn.Text == "" || password.Text == "")
            {

                Toast.MakeText(this, "Du mangler at skrive Brugernavn og Password", ToastLength.Long).Show();
                return;
            }
            
            var response = await HttpService.GetLoginResponse(brugernavn.Text, password.Text);

            if (response.Equals("Success"))
            {
                Toast.MakeText(this, "Logget ind, henter data", ToastLength.Long).Show();
                var hentbooks = await HttpService.GetCustomerBookings();
                if (hentbooks.Equals("Hentet"))
                {
                    var intent = new Intent(this, typeof(BookingsListActivity));
                    intent.SetFlags(ActivityFlags.NewTask);
                    StartActivity(intent);
                    Finish();
                }
                Toast.MakeText(this, hentbooks, ToastLength.Long).Show();
                return;

            }
            else
            {

                Toast.MakeText(this, response, ToastLength.Long).Show();
            }

        }
    }

}







