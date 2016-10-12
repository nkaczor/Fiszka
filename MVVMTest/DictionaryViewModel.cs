using Interfaces;
using Fiszka;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;

namespace Fiszka
{
    public class DictionaryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IDictionary _dict;
        private IDAO _dao;
        private ObservableCollection<WordViewModel> _words;
        public DictionaryViewModel(IDictionary dict)
        {
            this._dict = dict;
            _words = new ObservableCollection<WordViewModel>();
            foreach (var word in dict.Words) _words.Add(new WordViewModel(word));
        }

        public DictionaryViewModel(IDictionary dict, IDAO dao) : this(dict)
        {
            _dao = dao;
        }


        public void AddWord(IWord word)
        {
            _dao.AddWord(_dict, word);
            _words.Add(new WordViewModel(word));
        }

        public int DictionaryId
        {
            get { return _dict.DictionaryId; }
            set
            {
                _dict.DictionaryId = value;
                RaisePropertyChanged("DictionaryId");
            }
        }

        public ObservableCollection<WordViewModel> Words
        {
            get { return _words; }
            set
            {
                _words = value;
                RaisePropertyChanged("Words");
            }
        }

        public string Title
        {
            get { return _dict.Title; }
            set
            {
                _dict.Title = value;
                RaisePropertyChanged("Title");
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        internal void RefreshCounters()
        {
            RaisePropertyChanged("Words");
        }
    }
}