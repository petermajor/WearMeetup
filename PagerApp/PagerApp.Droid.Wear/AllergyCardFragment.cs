using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.Wearable.Views;

namespace PagerApp.Droid.Wear
{
	public class AllergyCardFragment : Fragment
	{
		string _allergyText;

		public static AllergyCardFragment Create(string allergyText)
		{
			var f = new AllergyCardFragment ();
			f._allergyText = allergyText;
			return f;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate (Resource.Layout.AllergyCardFragment, container, false);
		}

		public override void OnViewCreated (View view, Bundle savedInstanceState)
		{
			base.OnViewCreated (view, savedInstanceState);

			var label = view.FindViewById<TextView> (Resource.Id.allergy_text);
			label.Text = _allergyText;

			var cardScrollView = view.FindViewById<CardScrollView>(Resource.Id.card_scroll_view);
			cardScrollView.CardGravity = (int)GravityFlags.Bottom;
		}
	}
}