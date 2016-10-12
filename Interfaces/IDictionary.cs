using System.Collections.Generic;

namespace Interfaces
{
    public interface IDictionary
    {
       int DictionaryId { get; set; }
       string Title { get; set; }
       List<IWord> Words { get; set; }
    }
}