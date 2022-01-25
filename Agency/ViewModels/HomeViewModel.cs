using Agency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.ViewModels
{
    public class HomeViewModel
    {
        public List<Portfolio> Portfolios { get; set; }
        public List<Service> Services { get; set; }
    }
}
