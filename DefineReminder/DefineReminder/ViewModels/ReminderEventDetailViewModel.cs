using DefineReminder.Entities;
using DefineReminder.Models;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace DefineReminder.ViewModels
{
    [QueryProperty(nameof(ReminderEventId), nameof(ReminderEventId))]
    public class ReminderEventDetailViewModel : BaseViewModel
    {
        int reminderEventId;
        string name;
        string description;
        DateTime eventDate;

        public ReminderEventDetailViewModel()
        {
            DeleteCommand = new Command(OnDelete);
        }

        public int Id { get; set; }

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

        public int ReminderEventId
        {
            get
            {
                return reminderEventId;
            }
            set
            {
                reminderEventId = value;
                LoadReminderEventId(value);
            }
        }

        public Command DeleteCommand { get; }

        public async void LoadReminderEventId(int reminderEventId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(reminderEventId);
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                EventDate = item.EventDate;

                Title = $"Event: {Name}";
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnDelete()
        {
            bool wasDeleted = await DataStore.DeleteItemAsync(ReminderEventId);

            if (wasDeleted)
            {
                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
