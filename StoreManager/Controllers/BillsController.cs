﻿using System;
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
    public class BillsController : ControllerBase
    {
        private readonly store_managerContext _context;

        public BillsController(store_managerContext context)
        {
            _context = context;
        }

        // GET: api/Bills
        [HttpGet]
        public ActionResult<IEnumerable<Bills>> GetAllBills()
        {
            List<Bills> bills = _context.Bills.ToList();
            foreach (Bills bill in bills)
            {
                BillItems(bill);
            }
            return bills.ToList();
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bills>> GetBills(int id)
        {
            var bills = await _context.Bills.FindAsync(id);

            if (bills == null)
            {
                return NotFound();
            }
            BillItems(bills);
            return bills;
        }

        // PUT: api/Bills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBills(int id, Bills bills)
        {
            if (id.Equals(bills.Id))
            {
                return BadRequest();
            }

            _context.Entry(bills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bills>> PostBills(Bills bills)
        {
            _context.Bills.Add(bills);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBills", new { id = bills.Id }, bills);
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bills>> DeleteBills(int id)
        {
            var bills = await _context.Bills.FindAsync(id);
            if (bills == null)
            {
                return NotFound();
            }

            _context.Bills.Remove(bills);
            await _context.SaveChangesAsync();

            return bills;
        }

        private bool BillsExists(int id)
        {
            return _context.Bills.Any(e => e.Id.Equals(id));
        }

        private void BillItems(Bills bill)
        {
            ICollection<Items> items = _context.Items.Where(items => items.BillId == bill.Id).ToList(); ;
            foreach(Items item in items)
            {
                bill.Items.Add(item);
            }
            
        }
    }
}
