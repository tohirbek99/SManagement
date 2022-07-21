using Microsoft.EntityFrameworkCore;
using SManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SManagement.DataAccess.Models
{
    public static class ModulBE
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staf>().HasData(
               new Staf
               {
                   Id = 1,
                   FirstName = "Tohir",
                   LastName = "Arzimurodov",
                   Email = "tohirkarzimurodov@gmail.com",
                   Department = Departments.Admin
               },
                new Staf
                {
                    Id = 2,
                    FirstName = "Tohirbek",
                    LastName = "Arzimurodov",
                    Email = "tohirbekarzimurodov@gmail.com",
                    Department = Departments.HR
                }

               );
        }
    }
}
