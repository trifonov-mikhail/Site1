using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
[Serializable]
    public class TranslatableText
{
    protected string id;
    [XmlAttribute]
    public string ID
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
    protected int groupID;
    [XmlAttribute]
    public int GroupID
    { 
        get
        {
            return groupID;
        }
        set
        {
            groupID = value;
        }
    }
    protected string langCode;
    [XmlAttribute]
    public string LangCode
    { 
        get
        {
            return langCode;
        }
        set
        {
            langCode = value;
        }
    }
    protected string text;
    [XmlAttribute]
    public string Text
    { 
        get
        {
            return text;
        }
        set
        {
            text = value;
        }
    }
}

}