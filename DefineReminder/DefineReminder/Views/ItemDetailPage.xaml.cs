using DefineReminder.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DefineReminder.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}