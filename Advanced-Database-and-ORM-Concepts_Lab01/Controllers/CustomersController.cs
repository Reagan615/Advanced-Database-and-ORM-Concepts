using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Advanced_Database_and_ORM_Concepts_Lab01.Data;
using Advanced_Database_and_ORM_Concepts_Lab01.Models;
using Advanced_Database_and_ORM_Concepts_Lab01.Models.ViewModels;

namespace Advanced_Database_and_ORM_Concepts_Lab01.Controllers
{
    public class CustomersController : Controller
    {
        private readonly Advanced_Database_and_ORM_Concepts_Lab01Context _context;

        public CustomersController(Advanced_Database_and_ORM_Concepts_Lab01Context context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            List<Customer> customeres = await _context.Customer.ToListAsync();

            return View(customeres);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,CompanyName,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,CompanyName,Phone")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'Advanced_Database_and_ORM_Concepts_Lab01Context.Customer'  is null.");
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer != null)
            {
                _context.Customer.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return _context.Customer.Any(e => e.Id == id);
        }

        public IActionResult CompareIndex()
        {
            CompareCustomerAddressVM compareCustomerAddressVM = new CompareCustomerAddressVM
            {
                CustomerIds = _context.Customer.Select(c => new SelectListItem
                { Value = c.Id.ToString(), Text = c.FirstName }).ToList(),
                AddressIds = _context.Address.Select(a => new SelectListItem
                { Value = a.Id.ToString(), Text = a.AddressLine1 }).ToList()
            };
            return View(compareCustomerAddressVM);
        }

        [HttpPost]
        public IActionResult CompareCustomerAddress(CompareCustomerAddressVM compareCustomerAddressVM)
        {
            if (!compareCustomerAddressVM.SelectedCustomerId.HasValue || !compareCustomerAddressVM.SelectedAddressId.HasValue)
            {
                compareCustomerAddressVM.CustomerIds = _context.Customer.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.FirstName }).ToList();
                compareCustomerAddressVM.AddressIds = _context.Address.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.AddressLine1 }).ToList();

                return View("CompareIndex", compareCustomerAddressVM);
            }

            CustomerAddress customerAddress = _context.CustomerAddress.FirstOrDefault(a => 
            a.CustomerId == compareCustomerAddressVM.SelectedCustomerId.Value && a.AddressId == compareCustomerAddressVM.SelectedAddressId.Value);

            if (customerAddress == null)
            {
                compareCustomerAddressVM.IsCustomerAtAddress = false;
            }
            else
            {
                compareCustomerAddressVM.IsCustomerAtAddress = true;
            }

            compareCustomerAddressVM.CustomerIds = _context.Customer.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.FirstName }).ToList();
            compareCustomerAddressVM.AddressIds = _context.Address.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.AddressLine1 }).ToList();

            return View("CompareIndex", compareCustomerAddressVM);
        }

    }
    
}
