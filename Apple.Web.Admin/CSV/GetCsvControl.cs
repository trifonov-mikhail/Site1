using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Apple.Web.Admin.CSV;

namespace Apple.Web.Admin.Controls
{
    /// <summary>
    /// Summary description for GetCsvControl
    /// </summary>
    public class GetCsvControl : CompositeControl
    {
        private CsvFileGenerator generator = new CsvFileGenerator();

        public CsvFileGenerator Generator
        {
            get { return generator; }
        }

        private Button buttonGenerate = new Button();

        public Button ButtonGenerate
        {
            get { return buttonGenerate; }
        }

        private string dataSourceID;

        public string DataSourceID
        {
            get 
            {
                return dataSourceID; 
            }
            set 
            {
                dataSourceID = value;
            }
        }

        public ReportOptions Options
        {
            get
            {
                return Generator.Options;
            }
        }

        public GetCsvControl()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            ButtonGenerate.Text = "Export to CSV";
            ButtonGenerate.Click += new EventHandler(ButtonGenerate_Click);
            ButtonGenerate.CssClass = "btn";

            this.Controls.Add(Generator);
            this.Controls.Add(ButtonGenerate);
        }

        void ButtonGenerate_Click(object sender, EventArgs e)
        {
            Generator.DataSourceID = this.DataSourceID;
            Generator.DataBind();
        }

        
    }
}