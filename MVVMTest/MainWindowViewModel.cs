using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using CarLibraryMock1;
using Interfaces;
using System.Windows;
using Fiszka;

namespace Fiszka
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IDAO _dao;

       
        private ObservableCollection<UserViewModel> _users;

        public MainWindowViewModel()
        {
            _dao = new DAOMock1();
            _users = new ObservableCollection<UserViewModel>();
           
            _newDictionaryValue = "";
            GetAllUsers();
            _selectedDictionary = null;
            _selectedUser = _users[0];
            _selectedWord = null;
            _addUserCommand = new RelayCommand(param => AddNewUser());
            _startLearningCommand = new RelayCommand(param => StartLearning());
            _addDictionaryCommand = new RelayCommand(param => AddNewDictionary());
            _addWordCommand = new RelayCommand(param => AddNewWord());
            _deleteWordCommand = new RelayCommand(param => DeleteWord());
            _editDictionaryCommand = new RelayCommand(param => EditNewDictionary());
            _deleteDictionaryCommand = new RelayCommand(param => DeleteNewDictionary());
        }

        public ObservableCollection<UserViewModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged("Users");
            }
        }

        private void GetAllUsers()
        {
            foreach (var user in _dao.GetAllUsers())
            {
                _users.Add(new UserViewModel(user, _dao));
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

      
        private string _newDictionaryValue;

        public string NewDictionaryValue
        {
            set
            {
                _newDictionaryValue = value;
                RaisePropertyChanged("NewDictionaryValue");
            }
            get { return _newDictionaryValue; }
        }

        public ICommand EditDictionaryCommand
        {
            get { return _editDictionaryCommand; }
        }

        private RelayCommand _editDictionaryCommand;

        private void EditNewDictionary()
        {
            var dialog = new EditDictionaryNameDialog();
            if (dialog.ShowDialog() == true)
            {
               _selectedDictionary.Title = dialog.ResponseText;
            }
        }

        public ICommand DeleteDictionaryCommand
        {
            get { return _deleteDictionaryCommand; }
        }

        private RelayCommand _deleteDictionaryCommand;

        private void DeleteNewDictionary()
        {
            _selectedUser.Dictionaries.Remove(_selectedDictionary);
        }

        public ICommand AddDictionaryCommand
        {
            get { return _addDictionaryCommand; }
        }

        private RelayCommand _addDictionaryCommand;

        private void AddNewDictionary()
        {
            if (_newDictionaryValue.Length > 0)
            {
                IDictionary dictionary = _dao.CreateNewDictionary();
                dictionary.Title = _newDictionaryValue;
                _selectedUser.AddDictionary(dictionary);
            }
        }

        public ICommand AddWordCommand
        {
            get { return _addWordCommand; }
        }

        private RelayCommand _addWordCommand;

        private void AddNewWord()
        {
            var dialog = new NewWordDialog();
            if (dialog.ShowDialog() == true)
            {
                IWord word = _dao.CreateNewWord();
                word.OriginWord = dialog.OriginWord;
                word.Translation = dialog.Translation;
                _selectedDictionary.AddWord(word);
            }
        }

        public ICommand DeleteWordCommand
        {
            get { return _deleteWordCommand; }
        }

        private RelayCommand _deleteWordCommand;

        private void DeleteWord()

        {
            SelectedDictionary.Words.Remove(_selectedWord);
            _selectedWord = null;
            System.Console.WriteLine("Hello");
           
        }

        public ICommand StartLearningCommand
        {
            get { return _startLearningCommand; }
        }

        private RelayCommand _startLearningCommand;

        private void StartLearning()
        {
            var win = new LearningWindow();
            win.DataContext = new LearningViewModel(_selectedDictionary, _dao);
            win.Show();
        }

        public ICommand AddUserCommand
        {
            get { return _addUserCommand; }
        }

        private RelayCommand _addUserCommand;

        private void AddNewUser()
        {
            var dialog = new NewUserDialog();
            if (dialog.ShowDialog() == true)
            {
                IUser user = _dao.CreateNewUser();
                user.Name = dialog.ResponseText;
                UserViewModel userViewModel = new UserViewModel(user,_dao);

                _dao.AddUser(user);
                _users.Add(userViewModel);
                SelectedUser = userViewModel;
            }
        }

        private DictionaryViewModel _selectedDictionary;

        public DictionaryViewModel SelectedDictionary
        {
            get { return _selectedDictionary; }
            set
            {
                _selectedDictionary = value;
      
                RaisePropertyChanged("SelectedDictionary");
              
            }
        }

        private WordViewModel _selectedWord;

        public WordViewModel SelectedWord
        {
            get { return _selectedWord; }
            set
            {
                _selectedWord = value;

                RaisePropertyChanged("SelectedWord");
            }
        }

        private UserViewModel _selectedUser;

        public UserViewModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                SelectedDictionary = null;
                RaisePropertyChanged("SelectedUser");
            }
        }


    }
}
