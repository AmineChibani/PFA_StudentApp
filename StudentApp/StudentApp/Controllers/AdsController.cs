using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentApp.Filters;
using StudentApp.Models;
using StudentApp.ViewModels.Ads;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static Twilio.Rest.Content.V1.ContentResource;

namespace StudentApp.Controllers
{
    [Isconnected]
    public class AdsController : Controller
    {
        private readonly U669885128UZsNtContext _context;
        public AdsController(U669885128UZsNtContext context)
        {
            this._context = context;
        }


        public IActionResult Index()
        {
            var adsWithAllData = _context.Campaigns
            .Include(c => c.Clicks)
            .Include(c => c.IdAgeRangeNavigation)
            .Include(c => c.IdLocationNavigation)
            .Include(c => c.IdPublisherNavigation)
            .Include(c => c.IdTypeNavigation)
            .Include(c => c.CampainOs)
            .ThenInclude(c => c.IdOsNavigation)
            .ToList();
            return View(adsWithAllData);
        }


        public IActionResult AjouterAd()
        {
            AjouterAdVM ad = new AjouterAdVM();

            List<AgeRange> ranges = _context.AgeRanges.ToList();
            List<Location> Locations = _context.Locations.ToList();
            List<Publisher> publishers = _context.Publishers.ToList();
            List<AdType> AdTypes = _context.AdTypes.ToList();
            ad.Os = _context.Os.ToList();

            ad.ageRanges = ranges.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Max.ToString() + " - "+ r.Min.ToString() 
            }).ToList();

            ad.locations = Locations.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(), 
                Text = l.Libelle
            }).ToList();

            
            ad.publishers = publishers.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(), 
                Text = p.Name 
            }).ToList();

          
            ad.types = AdTypes.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(), 
                Text = t.Libelle
            }).ToList();

             



            return View(ad);
        }


        [HttpPost]
        public IActionResult AjouterAd(AjouterAdVM ad)
        {
            if (ad.DateDebut < DateTime.Now)
            {
                ModelState.AddModelError("DateDebut", "La date de début ne peut pas être dans le passé.");
            }

            if (ad.DateDebut > ad.DateFin)
            {
                ModelState.AddModelError("DateFin", "La date de fin doit être superieur à la date de debut.");
            }

            


            if (ModelState.IsValid)
            {
                
                try
                {
                    
                    _context.Database.BeginTransaction();
                    Campaign cam = new Campaign();
                    cam.DateDebut = ad.DateDebut;
                    cam.DateFin = ad.DateFin;
                    cam.Budget = ad.Budget;
                    cam.ContentUrl = ad.ContentUrl;
                    cam.AdUrl = ad.AdUrl;
                    cam.IdType = ad.IdType;
                    cam.IdPublisher = ad.IdPublisher;
                    cam.IdAgeRange = ad.IdAgeRange;
                    cam.IdLocation = ad.IdLocation;

                    _context.Campaigns.Add(cam);
                    _context.SaveChanges();

                    foreach (var os in ad.oschoix)
                    {
                        CampainO campainOs = new CampainO();
                        campainOs.IdCampaign = cam.Id;
                        campainOs.IdOs = os;
                        _context.CampainOs.Add(campainOs);
                    }
                    _context.SaveChanges();
                    _context.Database.CommitTransaction();


                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    _context.Database.RollbackTransaction();
                }
            }


            List<AgeRange> ranges = _context.AgeRanges.ToList();
            List<Location> Locations = _context.Locations.ToList();
            List<Publisher> publishers = _context.Publishers.ToList();
            List<AdType> AdTypes = _context.AdTypes.ToList();
            ad.Os = _context.Os.ToList();

            ad.ageRanges = ranges.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Max.ToString() + " - " + r.Min.ToString()
            }).ToList();

            ad.locations = Locations.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Libelle
            }).ToList();


            ad.publishers = publishers.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();


            ad.types = AdTypes.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Libelle
            }).ToList();

            return View(ad);
        }


        public IActionResult removeAd(int Id)
        {
            Campaign c = _context.Campaigns.FirstOrDefault(c => c.Id == Id);
            if (c != null)
            {
                _context.Campaigns.Remove(c);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
            



    }
}
