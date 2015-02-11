using Android.App;
using Android.Content;
using MeetupProject.Droid.ViewModels;
using Xamarin.Forms;

namespace MeetupProject.Droid.Notifications
{
	public abstract class NotificationBase
	{
		public void Raise(OrderViewModel order)
		{
			var pendingOrderDetailsIntent = CreateOrderDetailsIntent(order);

			var acceptPendingIntent = CreateAcceptIntent (order);

			var rejectPendingIntent = CreateRejectIntent (order);

			var builder = CreateBuilder (order)
				.SetContentIntent (pendingOrderDetailsIntent)
				.AddAction (Resource.Drawable.notification_accept, "Accept", acceptPendingIntent)
				.AddAction (Resource.Drawable.notification_reject, "Reject", rejectPendingIntent);

			var notification = builder.Build();

			var notificationManager = Forms.Context.GetSystemService(Context.NotificationService) as NotificationManager;

			notificationManager.Notify(order.Id, notification);
		}

		protected abstract Notification.Builder CreateBuilder(OrderViewModel order);

		static PendingIntent CreateOrderDetailsIntent(OrderViewModel order)
		{
			var intent = new Intent (Forms.Context, typeof(MainActivity));
			intent.PutExtra("navigateTo", "OrderDetailsPage");
			intent.PutExtra("orderId", order.Id);
			intent.PutExtra("notificationId", order.Id);

			return PendingIntent.GetActivity (Forms.Context, 0, intent, PendingIntentFlags.OneShot);
		}

		static PendingIntent CreateAcceptIntent(OrderViewModel order)
		{
			var intent = new Intent (Forms.Context, typeof(MainActivity));
			intent.PutExtra("navigateTo", "OrderAcceptedPage");
			intent.PutExtra("orderId", order.Id);
			intent.PutExtra("notificationId", order.Id);

			return PendingIntent.GetActivity (Forms.Context, 1, intent, PendingIntentFlags.OneShot);
		}

		static PendingIntent CreateRejectIntent(OrderViewModel order)
		{
			var intent = new Intent (Forms.Context, typeof(MainActivity));
			intent.PutExtra("navigateTo", "OrderRejectedPage");
			intent.PutExtra("orderId", order.Id);
			intent.PutExtra("notificationId", order.Id);

			return PendingIntent.GetActivity (Forms.Context, 2, intent, PendingIntentFlags.OneShot);
		}
	}
}