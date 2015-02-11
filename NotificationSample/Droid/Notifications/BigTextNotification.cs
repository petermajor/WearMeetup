using Android.App;
using Android.Graphics;
using Android.Text;
using Android.Text.Style;
using MeetupProject.Droid.ViewModels;
using Xamarin.Forms;

namespace MeetupProject.Droid.Notifications
{
	public class BigTextNotification : NotificationBase
	{
		protected override Notification.Builder CreateBuilder(OrderViewModel order)
		{
			var s = new SpannableString (order.CustomerAddress + " - " + order.FoodAllergies);
			s.SetSpan (new StyleSpan (TypefaceStyle.Bold), 0, order.CustomerAddress.Length, SpanTypes.InclusiveInclusive);

			var textStyle = new Notification.BigTextStyle();
			textStyle.BigText (s);

			return new Notification.Builder (Forms.Context)
				.SetAutoCancel(true)
				.SetContentTitle ("New Order")
				.SetContentText (order.CustomerAddress)
				.SetDefaults (NotificationDefaults.All)
				.SetSmallIcon (Resource.Drawable.icon)
				.SetStyle (textStyle);

		}
	}
}