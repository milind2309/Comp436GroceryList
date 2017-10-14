using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

/// <summary>
/// Summary description for StaticHelpers
/// </summary>
public static class StaticHelpers
{
    public static T ParseXML<T>(this string @this) where T : class
    {
        var reader = XmlReader.Create(@this.Trim().ToStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
        return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
    }

    public static Stream ToStream(this string @this)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(@this);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }

    public static string ToString(this XmlNode node, int indentation)
    {
        using (var sw = new StringWriter())
        {
            using (var xw = new XmlTextWriter(sw))
            {
                xw.Formatting = Formatting.Indented;
                xw.Indentation = indentation;
                node.WriteContentTo(xw);
            }
            return sw.ToString();
        }
    }

    public static string ToInnerText(this XmlNode node)
    {
        if (node == null) return string.Empty;
        return node.InnerText;
    }

    public static string ToInnerValue(this XElement el)
    {
        if (el == null) return string.Empty;
        return el.Value;
    }    

}