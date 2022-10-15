using DefineReminder.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DefineReminder.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderEventDetailPage : ContentPage
    {
        public ReminderEventDetailPage()
        {
            InitializeComponent();
            BindingContext = new ReminderEventDetailViewModel();
        }
    }
}