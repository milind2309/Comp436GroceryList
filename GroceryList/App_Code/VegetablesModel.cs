using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Vegetables
/// </summary>
public class VegetablesModel
{
    public VegetablesModel()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Name { get; set; }
    public string ID { get; set; }
    public bool IsPopular { get; set; }
    public string Calories { get; set; }
    public string ServingSize { get; set; }
    public string ImageName { get; set; }
    public string Fat { get; set; }
    public string Cholesterol { get; set; }
    public string Sodium { get; set; }
    public string Potassium { get; set; }
    public string Carbs { get; set; }
    public string Protein { get; set; }    
    
}