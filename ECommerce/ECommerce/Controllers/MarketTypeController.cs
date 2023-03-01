using ECommerce.Data;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
   public class MarketTypeController : Controller
   {
      private readonly ApplicationDbContext _context;

      public MarketTypeController()
		{
         _context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// GET: MarketType
		public ActionResult Index()
      {
         var marketTypes = _context.MarketTypes.ToList();
         return View(marketTypes);
      }

      // GET: MarketType/Details/5
      public ActionResult Details(int id)
      {
         var marketType = _context.MarketTypes.SingleOrDefault(d => d.Id == id);
         if (marketType == null)
			{
            return HttpNotFound("The market type not found");
			}
         return View(marketType);
      }

      // GET: MarketType/Create
      public ActionResult Create()
      {
         return View();
      }

      // POST: MarketType/Create
      [HttpPost]
      public ActionResult Create(MarketTypeModel model)
      {
         try
         {
            if (!ModelState.IsValid)
            {
               return View(model);
            }

            // check if market type is exists.
            var marketType = _context.MarketTypes.SingleOrDefault(c => c.Name == model.Name);
            if (marketType != null)
            {
               ModelState.AddModelError("Name", "The market type is already exist.");
               return View(model);
            }
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
               cfg.CreateMap<MarketType, MarketTypeModel>();
               cfg.CreateMap<MarketTypeModel, MarketType>();
            });

            var mapper = config.CreateMapper();

            var newMarketType = mapper.Map<MarketType>(model);

            _context.MarketTypes.Add(newMarketType);
            _context.SaveChanges();

            return RedirectToAction("Index");
         }
         catch
         {
            ModelState.AddModelError("", "An Exception Occured.");
            return View(model);
         }
      }

		// GET: MarketType/Edit/5
		public ActionResult Edit(int id)
      {
         var marketType = _context.MarketTypes.SingleOrDefault(m => m.Id == id);
         if (marketType == null)
			{
            ModelState.AddModelError("", "Market Type not exists");
            return RedirectToAction("Index");
			}
         var config = new AutoMapper.MapperConfiguration(cfg =>
         {
            cfg.CreateMap<MarketType, MarketTypeModel>();
            cfg.CreateMap<MarketTypeModel, MarketType>();
         });

         var mapper = config.CreateMapper();

         var marketTypeModel = mapper.Map<MarketTypeModel>(marketType);
         return View(marketTypeModel);
      }

      // POST: MarketType/Edit/5
      [HttpPost]
      public ActionResult Edit(int id, MarketTypeModel model)
      {
         try
         {
            if (!ModelState.IsValid)
				{
               return View(model);
				}

            var oldMartketType = _context.MarketTypes.SingleOrDefault(m => m.Id == id);
            if (model.Name != oldMartketType.Name)
				{
               oldMartketType.Name = model.Name;
            } 
            else if (model.Description != oldMartketType.Description)
				{
               oldMartketType.Description = model.Description;
				}
            else
				{
               ModelState.AddModelError("", "There is no changes.");
               return View(model);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
         }
         catch
         {
            return View();
         }
      }

      // POST: MarketType/Delete
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Delete(FormCollection collection)
      {
         try
         {
            var id = int.Parse(collection["Id"]);
            var marketType = _context.MarketTypes.Find(id);
            if (marketType == null)
            {
               ModelState.AddModelError("", "Market type not exists.");
               return RedirectToAction("Index");
            }

            _context.MarketTypes.Remove(marketType);
            _context.SaveChanges();
            return RedirectToAction("Index");
         }
         catch
			{
            return RedirectToAction("Index");
         }
      }
   }
}
