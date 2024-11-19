using ListView.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListView.ViewModels;

public class SampleDatasViewModel : INotifyPropertyChanged {
    readonly IList<SampleData> source;

    private ObservableCollection<SampleData> _SampleDatas;
    public ObservableCollection<SampleData> SampleDatas {
        get { return _SampleDatas; }
        private set { _SampleDatas = value; OnPropertyChanged(); }
    }

    public SampleDatasViewModel()
    {
        source = new List<SampleData>();
    }

    public Command Command => new Command(async (args) => {

        source.Clear();

        switch (args) {
            case "sample1":
                SetSampleData_1();
                break;

            case "sample2":
                SetSampleData_2();
                break;

            default:
                break;
        }
    });

    private void SetSampleData_1()
    {
        var header = "Sample 1";
        source.Add(new SampleData() { Title = $"{header} Title 1" });
        source.Add(new SampleData() { Title = $"{header} Message 1 - 1" });

        source.Add(new SampleData() { Title = $"{header} Title 2" });
        source.Add(new SampleData() { Title = $"{header} Message 2 - 1" });

        source.Add(new SampleData() { Title = $"{header} Title 3" });
        source.Add(new SampleData() { Title = $"{header} Message 3 - 1" });

        SampleDatas?.Clear();
        SampleDatas = new ObservableCollection<SampleData>(source);
    }

    private void SetSampleData_2()
    {
        var header = "Sample 2";
        source.Add(new SampleData() { Title = $"{header} Title 1" });
        source.Add(new SampleData() { Title = $"{header} Message 1 - 1" });

        source.Add(new SampleData() { Title = $"{header} Title 2" });
        source.Add(new SampleData() { Title = $"{header} Message 2 - 1" });
        source.Add(new SampleData() { Title = $"{header} Message 2 - 2" });

        source.Add(new SampleData() { Title = $"{header} Title 3" });
        source.Add(new SampleData() { Title = $"{header} Message 3 - 1" });
        source.Add(new SampleData() { Title = $"{header} Message 3 - 2" });
        source.Add(new SampleData() { Title = $"{header} Message 3 - 3" });

        SampleDatas?.Clear();
        SampleDatas = new ObservableCollection<SampleData>(source);
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}