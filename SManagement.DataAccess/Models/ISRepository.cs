using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SManagement.Models
{
    public interface ISRepository
    {
        Staf Get(int id);


        IEnumerable<Staf> GetAll();
        Staf Create(Staf staf);
        Staf Update(Staf staf);
        Staf Delete(int id);
    }
}
