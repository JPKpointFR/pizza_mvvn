using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using pizza_mvvn.Data;
using pizza_mvvn.Models;

namespace pizza_mvvn.Pages.Admin.Pizzas
{

    [Authorize]

    public class IndexModel : PageModel
    {
        private readonly pizza_mvvn.Data.DataContext _context;

        public IndexModel(pizza_mvvn.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizza { get;set; }

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizzas.ToListAsync();
        }

        public async Task<Pizza> FindPizzaAsync(int id)
        {
            Pizza = await _context.Pizzas.ToListAsync();
            var pizza = Pizza.FirstOrDefault(p => p.PizzaId == id);

            return pizza;
        }
    }
}
