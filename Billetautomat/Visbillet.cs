
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Billetautomat
{
    [Activity(Label = "Visbillet")]
    public class Visbillet : Activity
    {


        public string forstilling { get; set; }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Billeten);


       
            forstilling = Intent.GetStringExtra("Myitem");

            Console.WriteLine(forstilling);

            TextView title = FindViewById<TextView>(Resource.Id.text5);
            TextView tid = FindViewById<TextView>(Resource.Id.text6);
            TextView Lokation = FindViewById<TextView>(Resource.Id.text7);
            ImageView image = FindViewById<ImageView>(Resource.Id.image);

          

            if (forstilling != null)
            {
                title.Text = forstilling;
            }
               
        }
    }
}