namespace GreenGleam.App.Services
{
    public class StorageService
    {
        public static void SaveToStorage<Tvalue>(string key, Tvalue tvalue)
        {
            var serializedValue = JsonSerializer.Serialize(tvalue);
            Preferences.Default.Set(key, serializedValue);
        }
        public static TValue GetFromStorage<TValue>(string key, TValue tvalue)
        {
            if (Preferences.Default.ContainsKey(key))
            {
                var serializedValue = Preferences.Default.Get<string?>(key, null);

                if (!string.IsNullOrWhiteSpace(serializedValue))
                {
                    return JsonSerializer.Deserialize<TValue>(serializedValue)!;
                }
            }

            return tvalue;
        }
        public static void RemoveFromStorage(string key) => Preferences.Default.Remove(key);
    }
}