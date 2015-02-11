using System;

using Xamarin.Forms;

namespace MeetupProject.Droid.Pages
{
	public class OrderDetailsPage : ContentPage
	{
		public OrderDetailsPage ()
		{
			Content = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				Children = {
					new Label {
						XAlign = TextAlignment.Center,
						Text = "Order Details",
						TextColor = Color.White,
						FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
					}
				}
			};
		}
	}
}


