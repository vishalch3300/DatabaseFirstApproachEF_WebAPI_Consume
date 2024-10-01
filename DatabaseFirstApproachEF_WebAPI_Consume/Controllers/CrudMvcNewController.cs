using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DatabaseFirstApproachEF_WebAPI_Consume.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace DatabaseFirstApproachEF_WebAPI_Consume.Controllers
{
    public class CrudMvcNewController : Controller
    {
        string BaseUrl = "https://localhost:44314";

        //READ-------------------------------------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<Employee> empInfo = new List<Employee>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/CrudApi");
                if (res.IsSuccessStatusCode)
                {
                    var empResponse = res.Content.ReadAsStringAsync().Result;
                    empInfo = JsonConvert.DeserializeObject<List<Employee>>(empResponse);
                }
            }
            return View(empInfo);
        }

        //Details-------------------------------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            Employee emp = new Employee();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/CrudApi/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var empResponse = res.Content.ReadAsStringAsync().Result;
                    emp = JsonConvert.DeserializeObject<Employee>(empResponse);
                }
            }
            return View(emp);
        }

        //CREATE-----------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = client.PostAsJsonAsync("api/CrudApi", emp).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Create");
        }

        //Update or Edit---------------------------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Employee emp = new Employee();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/CrudApi/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var empResponse = res.Content.ReadAsStringAsync().Result;
                    emp = JsonConvert.DeserializeObject<Employee>(empResponse);
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = client.PutAsJsonAsync("api/CrudApi", emp).Result;

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Edit");
        }

        //Delete-------------------------------------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Employee emp = new Employee();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/CrudApi/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var empResponse = res.Content.ReadAsStringAsync().Result;
                    emp = JsonConvert.DeserializeObject<Employee>(empResponse);
                }
            }
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = client.DeleteAsync("api/CrudApi/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View("Delete");
        }
    }
}