using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CGVModClient.ViewModels;

internal partial class MainPageViewModel : ObservableObject
{
    [RelayCommand]
    private async Task GoGiveawayEventListPage() 
    {
        await Application.Current!.MainPage!.Navigation.PushAsync(new GiveawayEventsPage());
    }

    [RelayCommand]
    private async Task GoOpenNotification()
    {
        var database = new AppDatabase();
        await Application.Current!.MainPage!.Navigation.PushAsync(new OpenNotificationSettingPage(database));
    }

    [RelayCommand]
    private async Task GoAutoGiveawaySignup()
    {
        await Application.Current!.MainPage!.Navigation.PushAsync(new AutoGiveawayEventSignupPage());
    }
}
