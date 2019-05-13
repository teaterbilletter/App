
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Linq;
using System.Linq.Expressions;
using Android.Graphics;
using Billetautomat.Services;
using Java.Lang;
using QRCoder;

namespace Billetautomat
{
    [Activity(Label = "Visbillet")]
    public class Visbillet : Activity
    {


    


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Billeten);



            var index = Intent.GetIntExtra("index",0);
            
            
            Console.WriteLine(index);
            TextView title = FindViewById<TextView>(Resource.Id.billettitle);
            TextView tid = FindViewById<TextView>(Resource.Id.time);
            TextView location = FindViewById<TextView>(Resource.Id.location);
            TextView seats = FindViewById<TextView>(Resource.Id.seats);
            ImageView image = FindViewById<ImageView>(Resource.Id.image);
            TextView price = FindViewById<TextView>(Resource.Id.price);
            StringBuilder seatbuilder = new StringBuilder();
            foreach (var seat in HttpService.bookings[index].seats)
            {
                seatbuilder.Append("\nRække: " + seat.row_number + " Sæde: " + seat.seat_number);
            }

            Booking book = HttpService.bookings[index];
            title.Text=book.show.title;
            tid.Text = book.date.ToString("MM/dd/yyyy HH:mm");
            location.Text = book.show.hall.theater.name;
            seats.Text = seatbuilder.ToString();
            price.Text = book.totalPrice.ToString()+"kr";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(seatbuilder.ToString(), QRCodeGenerator.ECCLevel.Q);

            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            Bitmap qrCodeImage = BitmapFactory.DecodeByteArray(qrCode.GetGraphic(20), 0, qrCode.GetGraphic(20).Length);
            image.SetImageBitmap(qrCodeImage);
        }
    }
}


    
    
          
 
     
