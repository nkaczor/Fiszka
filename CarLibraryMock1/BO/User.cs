using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace CarLibraryMock1.BO
{
    public class User : IUser
    {

        static int ids = 1;
        public User() {
            Dictionaries = new List<IDictionary>();
            Console.WriteLine("Hejka");
            UserId = ids++;
        }

        public List<IDictionary> Dictionaries
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }
    }
}
