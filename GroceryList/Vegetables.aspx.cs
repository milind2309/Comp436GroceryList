using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Vegetables : System.Web.UI.Page
{
    protected List<VegetablesModel> VegetablesData = new List<VegetablesModel>();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadVegetables();
    }

    public void LoadVegetables()
    {
        string xml = File.ReadAllText(Server.MapPath("~/xmldata/vegetables.xml"));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("/vegetables/vegetable");
        foreach (XmlNode node in nodes)
        {
            VegetablesData.Add(new VegetablesModel
            {
                ID = node.Attributes["id"].Value,
                ImageName = node.Attributes["imagename"] != null ? node.Attributes["imagename"].Value : string.Empty,
                Name = StaticHelpers.ToInnerText(node["name"]),
                Calories = StaticHelpers.ToInnerText(node["calories"])
            });
        }
    }

    [System.Web.Services.WebMethod]
    public static string GetVegetableDetails(int id)
    {
        string xml = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/xmldata/vegetables.xml"));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("/vegetables/vegetable[@id='" + id + "']");
        //ideally id is unique so for loop will only run 1 time
        VegetablesModel vegetable = null;
        foreach (XmlNode node in nodes)
        {
            vegetable = new VegetablesModel
            {
                Name = StaticHelpers.ToInnerText(node["name"]),
                Calories = StaticHelpers.ToInnerText(node["calories"]),
                Carbs = StaticHelpers.ToInnerText(node["carbs"]),
                Cholesterol = StaticHelpers.ToInnerText(node["cholesterol"])
            };
        }
        return Newtonsoft.Json.JsonConvert.SerializeObject(vegetable);
    }
}