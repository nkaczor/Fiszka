using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibraryMock1.BO
{
    public class Word : IWord
    {

        public Word() {
            WasShowedCounter = 0;
            Successes = 0;
        }
        public string OriginWord
        {
            get;
            set;
        }

        public string Translation
        {
            get;
            set;
        }

        public int WordId
        {
            get;
            set;
        }

        public int WasShowedCounter { get; set; }

        public int Successes
        {
            get;
            set;
        }

        public int Losses
        {
            get;
            set;
           
        }
    }
}
