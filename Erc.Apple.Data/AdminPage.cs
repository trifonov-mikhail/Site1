using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
[Serializable]
public class AdminPage
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
    protected int? parentID;
    [XmlAttribute]
    public int? ParentID
    { 
        get
        {
            return parentID;
        }
        set
        {
            parentID = value;
        }
    }
    protected string title;
    [XmlAttribute]
    public string Title
    { 
        get
        {
            return title;
        }
        set
        {
            title = value;
        }
    }
    //TabContentTitle
    protected string tabContentTitle;
    [XmlAttribute]
    public string TabContentTitle
    {
        get
        {
            return tabContentTitle;
        }
        set
        {
            tabContentTitle = value;
        }
    }
    protected string url;
    [XmlAttribute]
    public string Url
    { 
        get
        {
            return url;
        }
        set
        {
            url = value;
        }
    }
    protected string control;
    [XmlAttribute]
    public string Control
    { 
        get
        {
            return control;
        }
        set
        {
            control = value;
        }
    }
    protected int orderID;
    [XmlAttribute]
    public int OrderID
    { 
        get
        {
            return orderID;
        }
        set
        {
            orderID = value;
        }
    }
    protected bool active;
    [XmlAttribute]
    public bool Active
    { 
        get
        {
            return active;
        }
        set
        {
            active = value;
        }
    }
    public AdminPage()
    {

    }
    public AdminPage(DbDataReader r)
    {
        this.ID = Convert.ToInt32(r["ID"]);
        this.ParentID = NullableConverter.ToInt32(r["ParentID"]);
        this.Title = Convert.ToString(r["Title"]);
        this.TabContentTitle = Convert.ToString(r["TabContentTitle"]);
        this.Url = Convert.ToString(r["Url"]);
        this.Control = Convert.ToString(r["Control"]);
        this.OrderID = Convert.ToInt32(r["OrderID"]);
        this.Active = Convert.ToBoolean(r["Active"]);
    }
}

}