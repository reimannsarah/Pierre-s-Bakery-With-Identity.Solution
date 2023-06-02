using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bakery.Controllers;

public class FlavorsController : Controller
{
  private readonly BakeryContext _db;

  public FlavorsController(BakeryContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    List<Flavor> model = _db.Flavors.ToList();
    return View(model);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Flavor flavor)
  {
    if(!ModelState.IsValid)
    {
      return View(flavor);
    }
    else
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
    
  public ActionResult Details(int id)
  {
    Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
    return View(thisFlavor);
  }

  public ActionResult AddTreat(int id)
  {
    Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
    ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
    return View(thisFlavor);
  }

  [HttpPost]
  public ActionResult AddTreat(Flavor flavor, int treatId)
  {
#nullable enable
    FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(join => (join.TreatId == treatId && join.FlavorId == flavor.FlavorId));
#nullable disable
    if (joinEntity == null && treatId != 0)
    {
      _db.FlavorTreats.Add(new FlavorTreat() { TreatId = treatId, FlavorId = flavor.FlavorId});
      _db.SaveChanges();
    }
    return RedirectToAction("Details", new { id = flavor.FlavorId });
  }
} 