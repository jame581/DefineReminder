using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DefineReminder.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenGitHubCommand = new Command(async () => await Browser.OpenAsync("https://github.com/jame581/define_reminder"));
            OpenPortfolioCommand = new Command(async () => await Browser.OpenAsync("https://jame581.azurewebsites.net/"));
            OpenBuyMeACoffeeCommand = new Command(async () => await Browser.OpenAsync("https://www.buymeacoffee.com/jame581"));
        }

        public ICommand OpenGitHubCommand { get; }
        public ICommand OpenPortfolioCommand { get; }
        public ICommand OpenBuyMeACoffeeCommand { get; }
    }
}