using System.Web.Mvc;
using ProductDatabase.Entity;
using ProductDatabase.Interfaces;
using Services.Services;
using Services.ViewModels;

namespace HomeWorkMVC.Controllers
{
    public class HomeController : Controller
    {
        private ProductService productService;

        public HomeController()
        {

        }
        public HomeController(IReposInterface<Product> repos)
        {
            productService = new ProductService(repos);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginForm(string username, string userpassword)
        {
            if (username == "admin" || userpassword == "admin")
            {
                HttpContext.Response.Cookies["login"].Value = "true";
                return Redirect("Index");
            }

            ViewBag.ErrorMessage = "Неверный логин или пароль";
            return View("Login");
        }

        public ActionResult Index()
        {
            if (HttpContext.Request.Cookies["login"] == null)
                HttpContext.Response.Cookies["login"].Value = "false";

            if(HttpContext.Request.Cookies["login"].Value =="true")
                return View(productService.GetAllProducts()); 

            return Redirect("Home/Login");
        }

        public ActionResult Unlogin()
        {
            HttpContext.Response.Cookies["login"].Value = "false";
            return Redirect("Login");
        }

        public ActionResult Sort(string inputCategory)
        {
            if (HttpContext.Request.Cookies["login"].Value == "true")
                return View("Index",productService.GetProductsByCategory(inputCategory));
            return Redirect("Home/Login");
        }

        public ActionResult ProductAdd(ProductViewModel product)
        {
            if (HttpContext.Request.Cookies["login"].Value == "true")
            {
                if (ModelState.IsValid)
                    productService.AddProduct(product);


                return View("Index", productService.GetAllProducts());
            }

            return Redirect("Home/Login");
        }
    }
}