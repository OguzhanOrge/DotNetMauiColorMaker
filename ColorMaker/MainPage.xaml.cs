using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
namespace ColorMaker
{
	public partial class MainPage : ContentPage
	{
		bool IsRandom;
		string hexValue = string.Empty;
		public MainPage()
		{
			InitializeComponent();
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{

		}

		private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			if (IsRandom == false)
			{
				var red = sldRed.Value;
				var green = sldGreen.Value;
				var blue = sldBlue.Value;

				Color color = Color.FromRgb(red, green, blue);
				SetColor(color);
			}
		}
		private void SetColor(Color color)
		{
			btnRandom.Background = color;
			Container.Background = color;
			hexValue = color.ToHex();
			lblHex.Text = "Hex Value :" + color.ToHex();
			lblHex.Background = color;
		}
		private void btnRandom_Click(object sender, EventArgs e)
		{
			IsRandom = true;
			var random = new Random();
			Color color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
			SetColor(color);
			sldBlue.Value = color.Blue;
			sldRed.Value = color.Red;
			sldGreen.Value = color.Green;
			IsRandom = false;
		}

		private async void lblHex_Clicked(object sender, EventArgs e)
		{
			await Clipboard.SetTextAsync(hexValue);
			var toast = Toast.Make("Color copied",ToastDuration.Short,12);
			await toast.Show();
		}
	}
}

