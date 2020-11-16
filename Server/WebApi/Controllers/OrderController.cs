using Microsoft.AspNetCore.Mvc;
using WebApi.BL;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private IInvoiceGenerator _generator;

        public OrderController(IInvoiceGenerator generator)
        {
            _generator = generator;
        }

        [HttpPost]
        public ActionResult<Invoice> GenerateInvoice(Order order)
        {
            return CreatedAtAction("GenerateInvoice", new { id = 100 }, _generator.GenerateInvoice(order));
        }
    }
}
