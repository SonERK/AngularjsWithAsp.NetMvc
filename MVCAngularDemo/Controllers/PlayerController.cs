using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAngularDemo.Models;

namespace MVCAngularDemo.Controllers
{
    public class PlayerController : Controller
    {
        private DbOnlineCup _context = null;
        public PlayerController()
        {
            _context = new DbOnlineCup();
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult GetPlayers()
        {
            var players = _context.Players.ToList();

            return Json(players,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPlayer(int playerId)
        {
            var player = _context.Players.First(p => p.PlayerId == playerId);

            return Json(player, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddPlayer(Player player)
        {
            player.RegisterationDate = DateTime.Now;

            _context.Players.Add(player);

            _context.SaveChanges();

            var players = _context.Players.ToList();

            return Json(players);
        }

        [HttpPost]
        public JsonResult UpdatePlayer(Player player)
        {
            _context.Entry(player).State=System.Data.Entity.EntityState.Modified;

            _context.SaveChanges();

            var players = _context.Players.ToList();

            return Json(players);
        }

        [HttpPost]
        public JsonResult DeletePlayer(int playerId)
        {
            var player = _context.Players.First(p => p.PlayerId == playerId);
            _context.Players.Remove(player);

            _context.SaveChanges();

            var players = _context.Players.ToList();

            return Json(players);
        }

        public JsonResult GetCountries()
        {
            var countries = _context.Countries.ToList();

            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetProvinces(int? countryId)
        {
            var provinces = _context.Provinces.Where(p => p.CountryId == countryId).ToList();

            return Json(provinces);
        }
    }
}