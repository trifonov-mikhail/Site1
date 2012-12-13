using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
[Serializable]
public class StatusRequest
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
    protected string status;
    [XmlAttribute]
    public string Status
    { 
        get
        {
            return status;
        }
        set
        {
            status = value;
        }
    }
    protected string companyName;
    [XmlAttribute]
    public string CompanyName
    { 
        get
        {
            return companyName;
        }
        set
        {
            companyName = value;
        }
    }
    protected string address;
    [XmlAttribute]
    public string Address
    { 
        get
        {
            return address;
        }
        set
        {
            address = value;
        }
    }
    protected string contactName;
    [XmlAttribute]
    public string ContactName
    { 
        get
        {
            return contactName;
        }
        set
        {
            contactName = value;
        }
    }
    protected string phone;
    [XmlAttribute]
    public string Phone
    { 
        get
        {
            return phone;
        }
        set
        {
            phone = value;
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
    protected bool isPartner;
    [XmlAttribute]
    public bool IsPartner
    { 
        get
        {
            return isPartner;
        }
        set
        {
            isPartner = value;
        }
    }
    protected bool isServicePartner;
    [XmlAttribute]
    public bool IsServicePartner
    { 
        get
        {
            return isServicePartner;
        }
        set
        {
            isServicePartner = value;
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
    public StatusRequest()
    {
    }
    public StatusRequest(DbDataReader r)
    {
        ID = Convert.ToInt32(r["ID"]);
        Status = Convert.ToString(r["Status"]);
        CompanyName = Convert.ToString(r["CompanyName"]);
        ContactName = Convert.ToString(r["ContactName"]);
        Address = Convert.ToString(r["Address"]);
        Phone = Convert.ToString(r["Phone"]);
        Email = Convert.ToString(r["Email"]);
        IsPartner = Convert.ToBoolean(r["IsPartner"]);
        IsServicePartner = Convert.ToBoolean(r["IsServicePartner"]);
        DateCreated = Convert.ToDateTime(r["DateCreated"]);
    }
}

}