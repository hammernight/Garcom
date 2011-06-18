using System;
using System.Web.Mvc;
using Garcom.Models;

namespace Garcom.Controllers
{
    public class MenuItemsController : Controller {
        private readonly AllPlaces _allPlaces;

        public MenuItemsController(AllPlaces allPlaces)
        {
            _allPlaces = allPlaces;
        }

        public ActionResult AddMenuItem(string placeId, MenuItem menuItem)
        {
            var place = _allPlaces.FindById(placeId);
            place.Menu.Items.Add(menuItem);
            _allPlaces.Save(place);
            return RedirectToAction("place", "places", new {id = placeId});
        }
    }
}