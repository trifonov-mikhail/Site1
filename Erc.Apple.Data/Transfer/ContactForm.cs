using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
[Serializable]
public class ContactForm
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
    protected string subject;
    [XmlAttribute]
    public string Subject
    { 
        get
        {
            return subject;
        }
        set
        {
            subject = value;
        }
    }
    protected string to;
    [XmlAttribute]
    public string To
    { 
        get
        {
            return to;
        }
        set
        {
            to = value;
        }
    }
    protected string cc;
    [XmlAttribute]
    public string CC
    { 
        get
        {
            return cc;
        }
        set
        {
            cc = value;
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

    private bool setForAllForms;

    [XmlIgnore]
    public bool SetForAllForms
    {
        get { return setForAllForms; }
        set { setForAllForms = value; }
    }
	

    public ContactForm()
    {
    }
    public ContactForm(DbDataReader r)
    {
        ID = Convert.ToInt32(r["ID"]);
        Name = Convert.ToString(r["Name"]);
        Subject = Convert.ToString(r["Subject"]);
        To = Convert.ToString(r["To"]);
        CC = Convert.ToString(r["CC"]);
        DateCreated = Convert.ToDateTime(r["DateCreated"]);
    }
}

}