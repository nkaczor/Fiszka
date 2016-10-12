using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUser
    {
        int UserId { get; set; }
        string Name { get; set; }
        List<IDictionary> Dictionaries { get; set; }
    }
}
