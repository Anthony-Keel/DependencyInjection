using DependencyInjection.Models;
using System.Web.Mvc;
using Ninject;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;
        private Product[] products =
        {
           new Product {Name = "Kayak", Category="Watersports", Price=275M },
           new Product {Name = "Lifejacket",Category="Watersports", Price = 48.95M },
           new Product {Name = "Soccer Ball", Category="Soccer", Price=19.50m },
           new Product {Name = "Corner Flag", Category="Soccer", Price=34.95M },

        };
        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }
        // GET: Home
        public ActionResult Index()
        {

            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}