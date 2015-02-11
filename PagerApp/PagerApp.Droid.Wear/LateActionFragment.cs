using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Content;

namespace PagerApp.Droid.Wear
{
	public class LateActionFragment : Fragment
	{
		Button button;

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate (Resource.Layout.LateActionFragment, container, false);
			button = (Button) view.FindViewById(Resource.Id.late_button);
			button.Click+= delegate {
				StartActionConfirmActivity();
			};
			return view;
		}

		void StartActionConfirmActivity()
		{
			Intent confirmationActivity = new Intent (Activity, typeof(LateActionConfirmationActivity));
			StartActivity (confirmationActivity);
		}
	}
}