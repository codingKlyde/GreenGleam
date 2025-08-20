namespace GreenGleam.App.Services
{
    public class AuthService
    {
        private const string UserDataKey = "user-data";
        public LoggedInUserDto? LoggedInUser {  get; set; }
        public bool IsLoggedIn { get; private set; }

        public AuthService()
        {
            var userData = StorageService.GetFromStorage<LoggedInUserDto?>(UserDataKey, null);

            if (userData != null)
            {
                LoggedInUser = userData;
                IsLoggedIn = true;
            }
        }

        public void Login(LoggedInUserDto loggedInUserDto)
        {
            StorageService.SaveToStorage(UserDataKey, loggedInUserDto);
            LoggedInUser = loggedInUserDto;
            IsLoggedIn = true;
        }
        public void Logout()
        {
            LoggedInUser = null;
            IsLoggedIn = false;
            StorageService.RemoveFromStorage(UserDataKey);
        }
    }
}