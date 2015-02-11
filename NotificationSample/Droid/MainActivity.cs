using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MeetupProject.Droid
{
	[Activity (Label = "MeetupProject.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsApplicationActivity
	{
		App app;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);

			Forms.Init (this, bundle);

			app = new App ();

			NavigateToPageIfRequired (Intent);

			LoadApplication (app);
		}

		protected override void OnNewIntent(Intent intent)
		{
			base.OnNewIntent (intent);

			NavigateToPageIfRequired (intent);
		}

		void NavigateToPageIfRequired(Intent intent)
		{
			if (!intent.HasExtra ("navigateTo"))
				return;
				
			switch(intent.GetStringExtra ("navigateTo"))
			{
				case "OrderDetailsPage": 
					app.ShowOrderDetailsPage (intent.GetIntExtra ("orderId", 0));
					break;
				case "OrderAcceptedPage": 
					app.ShowOrderAcceptedPage (intent.GetIntExtra ("orderId", 0));
					break;
				case "OrderRejectedPage": 
					app.ShowOrderRejectedPage (intent.GetIntExtra ("orderId", 0));
					break;
			}

			if (intent.HasExtra ("notificationId")) {
				var notificationId = intent.GetIntExtra ("notificationId", 0);
				var notificationManager = Forms.Context.GetSystemService(Context.NotificationService) as NotificationManager;
				notificationManager.Cancel(notificationId);
			}
		}
	}
}