using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;

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
        try
        {
            string xml = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/xmldata/dairyproducts.xml"));
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/dairyproducts/dairy[@id='" + id + "']");

            if (nodes == null || nodes.Count <= 0) return string.Empty;

            // Load the style sheet.
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(System.Web.Hosting.HostingEnvironment.MapPath("~/xsl/dairyproducts.xsl"));

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