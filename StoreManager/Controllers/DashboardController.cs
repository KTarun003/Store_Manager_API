using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManager.Models;

namespace StoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private const string Sql = "call UpdateDashboard();";
        private readonly store_managerContext _context;

        public DashboardController(store_managerContext context)
        {
            _context = context;
        }

        // GET: api/Dashboard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dashboard>> GetDashboard(int id)
        {
            _ = _context.Database.ExecuteSqlRaw(Sql);
            var Dashboard = await _context.Dashboard.FindAsync(id);

            if (Dashboard == null)
            {
                return NotFound();
            }

            return Dashboard;
        }
    }
    
}
