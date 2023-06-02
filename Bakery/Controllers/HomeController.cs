using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bakery.Controllers;

public class HomeController : Controller
{
  private readonly BakeryContext _db;

  public HomeController(BakeryContext db)
  {
    _db = db;
  }

  [HttpGet("/")]
  public ActionResult Index()
  {
    List<Flavor> flavors = _db.Flavors.ToList();
    List<Treat> treats = _db.Treats.ToList();
    ViewBag.flavors = flavors;
    ViewBag.treats = treats;
    return View();
  }
}