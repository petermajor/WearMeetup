using Android.App;
using MeetupProject.Droid.ViewModels;
using Xamarin.Forms;

namespace MeetupProject.Droid.Notifications
{
	public class WithPagesNotification : NotificationBase
	{
		protected override Notification.Builder CreateBuilder(OrderViewModel order)
		{
			var textStyle = new Notification.BigTextStyle();
			textStyle.BigText (order.FoodAllergies);
			textStyle.SetBigContentTitle ("Food allergies");

			var secondPage = new Notification.Builder(Forms.Context)
				.SetStyle(textStyle)
				.Build();

			return new Notification.Builder (Forms.Context)
				.SetAutoCancel(true)
				.SetContentTitle ("New Order")
				.SetContentText (order.CustomerAddress)
				.SetDefaults (NotificationDefaults.All)
				.SetSmallIcon (Resource.Drawable.icon)
				.Extend (new Notification.WearableExtender().AddPage(secondPage));
		}
	}
}