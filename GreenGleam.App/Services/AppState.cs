namespace GreenGleam.App.Services
{
    public partial class AppState : ObservableObject
    {
        [ObservableProperty][NotifyPropertyChangedFor(nameof(IsNotBusy))] bool isBusy;
        public bool IsNotBusy => !IsBusy;

        public void ShowLoader() => IsBusy = true;
        public void HideLoader() => IsBusy = false;
    }
}