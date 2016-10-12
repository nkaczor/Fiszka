using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibraryMock1.BO
{
    public class Dictionary : IDictionary
    {
        static int ids = 1;
        public Dictionary() {
            Words = new List<IWord>();
            DictionaryId = ids++;
        }

        public int DictionaryId
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public List<IWord> Words
        {
            get;
            set;
        }
    }
}
