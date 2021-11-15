using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AssessmentOmniAcc.Models;
using Newtonsoft.Json;
using PagedList;

namespace AssessmentOmniAcc.Controllers
{
    public class HomeController : Controller
    {

        //this is the base url for API endpont
        string BaseUrl = "http://st.omniaccounts.co.za:55683";

        public async Task<ActionResult> Index(int? page)
        {

            //Stock[] stock = null;
            List<Stock> stock = null;

            int pageSize = 10;
            int pageNumber = page ?? 1;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllstock using HttpClient
                HttpResponseMessage Res = await client.GetAsync("/Report/Stock%20Export?CompanyName=SA%20Example%20Company%20[Demo]&UserName=Guest&password=Dev2021");

                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var StockResponse = await Res.Content.ReadAsStringAsync();

                    //Deserializing the response recieved from web api and storing into the stock list
                    var res = JsonConvert.DeserializeObject<OurMainObject>(StockResponse).stock_export;
                    stock = res.ToList();


                }
                else
                {
                    //Server error 
                    ModelState.AddModelError(string.Empty, "Server error occured");
                }
               

                return View(stock.ToPagedList(pageNumber, pageSize));
            }

          
          
        }

        public async Task<ActionResult> GetByCode(string SearchString)
        {

            Stock stock = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetItem using HttpClient
                HttpResponseMessage Res = await client.GetAsync("/Report/Stock%20Export?CompanyName=SA%20Example%20Company%20[Demo]&UserName=Guest&password=Dev2021&IBarCode=" + SearchString);

              
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var StockResponse = await Res.Content.ReadAsStringAsync();

                    //Deserializing the response recieved from web api and storing into the stock list
                    var res = JsonConvert.DeserializeObject<OurMainObject>(StockResponse);

                    stock = res.stock_export[0];
                }
                else
                {
                    //Server error occured
                    ModelState.AddModelError(string.Empty, "Server error occured");
                }
                return View(stock);
            }
        }

    }
}