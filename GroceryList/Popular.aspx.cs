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
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadPopularFruits();
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
}