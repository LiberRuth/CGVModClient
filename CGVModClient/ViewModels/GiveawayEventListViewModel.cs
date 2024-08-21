using CGVModClient.Data;
using CGVModClient.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CGVModClient.ViewModels;

public partial class GiveawayEventsViewModel : ObservableObject
{
    private readonly CgvService service = new CgvService();

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string eventState = "진행중인 경품 이벤트 _개";

    [ObservableProperty]
    private GiveawayEvent? selectedItem;

    [ObservableProperty]
    private ObservableCollection<GiveawayEvent> giveawayEvents;

    public GiveawayEventsViewModel()
    {
        GiveawayEvents = new ObservableCollection<GiveawayEvent>();
        InitializeAsync();
    }

    private async void InitializeAsync()
    {
        await LoadAsync();
    }

    public async Task LoadAsync()
    {
        IsBusy = true;
        var arr = await service.Event.GetGiveawayEventsAsync();
        foreach (var item in arr)
        {
            GiveawayEvents.Add(new GiveawayEvent
            {
                Title = item.Title,
                Period = item.Period,
                DDay = item.DDay,
                EventIndex = item.EventIndex
            });
        }
        SetEventState(GiveawayEvents.Count);
        IsBusy = false;
    }

    public void SetEventState(int count)
    {
        EventState = $"진행중인 경품 이벤트 {count}개";
    }

    [RelayCommand]
    private async Task CollectioItemSelected()
    {
        if (SelectedItem != null)
        {
            await Application.Current!.MainPage!.Navigation.PushAsync(new GiveawayEventDetailPage(SelectedItem!.EventIndex));
            //Debug.WriteLine(SelectedItem!.EventIndex);
            SelectedItem = null;
        }
    }
}