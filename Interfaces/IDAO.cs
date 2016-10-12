using System.Collections.Generic;

namespace Interfaces
{
    public interface IDAO
    {
        
        IEnumerable<IUser> GetAllUsers();
        IUser CreateNewUser();
        IDictionary CreateNewDictionary();
        void AddUser(IUser user);
        void AddDictionary(IUser user, IDictionary dictionary);
        IWord CreateNewWord();
        void AddWord(IDictionary dictionary, IWord word);
    }
}
