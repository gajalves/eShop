using Microsoft.AspNetCore.Mvc;

namespace eShop.Catalog.API.Controllers
{
    public class CatalogController : BaseController
    {
        [HttpGet("teste")]
        public IActionResult Teste()
        {
            return Ok(new
            {
                message = "Deu bom"
            }
            );
        }

    }
}
