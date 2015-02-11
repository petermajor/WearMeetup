using System;

using Xamarin.Forms;

namespace MeetupProject.Droid.Pages
{
	public class OrderAcceptedPage : ContentPage
	{
		public OrderAcceptedPage ()
		{
			Content = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				Children = {
					new Label {
						XAlign = TextAlignment.Center,
						Text = "Order Accepted",
						TextColor = Color.Green,
						FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
					}
				}
			};
		}
	}
}


