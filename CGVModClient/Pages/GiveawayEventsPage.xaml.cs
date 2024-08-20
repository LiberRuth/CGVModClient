namespace CGVModClient.Pages;

public partial class GiveawayEventsPage : ContentPage
{
    public GiveawayEventsPage()
	{
		InitializeComponent();
        BindingContext = new GiveawayEventsViewModel();
	}
}