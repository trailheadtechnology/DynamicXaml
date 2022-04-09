using Xamarin.Essentials;

namespace DynamicXamlDemo.ViewModels
{
    public class DefinitionViewModel : BaseViewModel
    {
        public DefinitionViewModel()
        {
            Title = "Xaml Definition";
            XamlDefinition = Preferences.Get(nameof(XamlDefinition), "<Label Text=\"No Data\" /><Entry Text=\"No Binding\" />");
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