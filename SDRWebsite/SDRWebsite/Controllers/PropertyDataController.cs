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
    public class PropertyDataController : Controller
    {
        // GET: PropertyData
        public ActionResult Index()
        {
            return View();
        }

        // GET: PropertyData/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PropertyData/Create
        public async Task<ActionResult> Create()
        {
            var stateList = new List<StateModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("http://sdrwebapi:8001/api/State");
                if (response.IsSuccessStatusCode)
                {
                    stateList = await response.Content.ReadAsAsync<List<StateModel>>();
                }
            }

            ViewBag.StateID = new SelectList(stateList, "id", "name", null);

            //await PopulateStatesDropDownList();
            return View();
        }

        // POST: PropertyData/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PropertyData propertyData)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:9000/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // New code:
                    HttpResponseMessage response = await client.PostAsJsonAsync("http://sdrwebapi:8001/api/Property", propertyData);
                    if (response.IsSuccessStatusCode)
                    {
                        //Uri gizmoUrl = response.Headers.Location;
                        
                    }
                }

                return RedirectToAction("Index","Property");
            }
            catch
            {
                return View();
            }
        }

        // GET: PropertyData/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PropertyData/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PropertyData/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PropertyData/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public async Task<ActionResult> PopulateStatesDropDownList(object selectedState = null)
        //{
        //    var stateList = new List<StateModel>();

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:9000/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        // New code:
        //        HttpResponseMessage response = await client.GetAsync("http://sdrwebapi:8001/api/State");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            stateList = await response.Content.ReadAsAsync<List<StateModel>>();
        //        }
        //    }
           
        //    ViewBag.StateID = new SelectList(stateList, "StateID", "Name", selectedState);    
        //    return null;
        //}
    }
}
