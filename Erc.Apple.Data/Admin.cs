using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
[Serializable]
public class Admin
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
    protected string password;
    [XmlAttribute]
    public string Password
    { 
        get
        {
            return password;
        }
        set
        {
            password = value;
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
    public Admin()
    {
    }
    public Admin(DbDataReader r)
    {
        ID = Convert.ToInt32(r["ID"]);
        Name = Convert.ToString(r["Name"]);
        Email = Convert.ToString(r["Email"]);
        //Password = Convert.ToString(r["Password"]);
        DateCreated = Convert.ToDateTime(r["DateCreated"]);
    }
}

}