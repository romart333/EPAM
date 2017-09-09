namespace Task01.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Web.Configuration;
    using System.Web.Mvc;
    using AutoMapper;
    using ClassLibrary;
    using Task01.Models;

    public class HomeController : Controller
    {
        private DAL dal = new DAL();

        //  GET: Home
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            if (page <= 0)
            {
                return HttpNotFound();
            }

            var pageInfo = new PageInfo()
            {
                PageNumber = page,
                TotalItems = dal.GetTotalCountOrders()
            };

            var pageSize = pageInfo.PageSize;

            var orders = dal.GetOrders(((page - 1) * pageSize) + 1, page * pageSize);
            if (orders == null)
            {
                return HttpNotFound();
            }

            Mapper.Initialize(cfg => cfg.CreateMap<Order, BriefOrder>()
                .ForMember(
                dest => dest.OrderState,
                opt => opt.MapFrom(src => Enum.GetName(
                    typeof(enumOrderState),
                    src.OrderState)))); // преобразуем enum состояния заказа к строке
            var briefOrders = Mapper.Map<IEnumerable<Order>, List<BriefOrder>>(orders);
            for (int i = 0; i < orders.Count; i++)
            {
                briefOrders[i].Sum = dal.GetExtendedPrice(briefOrders[i].OrderID);
            }

            var model = new IndexOrderViewModel()
            {
                Orders = briefOrders,
                Page = pageInfo
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateProduct(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CreateProductViewModel model = new CreateProductViewModel();
            ViewBag.OrderID = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateProduct(CreateProductViewModel model, string button)
        {
            ViewBag.ErrorMessage = "Incorrect data";
            if (button == null)
            {
                return View(model);
            }

            if (button == "Cancel")
            {
                return RedirectToAction("Index", "Home");
            }

            if (model == null || !ModelState.IsValid)
            {
                
                return View(model);
            }

            dal.AddProduct(
                model.OrderID,
                model.ProductName,
                model.UnitPrice,
                model.Discount,
                model.Quantity);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DisplayDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var order = dal.GetInfoOrder((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }

            Mapper.Initialize(cfg => cfg.CreateMap<Order, OrderDetailsViewModel>()
            .ForMember(
                dest => dest.OrderState,
                opt => opt.MapFrom(src => Enum.GetName(typeof(enumOrderState), src.OrderState))));
            var model = Mapper.Map<Order, OrderDetailsViewModel>(order);

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrder(OrderDetailsViewModel model, string button)
        {
            if (button == "Cancel")
            {
                return RedirectToAction("Index", "Home");
            }
            
            if (model == null || !ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Incorrect data";
                return View();
            }

            dal.AddOrder(
                model.OrderDate,
                model.RequiredDate,
                model.ShippedDate,
                model.Freight,
                model.ShipName,
                model.ShipAddress,
                model.ShipCity,
                model.ShipRegion,
                model.ShipPostalCode,
                model.ShipCountry);

            return RedirectToAction("Index", "Home");
        }
    }
}