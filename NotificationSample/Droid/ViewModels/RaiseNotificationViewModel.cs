using Xamarin.Forms;
using MeetupProject.Droid.Notifications;

namespace MeetupProject.Droid.ViewModels
{
	public class RaiseNotificationViewModel
	{
		int lastOrderId = 100000;

		public Command RaiseSimple { get; private set; }
		public Command RaiseBigTextStyle { get; private set; }
		public Command RaisePages { get; private set; }
		public Command RaiseStacking { get; private set; }

		public RaiseNotificationViewModel()
		{
			RaiseSimple = new Command (RaiseNotification<SimpleNotification>);
			RaiseBigTextStyle = new Command (RaiseNotification<BigTextNotification>);
			RaisePages = new Command (RaiseNotification<WithPagesNotification>);
			RaiseStacking = new Command (RaiseNotification<StackingNotification>);
		}

		void RaiseNotification<T>() where T :  NotificationBase, new()
		{
			var order = CreateOrder ();

			var notification = new T ();
			notification.Raise (order);
		}

		OrderViewModel CreateOrder()
		{
			return new OrderViewModel
			{
				Id = ++lastOrderId,
				CustomerName = "John Doe",
				CustomerAddress = "30 Osterley View, London, W7 3LL",
				FoodAllergies = "I'm allergic to nuts. I'm also gluten intolerant. Oh and lactose intolerant too.",
			};
		}
	}
}
