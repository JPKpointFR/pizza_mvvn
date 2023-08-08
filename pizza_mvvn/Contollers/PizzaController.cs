using Microsoft.AspNetCore.Mvc;
using pizza_mvvn.Pages.Order;

namespace pizza_mvvn.Contollers
{
    public class PizzaController : Controller
    {

        private readonly pizza_mvvn.Data.DataContext _context;
        public static int pizzasIdListStatic;
        public PizzaController(pizza_mvvn.Data.DataContext context)
        {
            _context = context;

        }
         
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddPizza(int id)
        {

            OrderModel.pizzasIdList.Add(id);
            pizzasIdListStatic = OrderModel.pizzasIdList.Count;


            return RedirectToAction("Index", "Pizza");
        }
    }
}
