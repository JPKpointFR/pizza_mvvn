using System.ComponentModel.DataAnnotations;

namespace pizza_mvvn.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string nom { get; set; }
        public int prix { get; set; }
        [Display(Name = "Végétarienne")] 
        public bool vegetarienne { get; set; }
        public string ingredients { get; set; }
    }
}
