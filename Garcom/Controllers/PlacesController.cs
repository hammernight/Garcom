using System;
using System.Web.Mvc;
using Garcom.Models;

namespace Garcom.Controllers
{
    public class PlacesController : Controller
    {
        private readonly AllPlaces _allPlaces;

        public PlacesController(AllPlaces allPlaces)
        {
            _allPlaces = allPlaces;
        }

        public ViewResult New()
        {
            return View();
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Create(Place place)
        {
            _allPlaces.Save(place);
            return RedirectToAction("index","places");
        }
    }
}