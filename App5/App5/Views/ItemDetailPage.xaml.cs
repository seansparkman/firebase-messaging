using App5.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace App5.Views
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