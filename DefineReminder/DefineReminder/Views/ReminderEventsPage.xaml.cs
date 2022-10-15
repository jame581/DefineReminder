using DefineReminder.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefineReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderEventsPage : ContentPage
    {
        ReminderEventsViewModel viewModel;

        public ReminderEventsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ReminderEventsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}