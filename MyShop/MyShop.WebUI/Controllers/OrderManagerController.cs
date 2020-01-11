using System.Collections.Generic;
using System.Web.Mvc;
using MyShop.Core.Contracts;
using MyShop.Core.Models;

namespace MyShop.WebUI.Controllers
{
    public class OrderManagerController : Controller
    {
        private IOrderService _orderService;

        public OrderManagerController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        // GET: OrderManager
        public ActionResult Index()
        {
            List<Order> orders = _orderService.GetOrderList();

            return View(orders);
        }

        public ActionResult UpdateOrder(string Id)
        {
            ViewBag.StatusList = new List<string>()
            {
                "Order Created",
                "Payment Processed",
                "Order Shipoed",
                "Order Complated"
            };
            Order order = _orderService.GetOrder(Id);
            return View(order);
        }

        public ActionResult UpdateOrder(Order updatedOrder, string Id)
        {
            Order order = _orderService.GetOrder(Id);

            order.Orderstatus = updatedOrder.Orderstatus;
            _orderService.UpdateOrder(order);
            return RedirectToAction("Index");
        }
    }
}