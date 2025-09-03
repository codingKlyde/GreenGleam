namespace GreenGleam.App.Services
{
    public static class MauiInterop
    {
        public static async Task AlertAsync(string? message, string title = "Alert") => await App.Current.Windows[0].Page.DisplayAlert(title, message, "OK");
        public static async Task<bool> ConfirmAsync(string message, string title = "Confirm") => await App.Current.Windows[0].Page.DisplayAlert(title, message, "Yes", "No");
    }
}