using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Fruits
/// </summary>
public class FruitsModel
{
    public FruitsModel()
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
    
}