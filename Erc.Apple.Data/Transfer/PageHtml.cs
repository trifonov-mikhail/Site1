using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
[Serializable]
public class PageHtml
{
    protected string name;
    [XmlAttribute]
    public string Name
    { 
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    protected string html;
    [XmlAttribute]
    public string Html
    { 
        get
        {
            return html;
        }
        set
        {
            html = value;
        }
    }
    protected DateTime dateCreated;
    [XmlAttribute]
    public DateTime DateCreated
    { 
        get
        {
            return dateCreated;
        }
        set
        {
            dateCreated = value;
        }
    }
    public PageHtml()
    {
    }

    public PageHtml(DbDataReader r)
    {
        this.Name = Convert.ToString(r["Name"]);
        this.Html = Convert.ToString(r["Html"]);
        this.DateCreated = Convert.ToDateTime(r["DateCreated"]);
    }
}

}