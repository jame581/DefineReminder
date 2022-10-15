using DefineReminder.Models;
using DefineReminder.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DefineReminder.ViewModels
{
    public class EventsViewModel : BaseViewModel
    {
        private ReminderEvent selectedEvent;
        public ObservableCollection<ReminderEvent> ReminderEvents { get; }
        public Command LoadEventsCommand { get; }
        public Command AddEventCommand { get; }
        public Command<ReminderEvent> EventTapped { get; }

        public ReminderEvent SelectedItem
        {
            get => selectedEvent;
            set
            {
                SetProperty(ref selectedEvent, value);
                OnEventSelected(value);
            }
        }

        public EventsViewModel()
        {
            Title = "Browse Events";
            ReminderEvents = new ObservableCollection<ReminderEvent>();

            LoadEventsCommand = new Command(async () => await ExecuteLoadEventsCommand());

            EventTapped = new Command<ReminderEvent>(OnEventSelected);

            AddEventCommand = new Command(OnAddEvent);
        }

        async Task ExecuteLoadEventsCommand()
        {
            IsBusy = true;

            try
            {
                ReminderEvents.Clear();
                var events = await DataStore.GetItemsAsync(true);
                foreach (var item in events)
                {
                    ReminderEvents.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddEvent(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnEventSelected(ReminderEvent reminderEvent)
        {
            if (reminderEvent == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={reminderEvent.Id}");
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
    }
}
