using SManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SManagement.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Staf> Stafs { get; set; }
    }
}
