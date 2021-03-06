﻿using System.Web.Mvc;
using Garcom.Models;

namespace Garcom.Controllers
{
    public class PlacesController : Controller
    {
        private readonly AllPlaces _allPlaces;

        public PlacesController(AllPlaces allPlaces) { _allPlaces = allPlaces; }

        public ViewResult New() { return View(); }

        public ViewResult Index() { return View("index", _allPlaces.All); }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListOfPlaces() { return PartialView("_listOfPlaces", _allPlaces.All); }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Place place)
        {
            _allPlaces.Save(place);
            return RedirectToAction("index", "places");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateAjax(Place place)
        {
            _allPlaces.Save(place);
            return new EmptyResult();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Place(string id)
        {
            var place = _allPlaces.FindById(id);
            return View(place);
        }
    }
}