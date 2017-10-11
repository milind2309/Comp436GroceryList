using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Dairy : System.Web.UI.Page
{
    protected List<DairyProductsModel> DairyProductsData = new List<DairyProductsModel>();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDairyProducts();
    }

    public void LoadDairyProducts()
    {
        string xml = File.ReadAllText(Server.MapPath("~/xmldata/dairyproducts.xml"));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("/dairyproducts/dairy");
        foreach (XmlNode node in nodes)
        {
            DairyProductsData.Add(new DairyProductsModel
            {
                ID = node.Attributes["id"].Value,
                ImageName = node.Attributes["imagename"] != null ? node.Attributes["imagename"].Value : string.Empty,
                Name = StaticHelpers.ToInnerText(node["name"]),
                Calories = StaticHelpers.ToInnerText(node["calories"])
            });
        }
    }

    [System.Web.Services.WebMethod]
    public static string GetDairyProductDetails(int id)
    {
        string xml = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/xmldata/dairyproducts.xml"));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("/dairyproducts/dairy[@id='" + id + "']");
        //ideally id is unique so for loop will only run 1 time
        DairyProductsModel dairy = null;
        foreach (XmlNode node in nodes)
        {
            dairy = new DairyProductsModel
            {
                Name = StaticHelpers.ToInnerText(node["name"]),
                Calories = StaticHelpers.ToInnerText(node["calories"]),
                Carbs = StaticHelpers.ToInnerText(node["carbs"]),
                Cholesterol = StaticHelpers.ToInnerText(node["cholesterol"])
            };
        }
        return Newtonsoft.Json.JsonConvert.SerializeObject(dairy);
    }
}