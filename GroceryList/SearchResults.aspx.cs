using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

public partial class SearchResults : System.Web.UI.Page
{
    protected List<FruitsModel> FruitsData = new List<FruitsModel>();
    protected List<VegetablesModel> VegetablesData = new List<VegetablesModel>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadSearchResults();
        }
    }

    private void LoadSearchResults()
    {
        string term = Request.QueryString["term"] != null ? Request.QueryString["term"].ToString() : string.Empty;
        if(!string.IsNullOrEmpty(term))
        {
            term = term.ToLower();
            FindFruits(term);
            FindVegetables(term);
        }       
    }

    private void FindFruits(string term)
    {
        string xml = File.ReadAllText(Server.MapPath("~/xmldata/fruits.xml"));
        var xDoc = XDocument.Parse(xml);
        var fruits = xDoc.Root.Elements("fruit").Where(x => x.Element("name").Value.ToLower().Contains(term)).ToList();

        foreach (XElement el in fruits)
        {
            FruitsData.Add(new FruitsModel
            {
                Name = StaticHelpers.ToInnerValue(el.Element("name")),
                ImageName = el.Attribute("imagename") != null ? el.Attribute("imagename").Value : string.Empty
            });
        }
    }

    private void FindVegetables(string term)
    {
        string xml = File.ReadAllText(Server.MapPath("~/xmldata/vegetables.xml"));
        var xDoc = XDocument.Parse(xml);
        var vegetables = xDoc.Root.Elements("vegetable").Where(x => x.Element("name").Value.ToLower().Contains(term)).ToList();

        foreach (XElement el in vegetables)
        {
            VegetablesData.Add(new VegetablesModel
            {
                Name = StaticHelpers.ToInnerValue(el.Element("name")),
                ImageName = el.Attribute("imagename") != null ? el.Attribute("imagename").Value : string.Empty
            });
        }
    }
}