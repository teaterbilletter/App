
using Android.App;
using Android.OS;
using Android.Widget;
using Billetautomat.CustomAdapter;
using Billetautomat.Services;
using Xamarin.Essentials;

namespace Billetautomat
{


    [Activity(Label = "BookingsListActivity")]
    public class BookingsListActivity: Activity
    {
        
        
        private ListView lw;
        private TextView tw;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.Secondpage);
            tw = FindViewById<TextView>(Resource.Id.infotext);
            string name = Preferences.Get("name", "ok");
            tw.Text = $"Hej {name}, her er en liste over dine bestillinger. \nKlik for yderligere Information";
            lw = FindViewById<ListView>(Resource.Id.ListView);
            

            BookingAdapter b = new BookingAdapter(this, Resource.Layout.Listrow, HttpService.bookings,lw);
            lw.Adapter = b;
        }



    }


}
