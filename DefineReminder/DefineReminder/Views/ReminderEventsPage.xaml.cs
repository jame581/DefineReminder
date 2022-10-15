using DefineReminder.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefineReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderEventsPage : ContentPage
    {
        EventsViewModel viewModel;

        public ReminderEventsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new EventsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}