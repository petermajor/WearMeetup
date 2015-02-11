using System;

using Xamarin.Forms;

namespace MeetupProject.Droid.Pages
{
	public class OrderRejectedPage : ContentPage
	{
		public OrderRejectedPage ()
		{
			Content = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				Children = {
					new Label {
						XAlign = TextAlignment.Center,
						Text = "Order Rejected",
						TextColor = Color.Red,
						FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
					}
				}
			};
		}
	}
}


