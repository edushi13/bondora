using Microsoft.AspNetCore.Mvc;
using MVCClient.Data;
using MVCClient.Models;
using MVCClient.Formatters;
using MVCClient.Services;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace MVCClient.Controllers
{
    public class ItemsController : Controller
    {
        private IServerProxy _serverProxy;
        private IBookedRepository _booked;
        private IInvoiceFormatter _formatter;

        public ItemsController(IServerProxy proxy, IBookedRepository booked, IInvoiceFormatter invoiceFormatter)
        {
            _serverProxy = proxy;
            _booked = booked;
            _formatter = invoiceFormatter;
        }

        public IActionResult Index()
        {
            var items = _serverProxy.GetItems();
            return View(items);
        }

        public IActionResult Edit(int id)
        {
            var data = _serverProxy.GetItem(id);
            _booked.AddToOrder(id, data.Title, data.Type);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item _item)
        {
            var booked = _booked.GetOrderItem(_item.ID);
            _booked.Update(_item.ID, _item.Days);
            return RedirectToAction("Booked");        
        }


        public IActionResult Booked()
        {
            return View("Booked", _booked.GetBooked());
        }

        public IActionResult Remove(int id)
        {
            _booked.RemoveFromOrder(id);
            return View("Booked", _booked.GetBooked());        
        }

        [HttpGet]
        public IActionResult Invoice()
        {
            Order order = new Order() { CustomerId = 1, Items = _booked.GetBooked().ToList() };
            var invoice = _serverProxy.GenerateInvoiceAsync(order);
            
            string downloadFileName = "invoice.txt";

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            string text = _formatter.FormatInvoice(invoice);

            writer.Write(text);
            writer.Flush();
            stream.Position = 0;

            return File(stream, "text/plain", downloadFileName);
        }
    }
}