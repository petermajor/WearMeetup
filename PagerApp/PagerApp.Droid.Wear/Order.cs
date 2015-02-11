using System.Collections.Generic;
using System.Linq;

namespace PagerApp.Droid.Wear
{
	public class Order
	{
		public string Id { get; set; }

		public string CustomerName { get; set; }

		public string CustomerAddress { get; set; }

		public string AllergyInfo { get; set; }

		public IEnumerable<string> Items { get; set; }

		public OrderStatus Status { get; set; }

		public Order()
		{
			Items = Enumerable.Empty<string> ();
		}
	}

	public enum OrderStatus
	{
		OK,
		DueSoon,
		Late,
	}
}