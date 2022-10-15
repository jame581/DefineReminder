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
                Name = Name,
                Description = Description,
                EventDate = eventDate.ToUniversalTime(),
            };

            await DataStore.AddItemAsync(newReminderEvent);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
