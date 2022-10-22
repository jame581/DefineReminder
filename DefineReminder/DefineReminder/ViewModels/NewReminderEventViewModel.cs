using DefineReminder.Models;
using System;
using Xamarin.Forms;

namespace DefineReminder.ViewModels
{
    public class AddReminderEventViewModel : BaseViewModel
    {
        string name;
        string description;
        DateTime eventDate;
        TimeSpan eventTime;

        public AddReminderEventViewModel()
        {
            eventDate = DateTime.Now;
            eventTime = TimeSpan.FromSeconds(0);

            Title = "Add Reminder Event";

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public DateTime EventDate
        {
            get => eventDate;
            set => SetProperty(ref eventDate, value);
        }
        public TimeSpan EventTime
        {
            get => eventTime;
            set => SetProperty(ref eventTime, value);
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
            DateTime dateTime = new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, eventTime.Hours, eventTime.Minutes, eventTime.Seconds);

            ReminderEvent newReminderEvent = new ReminderEvent()
            {
                Name = Name,
                Description = Description,
                EventDate = dateTime,
            };

            await DataStore.AddItemAsync(newReminderEvent);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
