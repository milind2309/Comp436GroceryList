using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Fruits : System.Web.UI.Page
{
    protected List<FruitsModel> FruitsData = new List<FruitsModel>();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadFruits();
    }

    public void LoadFruits()
    {
        string xml = File.ReadAllText(Server.MapPath("~/xmldata/fruits.xml"));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("/fruits/fruit");
        foreach (XmlNode node in nodes)
        {
            FruitsData.Add(new FruitsModel
            {
                ID = node.Attributes["id"].Value,
                ImageName = node.Attributes["imagename"] != null ? node.Attributes["imagename"].Value : string.Empty,
                Name = StaticHelpers.ToInnerText(node["name"]),
                Calories = StaticHelpers.ToInnerText(node["calories"])
            });
        }
    }

    [System.Web.Services.WebMethod]
    public static string GetFruitDetails(int id)
    {
        string xml = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/xmldata/fruits.xml"));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("/fruits/fruit[@id='" + id + "']");
        //ideally id is unique so for loop will only run 1 time
        FruitsModel fruit = null;
        foreach(XmlNode node in nodes)
        {
            fruit = new FruitsModel
            {
                Name = StaticHelpers.ToInnerText(node["name"]),
                Calories = StaticHelpers.ToInnerText(node["calories"]),
                Carbs = StaticHelpers.ToInnerText(node["carbs"]),
                Cholesterol = StaticHelpers.ToInnerText(node["cholesterol"])
            };
        }
        return Newtonsoft.Json.JsonConvert.SerializeObject(fruit);
    }
}