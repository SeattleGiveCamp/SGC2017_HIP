# Mobile App Guidelines
A quick set of guidelines to follow when contributing to the mobile apps.

### Install Latest Android SDK
All Android apps use the latest API 25 SDK and is required to get started. See the [guide here to get started](https://blog.xamarin.com/mastering-android-support-libraries/).

### Plugins
Plugins for Xamarin help simplify the APIs for platform specific APIs into a common API. Checkout the full list at: [Plugins for Xamarin](https://github.com/xamarin/XamarinComponents#popular-plugins)

### MVVM Helpers
This is a helpful library that James created to simplify Xamarin.Forms development. Check it out at [GitHub-MvvmHelpers](https://github.com/jamesmontemagno/mvvm-helpers)

### Xamarin Documentation:
* [Xamarin.Forms](https://developer.xamarin.com/guides/xamarin-forms/)
* [iOS](https://developer.xamarin.com/guides/ios/)
* [Android](https://developer.xamarin.com/guides/android/)

### Icons/Images
All image resources are placed in the platform specific folders for iOS/Android/UWP.

1. Toolbar images should start with toolbar_NAME.png
2. Tab images should start with tab_NAME.png
3. All others: image_NAME.png
4. UWP images should be places in the Assets folder.

For icon generation use the platform specific versions:
* Android: https://romannurik.github.io/AndroidAssetStudio/ and https://materialdesignicons.com/
* iOS: https://icons8.com/icon/set/search/ios7
* UWP: http://modernuiicons.com/

### Main Navigation if Tabs (Xamarin.Forms)
This application uses Tabs for the main navigation.
* Android/UWP has a root Navigation page and the tabs are wrapped inside of it. Navigation NEVER occurs inside of a tab, always to a new page.
* iOS has the TabbedPage as its root and sub navigation pages


### Modal Pages
Modal pages should ALWAYS be wrapped in a NavigationPage.

* Android/UWP -> On the top right place the close toolbar icon and when pressed pop the modal page
* iOS -> Use the word *Close* and then perform the same action 






