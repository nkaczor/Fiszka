using System.ComponentModel;
using Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fiszka
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IUser _user;
        private IDAO _dao;
        private ObservableCollection<DictionaryViewModel> _dictionaries;
        public UserViewModel(IUser user, IDAO dao)
        {
            _user = user;
            _dao = dao;
            _dictionaries = new ObservableCollection<DictionaryViewModel>();
            foreach (var dict in user.Dictionaries) _dictionaries.Add(new DictionaryViewModel(dict, dao));
        }

        public void AddDictionary(IDictionary dictionary) {
            _dao.AddDictionary(_user, dictionary);
            _dictionaries.Add(new DictionaryViewModel(dictionary, _dao));
        }

        public int UserId
        {
            get { return _user.UserId; }
            set
            {
                _user.UserId = value;
                RaisePropertyChanged("UserId");
            }
        }

        public string Name
        {
            get { return _user.Name; }
            set
            {
                _user.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public ObservableCollection<DictionaryViewModel> Dictionaries
        {
            get { return _dictionaries; }
            set
            {
                _dictionaries = value;
                RaisePropertyChanged("Dictionaries");
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
