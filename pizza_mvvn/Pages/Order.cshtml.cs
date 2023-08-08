using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pizza_mvvn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pizza_mvvn.Contollers;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Net;

namespace pizza_mvvn.Pages.Order
{

    public class OrderModel : PageModel
    {
        private readonly pizza_mvvn.Data.DataContext _context;
        public static List<int> pizzasIdList { get; set; } = new();
        public List<Pizza> pizzasList;
        public List<string> pizzasOrder;
        public int pizzasCount;


        public OrderModel(pizza_mvvn.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizza { get; set; }

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizzas.ToListAsync();
            pizzasList = GetPizzas();
            pizzasCount = pizzasList.Count;
        }

        public List<Pizza> GetPizzas()
        {
            List<Pizza> pizzas = new();

            foreach (int id in pizzasIdList)
            {
                Pizza p = Pizza.FirstOrDefault(p => p.PizzaId == id);
                pizzas.Add(p);
            }

            return pizzas;
        }

        public void  SendEmail(string mailAdresse, string name)
        {
      

            //pizzasOrder = PizzaOrder();
            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("CISSE", "adam.cis345@gmail.com"));
            mail.To.Add(new MailboxAddress(name, mailAdresse));
            mail.Subject = "commande de Pizza";

            var builder = new BodyBuilder();
            builder.TextBody = $"Bonjour {name} nous avons bien reçu votre commande de {pizzasIdList.Count} Pizzas";

            mail.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            
            client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            client.Authenticate("adam.cis345@gmail.com", "jrvhjmvubmhnzdeq");
            client.Send(mail);
            client.Disconnect(true);
            
        }


     
    }
}       
