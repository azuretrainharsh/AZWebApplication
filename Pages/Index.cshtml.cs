using AZWebApplication.Models;
using AZWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AZWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;

        public void OnGet()
        {
            ProductServices ser=new ProductServices();
            Products= ser.GetProductDetails();

        }
    }
}