using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Wearable.Activity;
using Android.Support.Wearable.Views;
using Android.Views;

namespace PagerApp.Droid.Wear
{
	[Activity (Label = "LateActionConfirmationActivity")]			
	public class LateActionConfirmationActivity : Activity, DelayedConfirmationView.IDelayedConfirmationListener
	{
		const int NumberOfSeconds = 5;

		DelayedConfirmationView _delayedConfirmationView;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.LateActionConfirmation);

			_delayedConfirmationView = FindViewById<DelayedConfirmationView>(Resource.Id.delayed_confirmation);

			StartConfirmationTimer();
		}

		void StartConfirmationTimer()
		{
			_delayedConfirmationView.SetTotalTimeMs (NumberOfSeconds * 1000);
			_delayedConfirmationView.SetListener (this);
			_delayedConfirmationView.Start();
		}

		public void OnTimerFinished(View p0)
		{
			StartConfirmationActivity (ConfirmationActivity.SuccessAnimation, GetString (Resource.String.late_notification_successful));
		}

		void StartConfirmationActivity(int animationType, string Message)
		{
			Intent confirmationActivity = new Intent (this, typeof(ConfirmationActivity))
				.SetFlags (ActivityFlags.NewTask | ActivityFlags.NoAnimation)
				.PutExtra (ConfirmationActivity.ExtraAnimationType, animationType)
				.PutExtra (ConfirmationActivity.ExtraMessage, Message);
			StartActivityForResult (confirmationActivity, 0);
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			Finish ();
		}

		public void OnTimerSelected(View p0)
		{
			_delayedConfirmationView.Reset ();
			Finish ();
		}
	}
}