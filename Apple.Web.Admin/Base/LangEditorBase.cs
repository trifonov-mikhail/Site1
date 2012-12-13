using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Apple.Web.Admin.Controls
{
    /// <summary>
    /// Summary description for EditorBase
    /// </summary>
    public abstract class LangEditorBase : UserControl
    {
        protected abstract GridView ItemsList
        {
            get;
        }
        protected abstract DetailsView ItemDetails
        {
            get;
        }
        public LangEditorBase()
        {
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            
        }
    }
}