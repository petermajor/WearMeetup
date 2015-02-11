using Android.App;
using Android.OS;
using Android.Views;

namespace PagerApp.Droid.Wear
{
	public class CustomFragment : Fragment
	{
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate (Resource.Layout.CustomFragment, container, false);
		}
	}
}