using Adult.App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Adult.App.Views
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