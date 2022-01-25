using Agency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.Services
{
    public class LayoutService
    {
        AgencyContext _context;
        public LayoutService(AgencyContext context)
        {
            _context = context;
        }

        public async Task<List<Setting>> GetSettings()
        {
            return await _context.Settings.ToListAsync();
        }
    }
}
