using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;

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
        try
        {
            string xml = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/xmldata/vegetables.xml"));
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/vegetables/vegetable[@id='" + id + "']");

            if (nodes == null || nodes.Count <= 0) return string.Empty;

            // Load the style sheet.
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(System.Web.Hosting.HostingEnvironment.MapPath("~/xsl/vegetables.xsl"));

            //prepare an xml document from the xmlnode
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(nodes[0].OuterXml);

            // Transform the file and output an HTML string.
            string HTMLoutput;
            StringWriter writer = new StringWriter();
            xslt.Transform(xmlDoc, null, writer);
            HTMLoutput = writer.ToString();
            writer.Close();
            return HTMLoutput;
        }
        catch (Exception ex)
        {
            return string.Empty;
        }
    }
}