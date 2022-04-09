using Xamarin.Essentials;

namespace DynamicXamlDemo.ViewModels
{
    public class DefinitionViewModel : BaseViewModel
    {
        public DefinitionViewModel()
        {
            Title = "Xaml Definition";
            XamlDefinition = Preferences.Get(nameof(XamlDefinition), "<Label Text=\"Text 1\" /><Entry Text=\"{Binding Values[Text1]}\" />");
            JsonData = Preferences.Get(nameof(JsonData), "{Text1:\"Text 1 value\"}");
        }

        string jsonData;

        public string JsonData
        {
            get => jsonData;
            set
            {
                if (SetProperty(ref jsonData, value))
                {
                    Preferences.Set(nameof(JsonData), value);
                }
            }
        }

        string xamlDefinition;

        public string XamlDefinition
        {
            get => xamlDefinition;
            set
            {
                if (SetProperty(ref xamlDefinition, value))
                {
                    Preferences.Set(nameof(XamlDefinition), value);
                }
            }
        }
    }
}