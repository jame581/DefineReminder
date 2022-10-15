using DefineReminder.Models;
using DefineReminder.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DefineReminder.ViewModels
{
    public class ReminderEventsViewModel : BaseViewModel
    {
        private ReminderEvent selectedReminderEvent;
        public ObservableCollection<ReminderEvent> ReminderEvents { get; }
        public Command LoadReminderEventsCommand { get; }
        public Command AddReminderEventCommand { get; }
        public Command<ReminderEvent> ReminderEventTapped { get; }

        public ReminderEvent SelectedReminderEvent
        {
            get => selectedReminderEvent;
            set
            {
                SetProperty(ref selectedReminderEvent, value);
                OnEventSelected(value);
            }
        }

        public ReminderEventsViewModel()
        {
            Title = "Browse Events";
            ReminderEvents = new ObservableCollection<ReminderEvent>();

            LoadReminderEventsCommand = new Command(async () => await ExecuteLoadEventsCommand());

            ReminderEventTapped = new Command<ReminderEvent>(OnEventSelected);

            AddReminderEventCommand = new Command(OnAddEvent);
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
            await Shell.Current.GoToAsync(nameof(AddReminderEventPage));
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
            SelectedReminderEvent = null;
        }
    }
}
