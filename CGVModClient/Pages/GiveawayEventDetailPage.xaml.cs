namespace CGVModClient.Pages;

public partial class GiveawayEventDetailPage : ContentPage
{
    public GiveawayEventDetailPage(string eventIndex) {
        InitializeComponent();
        BindingContext = new GiveawayEventDetailViewModel(eventIndex);
    }
}