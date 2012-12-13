using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Erc.Apple.Data
{
    [Serializable]
    public class TranslatableField : List<Translate>
    {
        public string this[string code]
        {
            get
            {
                string text = string.Empty;

                foreach (Translate t in this)
                {
                    if (t.LangCode == code)
                    {
                        text = t.Text;
                    }
                }
                return text;
            }
        }
        public void Add(string lang, string text)
        {
            Translate t = new Translate();

            t.LangCode = lang;
            t.Text = text;

            this.Add(t);
        }
    }

    [Serializable]
    public class Translate
    {
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
