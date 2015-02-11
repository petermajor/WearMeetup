using Android.App;
using MeetupProject.Droid.ViewModels;
using Xamarin.Forms;

namespace MeetupProject.Droid.Notifications
{
	public class StackingNotification : NotificationBase
	{
		protected override Notification.Builder CreateBuilder(OrderViewModel order)
		{
			return new Notification.Builder (Forms.Context)
				.SetAutoCancel(true)
				.SetContentTitle ("New Order")
				.SetContentText (order.CustomerAddress)
				.SetDefaults (NotificationDefaults.All)
				.SetSmallIcon (Resource.Drawable.icon)
				.SetGroup ("MeetupProject.NewOrders");
		}
	}
}