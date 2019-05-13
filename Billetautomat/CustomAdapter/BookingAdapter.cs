using Android.Content;
using Android.Views;
using Android.Widget;
using Billetautomat.Services;
using System.Collections.Generic;
using System.Threading;
using Java.IO;

namespace Billetautomat.CustomAdapter
{
    class BookingAdapter : ArrayAdapter<Booking>, AdapterView.IOnItemClickListener
    {
        private readonly Context _context;
        private readonly int _resource;
        private readonly List<Booking> _bookings;
        private ListView _listView;
        private TextView title;
        private TextView date;
        private TextView theater;


        public BookingAdapter(Context context, int resource, List<Booking> bookings, ListView listView) : base(context, resource, bookings)
        {
            _context = context;
            _resource = resource;
            _bookings = bookings;
            _listView = listView;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView ?? LayoutInflater.From(_context).Inflate(_resource, null);


            title = view.FindViewById<TextView>(Resource.Id.showtitle);
            date = view.FindViewById<TextView>(Resource.Id.date);
            theater = view.FindViewById<TextView>(Resource.Id.theater);
            ImageView imgurlView = view.FindViewById<ImageView>(Resource.Id.imageurl);
            Booking book = GetItem(position);



            title.Text = book.show.title;
            date.Text = "Den. " + book.date.ToString("MM/dd/yyyy HH:mm");
            theater.Text = book.show.hall.theater.name;
            var imageBitmap = HttpService.ConvertToBitmapfromURL(book.show.imgUrl);
            imgurlView.SetImageBitmap(imageBitmap);


            _listView.OnItemClickListener = this;

            return view;
        }

        public async void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            Toast.MakeText(_context, "Henter data", ToastLength.Long).Show();
            var resp = await HttpService.GetBookingDetails(GetItem(position).bookingID,position);
            if (resp.Equals("Hentet"))
            {
                Toast.MakeText(_context, resp, ToastLength.Long).Show();
                var activity = new Intent(_context, typeof(Visbillet));
                activity.PutExtra("index", position);
                _context.StartActivity(activity);
            }
            Toast.MakeText(_context, resp, ToastLength.Long).Show();

        }


    }
}