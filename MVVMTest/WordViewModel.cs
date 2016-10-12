using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiszka
{
    public class WordViewModel : INotifyPropertyChanged
    {
        private IWord _word;
        private IDAO _dao;
        public WordViewModel(IWord word, IDAO dao)
        {
            _word = word;
            _dao = dao;
        }

        public WordViewModel(IWord word)
        {
            _word = word;
        }

        public int WordId
        {
            get { return _word.WordId; }
            set
            {
                _word.WordId = value;
                RaisePropertyChanged("WordId");
            }
        }

        public int Successes
        {
            get { return _word.Successes; }
            set
            {
                _word.Successes = value;
                RaisePropertyChanged("Successes");
            }
        }


        public int Losses
        {
            get { return _word.Losses; }
            set
            {
                _word.Losses = value;
                RaisePropertyChanged("Losses");
            }
        }
        public int WasShowedCounter {
            get { return _word.WasShowedCounter; }
            set
            {
                _word.WasShowedCounter = value;
                RaisePropertyChanged("WasShowedCounter");
                Console.WriteLine("apdejst");
            }
        }

        public string Translation
        {
            get { return _word.Translation; }
            set
            {
                _word.Translation = value;
                RaisePropertyChanged("Translation");
            }
        }

        public string OriginWord
        {
            get { return _word.OriginWord; }
            set
            {
                _word.OriginWord = value;
                RaisePropertyChanged("OriginWord");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
