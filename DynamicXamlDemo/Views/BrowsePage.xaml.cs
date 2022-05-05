using DynamicXamlDemo.ViewModels;
using Xamarin.Forms;

namespace DynamicXamlDemo.Views
{
    public partial class BrowsePage
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

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            vm.SaveData();
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