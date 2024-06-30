using Microsoft.AspNetCore.Mvc;
using Task2.Application;
using Task2.Contract;

namespace Task2.Presentation.Controllers
{
    public class ProductController(IProductStore productStore, ProductDownloader productDownloader) : Controller
    {
        private readonly IProductStore productStore = productStore;
        private readonly ProductDownloader productDownloader = productDownloader;

        public async Task<ActionResult> Index()
        {
            var products = await productStore.GetProductsAsync();

            return View(products);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await productStore.GetProductsAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Download()
        {
            await productDownloader.DownloadProductsAsync();

            return Ok();
        }

        [HttpPost]
        [Route("Product/ChangeState")]
        public async Task<IActionResult> ChangeState([FromBody]ChangeStateRequest req)
        {
            await productStore.ChangeStatusAsync(req.Id);

            return Ok();
        }
    }

    public class ChangeStateRequest
    {
        public int Id { get; set; }
    }
}
