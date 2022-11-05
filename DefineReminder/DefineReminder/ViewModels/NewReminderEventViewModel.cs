using DefineReminder.Entities;
using DefineReminder.Models;
using DefineReminder.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DefineReminder.ViewModels
{
    public class AddReminderEventViewModel : BaseViewModel
    {
        string name;
        string description;
        DateTime eventDate;
        TimeSpan eventTime;
        EventIconType selectedIconType;
        bool sendNotification;

        INotificationManager notificationManager;

        public AddReminderEventViewModel()
        {
            eventDate = DateTime.Now;
            eventTime = TimeSpan.FromSeconds(0);

            Title = "Add Reminder Event";

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            notificationManager = DependencyService.Get<INotificationManager>();

            InitializeIconSelection();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(description);
        }
        
        public List<EventIconType> IconTypes { get; set; }

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

        public EventIconType SelectedIconType
        {
            get => selectedIconType;
            set => SetProperty(ref selectedIconType, value);
        }
        
        public bool SendNotification
        {
            get => sendNotification;
            set => SetProperty(ref sendNotification, value);
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
                IconType = SelectedIconType == null ? IconType.Default : SelectedIconType.IconType, 
            };

            await DataStore.AddItemAsync(newReminderEvent);

            string title = $"Event {Name}";
            string message = $"Your scheduled event just started!";
            notificationManager.SendNotification(title, message, dateTime);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        void InitializeIconSelection()
        {
            IconTypes = new List<EventIconType>();

            foreach (IconType iconType in Enum.GetValues(typeof(IconType)))
            {
                IconTypes.Add(new EventIconType { IconType = iconType, Name = iconType.ToString() });
            }
        }
    }
}
