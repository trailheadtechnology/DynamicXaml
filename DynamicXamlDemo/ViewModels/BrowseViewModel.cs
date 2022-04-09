using Newtonsoft.Json;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Dynamic;
using Xamarin.Forms.Xaml;

namespace DynamicXamlDemo.ViewModels
{
    public class BrowseViewModel : BaseViewModel
    {
        public ObservableDictionary<string, object> Values { get; set; }

        public BrowseViewModel()
        {
            Title = "Browse";
            Values = new ObservableDictionary<string, object>();
        }

        string xamlShell = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><ContentView xmlns=\"http://xamarin.com/schemas/2014/forms\" xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\" xmlns:d=\"http://xamarin.com/schemas/2014/forms/design\" xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" mc:Ignorable=\"d\" x:Class=\"DynamicXamlDemo.XamlShell\"><ContentView.Content><StackLayout>{{content}}</StackLayout></ContentView.Content></ContentView>";

        public void LoadData()
        {
            // Load values from Json
            JsonData = Preferences.Get(nameof(JsonData), "{}");
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonData);
            Values.Clear();
            foreach (var entry in data)
            {
                Values.Add(entry.Key, entry.Value);
            }

            // Get the Xaml and put inside the shell
            var baseDefinition = Preferences.Get(nameof(XamlDefinition), "");
            XamlDefinition = xamlShell.Replace("{{content}}", baseDefinition);
            var contentView = new ContentView().LoadFromXaml(XamlDefinition);

            // Set DataBinding
            contentView.BindingContext = this;

            // Set the content on the view
            ContentPresenter?.Children?.Clear();
            ContentPresenter?.Children?.Add(contentView);
        }

        public string XamlDefinition { get; set; }
        public string JsonData { get; set; }

        StackLayout contentPresenter;
        public StackLayout ContentPresenter
        {
            get => contentPresenter;
            set
            {
                contentPresenter = value;
                LoadData();
            }
        }

    }
}