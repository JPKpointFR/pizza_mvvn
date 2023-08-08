using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pizza_mvvn.Pages;
using pizza_mvvn.Pages.Order;

namespace pizza_mvvn.Contollers
{
    public class OrderController : Controller
    {
        private readonly pizza_mvvn.Data.DataContext _context;

        OrderModel _orderModel;

        public OrderController(pizza_mvvn.Data.DataContext context)
        {
            _context = context;
            _orderModel = new OrderModel(context);

        }



        public IActionResult Index()
        {
            return View();
        }





        [HttpPost]
        public IActionResult MailSender(string mailAdresse, string name)
        {

            _orderModel.SendEmail(mailAdresse, name);

            OrderModel.pizzasIdList = new();
            
            return RedirectToPage("/GoodOrder");
        }


    }
}
