using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using pizza_mvvn.Data;
using pizza_mvvn.Models;

namespace pizza_mvvn.Pages.Admin.Pizzas
{
    [Authorize]

    public class CreateModel : PageModel
    {
        private readonly pizza_mvvn.Data.DataContext _context;

        public CreateModel(pizza_mvvn.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pizza Pizza { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pizzas.Add(Pizza);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
