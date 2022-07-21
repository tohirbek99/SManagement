using SManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SManagement.DataAccess.Models
{
    public class SqlServerSRepository : ISRepository
    {
        private readonly AppDbContext dbContext;

        public SqlServerSRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        Staf ISRepository.Create(Staf staf)
        {
            dbContext.Stafs.Add(staf);
            dbContext.SaveChanges();
            return staf;
        }

        Staf ISRepository.Delete(int id)
        {
            var staf = dbContext.Stafs.Find(id);
            if (staf != null)
            {
                dbContext.Stafs.Remove(staf);
                dbContext.SaveChanges();
            }
            return staf;
        }

        Staf ISRepository.Get(int id)
        {
           return dbContext.Stafs.Find(id);

        }

        IEnumerable<Staf> ISRepository.GetAll()
        {
            return dbContext.Stafs;
        }

        Staf ISRepository.Update(Staf updatedstaf)
        {
            var staf = dbContext.Stafs.Attach(updatedstaf);
            staf.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return updatedstaf;
        }
    }
}
