using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DynamicXamlDemo.ViewModels
{
    public class BrowseViewModel : BaseViewModel
    {
        public BrowseViewModel()
        {
            Title = "Browse";
        }

        string xamlShell = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><ContentView xmlns=\"http://xamarin.com/schemas/2014/forms\" xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\" xmlns:d=\"http://xamarin.com/schemas/2014/forms/design\" xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" mc:Ignorable=\"d\" x:Class=\"DynamicXamlDemo.XamlShell\"><ContentView.Content><StackLayout>{{content}}</StackLayout></ContentView.Content></ContentView>";

        public void LoadData()
        {
            // Get the Xaml and put inside the shell
            var baseDefinition = Preferences.Get(nameof(XamlDefinition), "");
            XamlDefinition = xamlShell.Replace("{{content}}", baseDefinition);
            var contentView = new ContentView().LoadFromXaml(XamlDefinition);

            // TODO: data binding
            // Set DataBinding
            // contentView.BindingContext = new { ChildrenSource = children };

            // Set the content on the view
            ContentPresenter?.Children?.Clear();
            ContentPresenter?.Children?.Add(contentView);
        }

        string xamlDefinition;

        public string XamlDefinition
        {
            get => xamlDefinition;
            set => SetProperty(ref xamlDefinition, value);
        }

        StackLayout contentPresenter;

        public StackLayout ContentPresenter
        {
            get => contentPresenter;
            set
            {
                SetProperty(ref contentPresenter, value);

                LoadData();
            }
        }

    }
}