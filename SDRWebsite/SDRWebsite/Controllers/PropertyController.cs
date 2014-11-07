using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SDRWebsite.Models;

namespace SDRWebsite.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        public async Task<ActionResult> Index()
        {
            var property = new List<PropertyListData>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("http://sdrwebapi:8001/api/Property");
                if (response.IsSuccessStatusCode)
                {
                     property = await response.Content.ReadAsAsync<List<PropertyListData>>();                  
                }
            }
            return View(property);
        }
    }
}