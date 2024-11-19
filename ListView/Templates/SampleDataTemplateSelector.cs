using ListView.Models;

namespace ListView.Templates;

public class SampleDataTemplateSelector : DataTemplateSelector {

    public DataTemplate TitleTemplate { get; set; }
    public DataTemplate MessageTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        return ((SampleData)item).Title.Contains("Title") ? TitleTemplate : MessageTemplate;
    }
}