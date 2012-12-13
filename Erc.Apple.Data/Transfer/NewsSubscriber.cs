using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
[Serializable]
public class NewsSubscriber
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
    protected string email;
    [XmlAttribute]
    public string Email
    { 
        get
        {
            return email;
        }
        set
        {
            email = value;
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

    public NewsSubscriber()
    {
    }

    public NewsSubscriber(DbDataReader r)
    {
        this.ID = Convert.ToInt32(r["ID"]);
        this.Name = Convert.ToString(r["Name"]);
        this.Email = Convert.ToString(r["Email"]);
        this.DateCreated = Convert.ToDateTime(r["DateCreated"]);
    }
}

}