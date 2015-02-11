using Xamarin.Forms;

namespace MeetupProject.Droid.Pages
{
	public class RaiseNotificationPage : ContentPage
	{
		public RaiseNotificationPage ()
		{
			Content = new StackLayout {
				Children = {
					CreateButton("Simple", "RaiseSimple"),
					CreateButton("Big Text Style", "RaiseBigTextStyle"),
					CreateButton("Pages", "RaisePages"),
					CreateButton("Stacking", "RaiseStacking"),
				}
			};
		}

		Button CreateButton(string text, string command)
		{
			var button = new Button { Text = text };
			button.SetBinding(Button.CommandProperty, new Binding(command));

			return button;
		}
	}
}


