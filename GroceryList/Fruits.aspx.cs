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
                Name = node.InnerText
            });
        }
    }

}