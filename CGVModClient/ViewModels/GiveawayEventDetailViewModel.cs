﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CGVModClient.ViewModels;

public partial class GiveawayEventDetailViewModel : ObservableObject
{
    private CgvService service = new CgvService();

    [ObservableProperty]
    private bool isBusy = false;

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private string description;

    [ObservableProperty]
    public List<Area> areas;

    [ObservableProperty]
    public ObservableCollection<Theater> theaters;

    private GiveawayEventModel model;

    public GiveawayEventDetailViewModel(string value) 
    {
        Theaters = new ObservableCollection<Theater>();
        InitializeAsync(value);
    }

    private async void InitializeAsync(string eventIndex)
    {
        await LoadAsync(eventIndex);
    }

    public async Task LoadAsync(string eventIndex)
    {
        IsBusy = true;
        model = await service.Event.GetGiveawayEventModelAsync(eventIndex);
        Title = model.Title;
        Description = model.Contents;
        var theaterInfo = await service.Event.GetGiveawayTheaterInfoAsync(model.GiveawayIndex);
        Areas = theaterInfo.AreaList;
        foreach (var item in theaterInfo.TheaterList) {
            Theaters.Add(item);   
        }
        IsBusy = false;
    }

    [RelayCommand]
    private async Task SelectArea(string areaCode)
    {
        IsBusy = true;
        Theaters.Clear();
        var theaterInfo = await service.Event.GetGiveawayTheaterInfoAsync(model.GiveawayIndex, areaCode);
        foreach (var item in theaterInfo.TheaterList){
            Theaters.Add(item);
        }
        IsBusy= false;
    }
}
