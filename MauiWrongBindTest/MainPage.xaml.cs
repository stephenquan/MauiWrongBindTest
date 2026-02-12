// MainPage.xaml.cs

namespace MauiWrongBindTest;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MyViewModel();
	}

	async void OnGoToSecondPage(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(SecondPage));
	}
}
