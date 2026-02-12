// SecondPage.xaml.cs

namespace MauiWrongBindTest;

public partial class SecondPage : ContentPage
{
	public SecondPage()
	{
		InitializeComponent();
		BindingContext = new MyViewModel();
	}
}
