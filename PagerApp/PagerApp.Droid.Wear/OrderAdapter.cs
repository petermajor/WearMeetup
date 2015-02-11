using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Support.Wearable.Views;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace PagerApp.Droid.Wear
{
	public class OrderAdapter : FragmentGridPagerAdapter
	{
		readonly Order[] _orders = {
			new Order {
				Status = OrderStatus.Late,
				CustomerName = "Eric Rampy",
				CustomerAddress = "9472 Lind St, Desborough, NN14 2GH",
				AllergyInfo = "Gluten intolerant",
				Items = new[] { "Prawn crackers", "Salt and pepper squid", "Fried dumplings", "1/2 Crispy duck", "Lemon chicken", "Egg fried rice", "Spring rolls", "Banana fritters", "Extra plum sauce" } },
			new Order {
				Status = OrderStatus.DueSoon,
				CustomerName = "Marg Grasmick",
				CustomerAddress = "7457 Cowl St, Bargate Ward, SO14 3TY",
				Items = new[] { "Large pepperoni pizza" } },
			new Order {
				Status = OrderStatus.OK,
				CustomerName = "Laquita Hisaw",
				CustomerAddress = "20 Gloucester Pl, Desborough, Chirton Ward, NE29 7AD",
				Items = new[] { "Beef shawarma", "Cola" } },
		};

		readonly ColorDrawable ColorOk = new ColorDrawable(Color.LimeGreen);
		readonly ColorDrawable ColorDueSoon = new ColorDrawable (Color.Goldenrod);
		readonly ColorDrawable ColorLate = new ColorDrawable (Color.Tomato);

		readonly Context _context;
		readonly Resources _resources;

		public OrderAdapter (Context context, FragmentManager fm)
			: base (fm)
		{
			_context = context;
			_resources = _context.Resources;
		}

		public override int GetColumnCount (int row)
		{
			return string.IsNullOrEmpty(_orders[row].AllergyInfo) ? 3 : 4;
		}

		public override int RowCount {
			get {
				return _orders.Length;
			}
		}

		public override Fragment GetFragment (int row, int column)
		{
			var order = _orders [row];

			if (column == 0) {
				return CreateCard(Resource.String.title_customer_name, order.CustomerName);
			}

			if (string.IsNullOrWhiteSpace (order.AllergyInfo)) {
				column += 1;
			}

			if (column == 1) {
				return AllergyCardFragment.Create(order.AllergyInfo);
			}

			if (column == 2) {
				return CreateCard(Resource.String.title_items, FormatItems(order.Items));
			}

			return new LateActionFragment ();
		}

		public override Drawable GetBackgroundForPage(int row, int column)
		{
			var order = _orders [row];

			switch (order.Status) {
				case OrderStatus.OK:
					return ColorOk;
				case OrderStatus.DueSoon:
					return ColorDueSoon;
				case OrderStatus.Late:
					return ColorLate;
			}

			return new ColorDrawable ();
		}

		CardFragment CreateCard(int titleResource, string valueString)
		{
			var card = CardFragment.Create (_resources.GetString (titleResource), valueString);
			card.SetCardMarginBottom(_resources.GetDimensionPixelSize(Resource.Dimension.card_margin_bottom));
			return card;
		}

		string FormatItems(IEnumerable<string> items)
		{
			return string.Join ("\n", items);
		}
	}
}