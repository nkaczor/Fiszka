using System;
using System.Collections.Generic;
using System.Linq;
using CarLibraryMock1.BO;
using Interfaces;

namespace CarLibraryMock1
{
    public class DAOMock1 : IDAO
    {
       
        private List<IUser> _users;
        public DAOMock1()
        {

        
            _users = new List<IUser>
            {
                new User {Name = "Natalia",
                    Dictionaries = new List<IDictionary> {
                        new Dictionary {
                            Title ="Angielsko-Polski",
                            Words = new List<IWord> {
                                new Word { OriginWord="Car", Translation="Auto" },
                                new Word {  OriginWord="Wash", Translation="myć" },
                                new Word { OriginWord="Child", Translation="Dziecko" },
                                new Word { OriginWord="Bike", Translation="Rower" },
                                new Word {  OriginWord="Tea", Translation="herbata" },
                                new Word { OriginWord="Flower", Translation="kwiatek" },
                                new Word { OriginWord="Window", Translation="okno" },
                                new Word { OriginWord="Science", Translation="nauka" },
                                new Word { OriginWord="Science", Translation="nauka" },
                                new Word { OriginWord="Love", Translation="milosc" },
                                new Word { OriginWord="Dog", Translation="pies" },
                                new Word { OriginWord="Cat", Translation="kot" },
                                new Word { OriginWord="Word", Translation="słowo" },
                            } },
                        new Dictionary {
                            Title ="Informatyczno-polski",
                            Words = new List<IWord> {
                                new Word { WordId=4, OriginWord="Formatka", Translation="okienko" },
                                new Word { WordId=5, OriginWord="myszka", Translation=" urządzenie wskazujące używane podczas pracy z interfejsem graficznym systemu komputerowego" },
                                new Word { WordId=6, OriginWord="Kompilator", Translation="program służący do automatycznego tłumaczenia kodu" },
                            } },
                    } },
                new User {Name = "Damian", Dictionaries = new List<IDictionary> {
                        new Dictionary { Title="Niemiecko-Polski", Words = new List<IWord>{
                                new Word { OriginWord="waschen", Translation="myc" },new Word { OriginWord="das auto", Translation="samochod" } } },
                        new Dictionary { Title="Rusko-polski", Words = new List<IWord>() },
                    }},
                new User {Name = "Janusz", Dictionaries = new List<IDictionary> {
                        new Dictionary { Title="Arabsko-Polski", Words = new List<IWord>() },
                        new Dictionary { Title="Informatyczno-niemiecki", Words = new List<IWord>() },
                    }}
            };
        }
        public IEnumerable<IUser> GetAllUsers()
        {
            return _users;
        }

        public IUser CreateNewUser()
        {
            return new User();
        }

        public void AddUser(IUser user)
        {
            _users.Add(user);
        }

        public IDictionary CreateNewDictionary()
        {
            return new Dictionary();
        }

        public IWord CreateNewWord()
        {
            return new Word();
        }

        public void AddDictionary(IUser user, IDictionary dictionary)
        {
            user.Dictionaries.Add(dictionary);
        }

        public void AddWord(IDictionary dictionary, IWord word)
        {
            dictionary.Words.Add(word);
        }
    }
}
