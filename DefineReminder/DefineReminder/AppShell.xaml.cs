using DefineReminder.ViewModels;
using DefineReminder.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DefineReminder
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(AddReminderEventPage), typeof(AddReminderEventPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
