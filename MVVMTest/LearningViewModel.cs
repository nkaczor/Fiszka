using Fiszka;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fiszka
{
    public class LearningViewModel : INotifyPropertyChanged
    {
        static Random rnd = new Random();
        private DictionaryViewModel _dict;
        private IDAO _dao;
        private bool _startScreen;
        private bool _endScreen;
        private bool _wordsScreen;
        private WordViewModel _currentWord;

        private ObservableCollection<WordViewModel> _words;
        public event PropertyChangedEventHandler PropertyChanged;

        public LearningViewModel(DictionaryViewModel dict, IDAO dao) {
            _dict = dict;
            _dao = dao;
            _showWordsCommand = new RelayCommand(param => ShowWords());
            _checkCommand = new RelayCommand(param => Check());
            _nextCommand = new RelayCommand(param => Next());
            StartScreen = true;
            WordsScreen = false;
            EndScreen = false;
            UserResponse = "";
            Successes = 0;
            
        }
        private int _successes;
        public int Successes
        {
            get { return _successes; }
            set
            {
                _successes = value;
                RaisePropertyChanged("Successes");
            }
        }

        public bool EndScreen{
            get{ return _endScreen; }
            set {
                _endScreen = value;
                RaisePropertyChanged("EndScreen");
            }    
        }


        public bool WordsScreen
        {
            get { return _wordsScreen; }
            set
            {
                _wordsScreen = value;
                RaisePropertyChanged("WordsScreen");
            }
        }

        public bool StartScreen
        {
            get { return _startScreen; }
            set
            {
                _startScreen = value;
                RaisePropertyChanged("StartScreen");
            }
        }

        public ICommand ShowWordsCommand
        {
            get { return _showWordsCommand; }
        }

        private RelayCommand _showWordsCommand;

        private void ShowWords()
        {

            StartScreen = false;
            WordsScreen = true;
            RaisePropertyChanged("StartScreenVisibility");
            RaisePropertyChanged("WordsVisibility");
            createLearningSet();

        }

        public ICommand CheckCommand
        {
            get { return _checkCommand; }
        }

        private RelayCommand _checkCommand;

        private void Check()
        {
            if (CurrentWord.OriginWord.ToLower() == UserResponse.ToLower())
            {
                Console.WriteLine("Dobrze!");
                CurrentWord.Successes++;
                Successes++;
                _dict.RefreshCounters();
                ResponseStatus = 1;
            }
            else {
                CurrentWord.Losses++;
                ResponseStatus = -1;
            }
            IsChecked = true;

        }

        public ICommand NextCommand
        {
            get { return _nextCommand; }
        }

        private RelayCommand _nextCommand;

        private void Next()
        {
            randNextWord();
            IsChecked = false;
            UserResponse = "";
            ResponseStatus = 0;
        }

        public Visibility NextButtonVisibility
        {
            get { return IsChecked ? Visibility.Visible : Visibility.Collapsed; }
        }

        public Visibility CheckButtonVisibility
        {
            get { return IsChecked ? Visibility.Collapsed : Visibility.Visible; }
        }
        private bool isChecked;
        public bool IsChecked {
            get { return isChecked; }
            set {
                isChecked = value;
                RaisePropertyChanged("CheckButtonVisibility");
                RaisePropertyChanged("NextButtonVisibility");
            }
        }

        public DictionaryViewModel Dictionary {
            get { return _dict; }
        }

        private void createLearningSet() {
            int newWordsNumber = Convert.ToInt32(0.4f * _wordsToLearn);
            int barelyKnownWordsNumber = Convert.ToInt32(0.4f * _wordsToLearn);
            int wellKnownWordsNumber = _wordsToLearn - newWordsNumber - barelyKnownWordsNumber;
            
            var newWords = _dict.Words.Where(word => word.WasShowedCounter == 0).OrderBy(x => rnd.Next()).Take(newWordsNumber);
            var barelyKnownWords = _dict.Words
                .Where(word => word.WasShowedCounter > 0 && word.Successes / word.WasShowedCounter <= 0.5)
                .OrderBy(x => rnd.Next())
                .Take(barelyKnownWordsNumber);
            var wellKnownWords = _dict.Words
                .Where(word => word.WasShowedCounter > 0 && word.Successes / word.WasShowedCounter > 0.5)
                .OrderBy(x => rnd.Next())
                .Take(wellKnownWordsNumber);
            var remainingWordsNumber = _wordsToLearn - newWords.Count() - barelyKnownWords.Count() - wellKnownWords.Count();
            var remainingWords = _dict.Words.OrderBy(x => rnd.Next()).Take(remainingWordsNumber);
            
            _words = new ObservableCollection<WordViewModel>(newWords.Concat(barelyKnownWords).Concat(wellKnownWords).Concat(remainingWords));
            ResponseStatus = 0;
            randNextWord();

        }

        private void randNextWord(){
            if (_words.Count == 0) {
                WordsScreen = false;
                EndScreen = true;
            }
            else
            {
                int r = rnd.Next(_words.Count);
                CurrentWord = _words[r];
                CurrentWord.WasShowedCounter++;
                _dict.RefreshCounters();
                _words.RemoveAt(r);
            }
        }


        private Int32 _wordsToLearn = 5;

        public Int32 WordsToLearn
        {
            get { return _wordsToLearn; }
            set {
                _wordsToLearn = value;
                RaisePropertyChanged("WordsToLearn");
            }
        }

        public WordViewModel CurrentWord {
            get { return _currentWord; }
            set {
                _currentWord = value;
                RaisePropertyChanged("CurrentWord");
            } 
        }

        private int _responseStatus;
        public int ResponseStatus
        {
            get { return _responseStatus; }
            set
            {
                _responseStatus = value;
                RaisePropertyChanged("ResponseStatus");
            }
        }

        private string _userResponse;
        public string UserResponse
        {
            get { return _userResponse; }
            set
            {
                _userResponse = value;
                RaisePropertyChanged("UserResponse");
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
