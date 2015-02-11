using Xamarin.Forms;
using MeetupProject.Droid.Pages;
using MeetupProject.Droid.ViewModels;

namespace MeetupProject.Droid
{
	public class App : Application
	{
		public App ()
		{
			var page = new RaiseNotificationPage ();
			page.BindingContext = new RaiseNotificationViewModel ();

			MainPage = new NavigationPage(page);
		}

		public void ShowOrderDetailsPage(int orderId)
		{
			var page = new OrderDetailsPage ();

			MainPage.Navigation.PushAsync (page);
		}

		public void ShowOrderAcceptedPage(int orderId)
		{
			var page = new OrderAcceptedPage ();

			MainPage.Navigation.PushAsync (page);
		}

		public void ShowOrderRejectedPage(int orderId)
		{
			var page = new OrderRejectedPage ();

			MainPage.Navigation.PushAsync (page);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

