using ChristmasProject.Applicazione.Code.ViewModel;

namespace ChristmasProject.Applicazione.Design;

public partial class test : ContentPage
{
	public test(CardViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}