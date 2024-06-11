using ExemploHTTP.ViewModel;

namespace ExemploHTTP.View;

public partial class PostagemView : ContentPage
{
	public PostagemView()
	{
		BindingContext = new PostagemViewModel();
		InitializeComponent();
	}
}