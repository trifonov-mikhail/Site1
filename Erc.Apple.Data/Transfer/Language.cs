using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
[Serializable]
public class Language
{
    protected string code;
    [XmlAttribute]
    public string Code
    { 
        get
        {
            return code;
        }
        set
        {
            code = value;
        }
    }
    protected string locale;
    [XmlAttribute]
    public string Locale
    { 
        get
        {
            return locale;
        }
        set
        {
            locale = value;
        }
    }

	protected string description;
	[XmlAttribute]
	public string Description
	{
		get
		{
			return description;
		}
		set
		{
			description = value;
		}
	}
}

}