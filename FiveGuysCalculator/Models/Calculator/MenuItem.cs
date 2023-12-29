using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel.DataAnnotations;


namespace FiveGuysCalculator.Models.Calculator
{
    [Serializable]
    public class MenuItem //: ISerializable
    {
        #region private fields
        private bool _selected = false;
        #endregion private fields

        #region public fields

        public bool Selected { get { return _selected; } set { _selected = value; } }
        
        [Display(Name="Item Name")]
        public string ItemName {get; set;}

        [Display(Name="Serving Size")]
        public double ServingSize {get; set;}

        [Display(Name="Calories")]
        public double Calories { get; set; }

        [Display(Name="Calories From Fat")]
        public double CaloriesFromFat { get; set; }

        [Display(Name="Total Fat")]
        public double TotalFat { get; set; }

        [Display(Name="Saturated Fat")]
        public double SaturatedFat { get; set; }

        [Display(Name="Transfat")]
        public double TransFat { get; set; }

        [Display(Name="Cholesterol")]
        public double Cholesterol { get; set; }

        [Display(Name="Sodium")]
        public double Sodium { get; set; }

        [Display(Name="Carbs")]
        public double Carbs { get; set; }

        [Display(Name="Fiber")]
        public double Fiber { get; set; }

        [Display(Name="Sugar")]
        public double Sugar { get; set; }

        [Display(Name="Protein")]
        public double Protein { get; set; }

        [Display(Name="Serving Size Unit" )]
        public string ServingSizeUnit {get; set;}

        [Display(Name="Section")]
        public string Section { get; set; }

        public double ItemOrder { get; set; }

        public double SectionOrder { get; set; }



        #endregion public fields

        #region Serialization
       /* public MenuItem(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            itemName = (string)info.GetValue("itemName", typeof(string));
            servingSize = (double)info.GetValue("servingSize", typeof(double));
            calories = (double)info.GetValue("calories", typeof(double));
            caloriesFromFat = (double)info.GetValue("caloriesFromFat", typeof(double));
            totalFat = (double)info.GetValue("totalFat", typeof(double));
            saturatedFat = (double)info.GetValue("saturatedFat", typeof(double));
            transFat = (double)info.GetValue("transFat", typeof(double));
            cholesterol = (double)info.GetValue("cholesterol", typeof(double));
            sodium = (double)info.GetValue("sodium", typeof(double));
            carbs = (double)info.GetValue("carbs", typeof(double));
            fiber = (double)info.GetValue("fiber", typeof(double));
            protein = (double)info.GetValue("sugar", typeof(double));
            sugar = (double)info.GetValue("servingSize", typeof(double));
            itemOrder = (double)info.GetValue("itemOrder", typeof(double));
            sectionOrder = (double)info.GetValue("sectionOrder", typeof(double));
            servingSizeUnit = (string)info.GetValue("servingSizeUnit", typeof(string));
            section = (string)info.GetValue("section", typeof(string));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {

            info.AddValue("itemName", itemName);
            info.AddValue("servingSize", servingSize);
            info.AddValue("calories", calories);
            info.AddValue("caloriesFromFat", caloriesFromFat);
            info.AddValue("totalFat", totalFat);
            info.AddValue("saturatedFat", saturatedFat);
            info.AddValue("transFat", transFat);
            info.AddValue("cholesterol", cholesterol);
            info.AddValue("sodium", sodium);
            info.AddValue("carbs", carbs);
            info.AddValue("fiber", fiber);
            info.AddValue("sugar", sugar);
            info.AddValue("protein", protein);
            info.AddValue("itemOrder", itemOrder);
            info.AddValue("sectionOrder", sectionOrder);
            info.AddValue("servingSizeUnit", servingSizeUnit);
            info.AddValue("section", section);

        }*/
        #endregion Serialization

        public MenuItem()
        { }

        public MenuItem(DataRow d)
        {
            ItemName = d["ItemName"].ToString();
            ServingSize = Convert.ToDouble(d["ServingSize"].ToString());
            Calories = Convert.ToDouble(d["Calories"].ToString());
            CaloriesFromFat = Convert.ToDouble(d["CaloriesFromFat"].ToString());
            TotalFat = Convert.ToDouble(d["TotalFat"].ToString());
            SaturatedFat = Convert.ToDouble(d["SaturatedFat"].ToString());
            TransFat = Convert.ToDouble(d["TransFat"].ToString());
            Cholesterol = Convert.ToDouble(d["Cholesterol"].ToString());
            Sodium = Convert.ToDouble(d["Sodium"].ToString());
            Carbs = Convert.ToDouble(d["Carbs"].ToString());
            Fiber = Convert.ToDouble(d["Fiber"].ToString());
            Sugar = Convert.ToDouble(d["Sugar"].ToString());
            Protein = Convert.ToDouble(d["Protein"].ToString());
            ServingSizeUnit = d["ServingSizeUnit"].ToString();
            Section = d["Section"].ToString();     
        }


    }
}