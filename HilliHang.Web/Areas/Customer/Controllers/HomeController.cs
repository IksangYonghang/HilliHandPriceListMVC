using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            Product product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category");
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet] // Add this attribute for handling AJAX GET requests
        public IActionResult SearchSuggestions(string query)
        {
            // Query the database for product suggestions based on the 'query' parameter
            var suggestions = _unitOfWork.Product
                .GetProductsByName(query)
                .Select(product => new { productName = product.ProductName })
                .ToList();

            return Json(suggestions);
        }

        // This is your existing Search action for rendering the search results view
        [HttpGet]
        public IActionResult Search(string productName)
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetProductsByName(productName);
            return View("Index", productList);
        }
    }
}
