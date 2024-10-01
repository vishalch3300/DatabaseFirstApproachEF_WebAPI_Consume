using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DatabaseFirstApproachEF_WebAPI_Consume.Models;
using System.Net.Http;

namespace DatabaseFirstApproachEF_WebAPI_Consume.Controllers
{
    public class CrudMvcController : Controller
    {
        HttpClient client = new HttpClient();

        //READ-------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Index()
        {
            List<Employee> emp_list = new List<Employee>();

            //Note - WebAPi XML and JSON all format accepted
            client.BaseAddress = new Uri("https://localhost:44314/api/CrudApi");
            var response = client.GetAsync("CrudApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                //Just install this package System.Net.Http.Formatting.Extension from NuGet (for ReadAsAsync)
                var display = test.Content.ReadAsAsync<List<Employee>>();

                display.Wait();
                emp_list = display.Result;

            }

            return View(emp_list);
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
            client.BaseAddress = new Uri("https://localhost:44314/api/CrudApi");
            var response = client.PostAsJsonAsync<Employee>("CrudApi", emp);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }

        //Update or Edit---------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee e = null;

            client.BaseAddress = new Uri("https://localhost:44314/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }

            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            client.BaseAddress = new Uri("https://localhost:44314/api/CrudApi");
            var response = client.PutAsJsonAsync<Employee>("CrudApi", e);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Edit");
        }

        //Delete-------------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee e = null;

            client.BaseAddress = new Uri("https://localhost:44314/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }

            return View(e);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44314/api/CrudApi");
            var response = client.DeleteAsync("CrudApi/" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Delete");
        }

        //Details-------------------------------------------------------------------------------
        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee e = null;

            client.BaseAddress = new Uri("https://localhost:44314/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Employee>();
                display.Wait();
                e = display.Result;
            }

            return View(e);
        }
    }
}