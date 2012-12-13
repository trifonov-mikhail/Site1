using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
[Serializable]
public class ContentPage
{
    protected int id;
    [XmlAttribute]
    public int ID
    { 
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
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
    public ContentPage()
    {
    }
    public ContentPage(DbDataReader r)
    {
        ID = Convert.ToInt32(r["ID"]);
        Name = Convert.ToString(r["Name"]);
    }
}

}