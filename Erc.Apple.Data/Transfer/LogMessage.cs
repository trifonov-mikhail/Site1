using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
[Serializable]
public class LogMessage
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
    protected int messageType;
    [XmlAttribute]
    public int MessageType
    { 
        get
        {
            return messageType;
        }
        set
        {
            messageType = value;
        }
    }
    protected string source;
    [XmlAttribute]
    public string Source
    { 
        get
        {
            return source;
        }
        set
        {
            source = value;
        }
    }
    protected string message;
    [XmlAttribute]
    public string Message
    { 
        get
        {
            return message;
        }
        set
        {
            message = value;
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

    public LogMessage()
    {
    }
    public LogMessage(DbDataReader r)
    {
        ID = Convert.ToInt32(r["ID"]);
        MessageType = Convert.ToInt32(r["MessageType"]);
        Source = Convert.ToString(r["Source"]);
        Message = Convert.ToString(r["Message"]);
        DateCreated = Convert.ToDateTime(r["DateCreated"]);
    }
}

}