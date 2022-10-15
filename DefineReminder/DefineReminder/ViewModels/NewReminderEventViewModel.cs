using DefineReminder.Models;
using System;
using Xamarin.Forms;

namespace DefineReminder.ViewModels
{
    public class AddReminderEventViewModel : BaseViewModel
    {
        string text;
        DateTime eventDate;

        public AddReminderEventViewModel()
        {
            eventDate = DateTime.Now;

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public DateTime EventDate
        {
            get => eventDate;
            set => SetProperty(ref eventDate, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            ReminderEvent newReminderEvent = new ReminderEvent()
            {
                Text = Text,
                EventDate = eventDate.ToUniversalTime(),
            };

            await DataStore.AddItemAsync(newReminderEvent);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
