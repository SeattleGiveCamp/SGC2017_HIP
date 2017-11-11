// Helpers/Settings.cs This file was automatically added when you installed the Settings Plugin. If you are not using a PCL then comment this file back in to use it.
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Text.RegularExpressions;

namespace HIP.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

        #region Setting Constants

        private const string FirstNameKey = "firstname_key";
        private static readonly string FirstNameDefault = string.Empty;

        private const string LastNameKey = "lastname_key";
        private static readonly string LastNameDefault = string.Empty;

        private const string EmailKey = "email_key";
        private static readonly string EmailDefault = string.Empty;

        #endregion


        public static string FirstName
		{
			get => AppSettings.GetValueOrDefault(FirstNameKey, FirstNameDefault);
			
			set => AppSettings.AddOrUpdateValue(FirstNameKey, value);
		}

        public static string LastName
        {
            get => AppSettings.GetValueOrDefault(LastNameKey, LastNameDefault);

            set => AppSettings.AddOrUpdateValue(LastNameKey, value);
        }

        public static string Email
        {
            get => AppSettings.GetValueOrDefault(EmailKey, EmailDefault);

            set => AppSettings.AddOrUpdateValue(EmailKey, value);
        }


        const string IllegalCharacters = "[|\\?*<\":>/']";

        static string GetFavKey(string id)
        {
            id = "fav_" + id.Replace(" ", string.Empty).ToLowerInvariant();

            return Regex.Replace(id, IllegalCharacters, string.Empty).Replace(@"\", string.Empty);
        }

        public static bool IsFavorite(string key) =>
            AppSettings.GetValueOrDefault(GetFavKey(key), false);

        public static bool SetFavorite(string key, bool isFav) =>
            AppSettings.AddOrUpdateValue(GetFavKey(key), isFav);


    }
}