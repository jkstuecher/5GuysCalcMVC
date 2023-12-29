using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Sql;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace FiveGuysCalculator.Controllers
{
    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/

        private FiveGuysCalculator.Models.Calculator.Menu GetMenu()
        {
            FiveGuysCalculator.Models.Calculator.Menu returnMenu = new FiveGuysCalculator.Models.Calculator.Menu();

            List<FiveGuysCalculator.Models.Calculator.MenuItem> menuList = new List<FiveGuysCalculator.Models.Calculator.MenuItem>();

            List<string> menuSections = new List<string>();

            DataSet itemsSet = new DataSet(); //will hold data about all the items
            itemsSet.ReadXmlSchema(Server.MapPath("~/Items.xsd")); //get the schema
            itemsSet.ReadXml(Server.MapPath("~/ItemsReOrder.xml")); //get the data
            DataTable itemsTable = itemsSet.Tables[1]; //load data into table

            DataView viewSections = new DataView(itemsTable); //will store info about the sections
            viewSections.Sort = "SectionOrder"; //sort by section sort order
            DataTable distinctSections = viewSections.ToTable(true, "Section"); //build table based on section

            foreach (DataRow dr in distinctSections.Rows) //for each section
            {
                menuSections.Add(dr["Section"].ToString());
                string sectionName = dr["Section"].ToString(); //get section name
                DataView viewMenuItems = new DataView(itemsTable); //will hold menu items under this section
                viewMenuItems.Sort = "ItemOrder"; //sort by Item Order field
                DataTable menuItems = viewMenuItems.ToTable(); //turn view into a table to manipulate
                DataRow[] theseItems = menuItems.Select("Section = '" + sectionName + "'");
                foreach (DataRow midr in theseItems)
                {
                    FiveGuysCalculator.Models.Calculator.MenuItem m = new FiveGuysCalculator.Models.Calculator.MenuItem(midr);
                    menuList.Add(m);
                }
            }

            returnMenu.Items = menuList;
            returnMenu.Categories = menuSections;

            return returnMenu;
        }

        private List<string> GetMenuCategories()
        {
            List<string> returnList = new List<String>();
            return returnList;
        }

        public ActionResult AjaxIndex()
        {
            FiveGuysCalculator.Models.Calculator.Menu menu = GetMenu();

            return View(menu);
        }

        [HttpPost]
        public ActionResult Index(string UpdateTotals, string Reset, FiveGuysCalculator.Models.Calculator.Menu selmenu)
        {
            ModelState.Clear();

            string submitType = UpdateTotals ?? Reset;

            FiveGuysCalculator.Models.Calculator.Menu menu = GetMenu();
            menu.Total = new Models.Calculator.MenuItem();
            menu.SelectedItems = new List<string>();

            int itemCounter = 0;

            if (submitType == "Update Totals")
            {
                foreach (FiveGuysCalculator.Models.Calculator.MenuItem i in selmenu.Items)
                {
                    if (i.Selected) { menu.Items[itemCounter].Selected = true; }
                    itemCounter++;
                }

                foreach (FiveGuysCalculator.Models.Calculator.MenuItem m in menu.Items)
                {
                    if (m.Selected)
                    {
                        menu.SelectedItems.Add(m.ItemName);

                        menu.Total.ServingSize += m.ServingSize;
                        menu.Total.Calories += m.Calories;
                        menu.Total.CaloriesFromFat += m.CaloriesFromFat;
                        menu.Total.TotalFat += m.TotalFat;
                        menu.Total.TransFat += m.TransFat;
                        menu.Total.Cholesterol += m.Cholesterol;
                        menu.Total.Sodium += m.Sodium;
                        menu.Total.Carbs += m.Carbs;
                        menu.Total.Fiber += m.Fiber;
                        menu.Total.Sugar += m.Sugar;
                        menu.Total.Protein += m.Protein;
                    }
                }
            }
            return View(menu);
        }

        /*[HttpPost]
        [MultipleButton(NameValueCollectionExtensions= "action", ArgumentException= "Cancel")]
        public ActionResult Cancel()
        {
            FiveGuysCalculator.Models.Calculator.Menu menu = GetMenu();
            menu.Total = new Models.Calculator.MenuItem();
            menu.SelectedItems = new List<string>();
            return View("Index",menu);
        }*/

        public ActionResult Index()
        {
            FiveGuysCalculator.Models.Calculator.Menu menu = GetMenu();
            menu.Total = new Models.Calculator.MenuItem();
            menu.SelectedItems = new List<string>();
            return View(menu);
        }


        public PartialViewResult Nutrition()
        {
            ViewBag.Derp = "Herpy Derpy";

            return PartialView("_nutrition");
        }

        public ActionResult Accordian()
        {
            return View();
        }

        

    }
}
