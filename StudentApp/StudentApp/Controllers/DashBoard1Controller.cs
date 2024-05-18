using Microsoft.AspNetCore.Mvc;
using StudentApp.Filters;
using StudentApp.Models;
using StudentApp.ViewModels.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Velzon.Controllers
{
    //[Isconnected]
    public class DashBoard1Controller : Controller
    {
        private readonly U669885128UZsNtContext _context;
        public DashBoard1Controller(U669885128UZsNtContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ActionName("Analytics")]
        public IActionResult Analytics()
        {
            int totalStudents = _context.Students.Count();
            int TotalPublishers = _context.Publishers.Count();
            int TotalAbonneent = _context.Abonnements.Count();
            int totalActiveAds = _context.Campaigns.Where(ad => ad.DateDebut <= DateTime.Now && ad.DateFin >= DateTime.Now).Count();

            var studentsByQuartier = _context.Cartiers
                .Join(_context.Students,
                    quartier => quartier.Id,
                    etudiant => etudiant.Cartier,
                    (quartier, etudiant) => new { Quartier = quartier.Libelle })
                .GroupBy(q => q.Quartier)
                .ToDictionary(g => g.Key, g => g.Count());

            var quartierPercentages = new Dictionary<string, double>();
            foreach (var entry in studentsByQuartier)
            {
                double percentage = (double)entry.Value / totalStudents * 100;
                quartierPercentages.Add(entry.Key, percentage);
            }


            var lignesWithTotalSubscriptions = _context.AbonnementLignes
            .GroupBy(l => l.NumLine)
            .ToDictionary(g => g.Key, g => g.Count());


            // Calculer le nombre de clics par campagne
            Dictionary<int, int> ClicksByCampaign = _context.Clicks
                .GroupBy(c => c.IdCampain)
                .ToDictionary(g => g.Key, g => g.Count());



            var viewModel = new AnalyticsVM
            {
                TotalStudents = totalStudents,
                TotalPublishers = TotalPublishers,
                totalActiveAds = totalActiveAds,
                TotalAbonneent = TotalAbonneent,
                lignesWithTotalSubscriptions = lignesWithTotalSubscriptions,
                StudentsByQuartier = studentsByQuartier,
                QuartierPercentages = quartierPercentages,
                ClicksByCampaign = ClicksByCampaign
            };

            return View(viewModel);
        }


        [ActionName("GetAnalyticsData")]
        [HttpPost]
        public IActionResult GetAnalyticsData()
        {
            int totalClicks = _context.Clicks.Count();

            Dictionary<string, int> ClicksByOS = _context.Clicks
                .GroupBy(c => c.Os)
                .ToDictionary(g => g.Key, g => g.Count());

            Dictionary<string, double> ClicksPercentageByOS = ClicksByOS
                .ToDictionary(kv => kv.Key, kv => (double)kv.Value / totalClicks * 100);

            List<string> osKeys = ClicksByOS.Keys.ToList();

            List<int> osValues = ClicksByOS.Values.ToList();

            // Formater les pourcentages avec deux chiffres après la virgule
            List<string> osPercentages = ClicksPercentageByOS.Values.Select(p => p.ToString("0.##")).ToList();

            return Json(new { keys = osKeys, values = osValues, percentages = osPercentages });

        }


        [ActionName("GetSubscriptionsData")]
        [HttpPost]
        public IActionResult GetSubscriptionsData()
        {
            int totalSubscriptions = _context.AbonnementLignes.Count();

            Dictionary<int, int> SubscriptionsByLine = _context.AbonnementLignes
                .GroupBy(c => c.NumLine)
                .ToDictionary(g => g.Key, g => g.Count());

            Dictionary<int, double> SubscriptionsPercentageByLine = SubscriptionsByLine
                .ToDictionary(kv => kv.Key, kv => (double)kv.Value / totalSubscriptions * 100);

            List<int> lineKeys = SubscriptionsByLine.Keys.ToList();
            List<int> lineValues = SubscriptionsByLine.Values.ToList();
            List<string> linePercentages = SubscriptionsPercentageByLine.Values.Select(p => p.ToString("0.##")).ToList();

            return Json(new { keys = lineKeys, values = lineValues, percentages = linePercentages });
        }









        [ActionName("CRM")]
        public IActionResult CRM()
        {
            return View();
        }

        [ActionName("Crypto")]
        public IActionResult Crypto()
        {
            return View();
        }

        [ActionName("Projects")]
        public IActionResult Projects()
        {
            return View();
        }

        [ActionName("NFT")]
        public IActionResult NFT()
        {
            return View();
        }

        [ActionName("Job")]
        public IActionResult Job()
        {
            return View();
        }

    }
}
