using Android.App;
using Android.OS;
using Android.Support.Wearable.Views;

namespace PagerApp.Droid.Wear
{
	[Activity (Label = "PagerApp.Droid.Wear", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		GridViewPager _pager;
		OrderAdapter _adapter;
		DotsPageIndicator _dotsPageIndicator;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			_pager = FindViewById<GridViewPager> (Resource.Id.pager);
			_adapter = new OrderAdapter (this, FragmentManager);
			_pager.Adapter = _adapter;

			_dotsPageIndicator = FindViewById<DotsPageIndicator>(Resource.Id.page_indicator);
			_dotsPageIndicator.SetPager(_pager);		
		}
	}
}