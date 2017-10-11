using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;



public partial class Popular : System.Web.UI.Page
{
    protected List<FruitsModel> FruitsData = new List<FruitsModel>();
    protected List<VegetablesModel> VegetablesData = new List<VegetablesModel>();
    protected List<DairyProductsModel> DairyProductsData = new List<DairyProductsModel>();

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadPopularFruits();
        LoadPopularVegetables();
    }

    public void LoadPopularFruits()
    {
        string xml = File.ReadAllText(Server.MapPath("~/xmldata/fruits.xml"));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("/fruits/fruit");
        foreach (XmlNode node in nodes)
        {
            if (node.Attributes["popular"] != null)
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
    }

    public void LoadPopularVegetables()
    {
        string xml = File.ReadAllText(Server.MapPath("~/xmldata/vegetables.xml"));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("/vegetables/vegetable");
        foreach (XmlNode node in nodes)
        {
            if (node.Attributes["popular"] != null)
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
    }

    public void LoadDairyProducts()
    {
        string xml = File.ReadAllText(Server.MapPath("~/xmldata/dairyproducts.xml"));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("/dairyproducts/dairy");
        foreach (XmlNode node in nodes)
        {
            if (node.Attributes["popular"] != null)
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
    }
}