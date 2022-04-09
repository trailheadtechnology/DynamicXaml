using DynamicXamlDemo.ViewModels;
using Xamarin.Forms;

namespace DynamicXamlDemo.Views
{
    public partial class BrowsePage : ContentPage
    {
        
        public BrowsePage()
        {
            InitializeComponent();
            BindingContext = new BrowseViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (vm != null)
            {
                vm.ContentPresenter = DynamicContentPresenter;
            }
        }

        BrowseViewModel vm => BindingContext as BrowseViewModel;

        //protected override void OnBindingContextChanged()
        //{
        //    base.OnBindingContextChanged();

        //    if (vm != null)
        //    {
        //        vm.ContentPresenter = DynamicContentPresenter;
        //    }
        //}
    }
}