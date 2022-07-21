using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SManagement.Models
{
    public class MockSR : ISRepository
    {
        private List<Staf> _stafs = null;
        public MockSR()
        {
            _stafs = new List<Staf>()
            {
                new Staf(){Id=1,FirstName="Tohir",LastName="Arzimurodov",Email="tohirbekarzimurodov@gmail.com",Department=Departments.Admin},
                new Staf(){Id=2,FirstName="Tohirbe",LastName="Arzimurodov",Email="tohirbekarzimurodov@gmail.com",Department=Departments.Marketing},
                new Staf(){Id=3,FirstName="Tohirbek",LastName="Arzimurodov",Email="tohirbekarzimurodov@gmail.com",Department=Departments.Production}
            };
        }

        public Staf Create(Staf staf)
        {
            staf.Id = _stafs.Max(s => s.Id) + 1;
            _stafs.Add(staf);
            return staf;
        }

        public Staf Delete(int id)
        {
            var staf = _stafs.FirstOrDefault(s => s.Id.Equals(id));
            if (_stafs != null)
            {
                _stafs.Remove(staf);
            }
            return staf;
        }

        public Staf Get(int id)
        {
            return _stafs.FirstOrDefault(staf => staf.Id.Equals(id));
        }

        public IEnumerable<Staf> GetAll()
        {
            return _stafs;
        }

        public Staf Update(Staf updateedstaf)
        {
            var staf = _stafs.FirstOrDefault(s => s.Id.Equals(updateedstaf.Id));
            if (_stafs != null)
            {
                staf.FirstName = updateedstaf.FirstName;
                staf.LastName = updateedstaf.LastName;
                staf.Email = updateedstaf.Email;
                staf.Department = updateedstaf.Department;
            }
            return staf;
        }
    }
}
