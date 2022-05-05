using System;
using System.ComponentModel;
using DynamicXamlDemo.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DynamicXamlDemo.Views
{
    public partial class DefinitionPage
    {
        DefinitionViewModel vm => BindingContext as DefinitionViewModel;
        
        public DefinitionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm?.LoadData();
        }
    }
}