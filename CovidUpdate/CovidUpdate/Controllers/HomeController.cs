using CovidUpdate.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;


namespace CovidUpdate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Countries> countries = null;
            var uri = "https://api.covid19api.com/summary";
            var syncClient = new WebClient();
            var data = syncClient.DownloadString(uri);
            
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Covid));
            using (var m = new MemoryStream(Encoding.Unicode.GetBytes(data)))
            {
                var covidUpdate = (Covid)serializer.ReadObject(m);
                countries = covidUpdate.Countries;
            }
            

                return View(countries);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}