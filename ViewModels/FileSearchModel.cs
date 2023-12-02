using MauiBase.Util;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MauiBase.ViewModels
{
    internal class FileSearchModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        readonly FileSearcher _fileSearcher = new();
        string _keyword;
        public string Keyword
        {
            get => _keyword;
            set
            {
                if (value != _keyword)
                {
                    _keyword = value;
                    _fileSearcher.SearchText = value;
                    var files = _fileSearcher.Search();
                    if (files != null)
                    {
                        Filenames.Clear();
                        foreach (var filename in files)
                        {
                            Filenames.Add(filename);
                        }
                    }
                    else
                    {
                        Filenames.Clear();
                    }
                    OnPropertyChanged();
                }
            }
        }
        bool _nestSearch = false;
        public bool NestSearch
        {
            get => _nestSearch;
            set
            {
                if (value != _nestSearch)
                {
                    _nestSearch = value;
                    _fileSearcher.NestSearch = value;
                    Filenames = _fileSearcher.Search() == null ? new() : new(_fileSearcher.Search());
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<string> Filenames { get; set; }

        public FileSearchModel()
        {
            Filenames = new ObservableCollection<string>(new[] {
            "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao",
             "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao", "nihao"
        });
        }

        void OnPropertyChanged([CallerMemberName] string callerName="")
        {
            Debug.WriteLine($"length:{Filenames.Count}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }

    }
}
