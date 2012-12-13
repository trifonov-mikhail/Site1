using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
[Serializable]
public class DbConfigItem
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
    protected string _value;
    [XmlAttribute]
    public string Value
    { 
        get
        {
            return _value;
        }
        set
        {
            _value = value;
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
    
    public DbConfigItem()
    {
    }

    public DbConfigItem(string name,string value) 
    {
        this.Name = name;
        this.Value = value;
    }
}

}