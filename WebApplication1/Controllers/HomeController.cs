using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Tour tour = new Tour();

            var t = from d in tour.db.TourTable
                    select d;

            List<string> list = new List<string>();

            foreach (var item in t)
            {
                string[] start = item.DateTourStart.ToString().Split(' ');
                string[] end = item.DateTourEnd.ToString().Split(' ');
                
                list.Add(item.City.ToString().TrimEnd() + " Начало тура- " + start[0] + " Конец тура- " + end[0] + " Цена- " + item.Price);
            }

            tour.Tours = GetSelectListItems(list);
            
            return View(tour);
        }

        [HttpPost]
        public ActionResult Next(Tour tour)
        {
            string[] parse_selected = tour.SelectedTour.Split(' ');

            tour.City = parse_selected[0];
            tour.DateTourStart = Convert.ToDateTime(parse_selected[3]);
            tour.DateTourEnd = Convert.ToDateTime(parse_selected[6]);
            tour.Price = Convert.ToInt32(parse_selected[8]);

            TempData["ArrayData"] = parse_selected;

            return View(tour);
        }

        //[HttpPost]
        public ActionResult Final(FormCollection form)
        {
            Tourist tourist = new Tourist();
            Tour tour = new Tour();

            tourist.Name = form["txt_Name"];
            tourist.SecondName = form["txt_SecondName"];
            tourist.ThirdName = form["txt_ThirdName"];
            tourist.Passport = form["txt_Passport"];
            tourist.CreditCard = form["txt_CreditCard"];

            ViewBag.ArrayData = TempData["ArrayData"];

            tour.City = ViewBag.ArrayData[0];
            tour.DateTourStart = Convert.ToDateTime(ViewBag.ArrayData[3]);
            tour.DateTourEnd = Convert.ToDateTime(ViewBag.ArrayData[6]);
            tour.Price = Convert.ToInt32(ViewBag.ArrayData[8]);

            SaveToDB(tourist);

            var tuple = new Tuple<Tour, Tourist>(tour, tourist);

            return View(tuple);
        }


        public void SaveToDB(Tourist tourist)
        {
            Database1Entities db = new Database1Entities();

            TouristTable tb = new TouristTable
            {
                Name = tourist.Name,
                SecondName = tourist.SecondName,
                ThirdName = tourist.ThirdName,
                Passport = tourist.Passport,
                CreditCard = tourist.CreditCard
            };
            

            db.TouristTable.Add(tb);
            db.SaveChanges();
        }


        public void MakeFileToMail(Tour tour, Tourist tourist)
        {
            



        }

        public Tour GetFields(string[] fields)
        {
            Tour tour = new Tour()
            {
                City = fields[0],
                DateTourStart = Convert.ToDateTime(fields[3]),
                DateTourEnd = Convert.ToDateTime(fields[6]),
                Price = Convert.ToInt32(fields[8])
            };
                                 
            return tour;
        }

        public IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            var selectList = new List<SelectListItem>();

            foreach (var item in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item,
                    Text = item
                });
            }

            return selectList;
        }
    }
}