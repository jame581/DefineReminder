using DefineReminder.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefineReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddReminderEventPage : ContentPage
    {
        public AddReminderEventPage()
        {
            InitializeComponent();
            BindingContext = new AddReminderEventViewModel();
        }
    }
}