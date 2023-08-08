using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pizza_mvvn.Data;
using pizza_mvvn.Models;
using Microsoft.EntityFrameworkCore;
using pizza_mvvn.Pages.Order;
using pizza_mvvn.Contollers;





namespace pizza_mvvn.Pages
{
    public class IndexModel : PageModel
    {
        private readonly pizza_mvvn.Data.DataContext _context;

        private readonly ILogger<IndexModel> _logger;
        public int orderLenght;
        private readonly OrderModel _orderModel;


        public IndexModel(ILogger<IndexModel> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
            _orderModel = new OrderModel(context);

        }
        public List<Pizza> Pizza { get; set; } = new List<Pizza>();

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizzas.ToListAsync();
            orderLenght = OrderModel.pizzasIdList.Count;
        }

    }
}
